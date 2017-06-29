using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

namespace cleanOcean{
	public class TouchPos : MonoBehaviour{

		private MetaGesture gesture;
		private ReleaseGesture releaseGesture;
		public MenuCartas menu;
		public interfaceController gotas;
		public CardInformation cardInfo;
		public UnitsPooling unitPool;

		public GameObject iluminacao;
		public GameObject areaPoseidon;
		public Poseidon poderPoseidon;
		private Transform areaTrans;
		private Color lightColor;
		private SpriteRenderer lightRender;
		private Vector2 luzPos;
		private Vector2 areaPos;

		private Vector2 touchPos;
		private Vector2 unitPos;
		private bool[,] unitVerificar;
		private Transform trans;

		public AudioClip rasteloSom;
		public AudioClip redeSom;
		public AudioClip aspiradorSom;
		public AudioClip mergulhadorSom;
		public AudioClip tridenteSom;

		private float tileSize = GameConstant.TILE_SIZE;

		private void Awake (){
			gesture = GetComponent<MetaGesture> ();
			releaseGesture = GetComponent<ReleaseGesture> ();
			trans = iluminacao.GetComponent<Transform> ();
			areaTrans = areaPoseidon.GetComponent<Transform> ();
			lightRender = iluminacao.GetComponent<SpriteRenderer> ();
			luzPos = new Vector2 ();
			unitPos = new Vector2 ();
			lightColor = new Color (1,1,1);
			unitVerificar = new bool[13,7];

		}

		private void OnEnable (){
			gesture.TouchMoved += selectTile;
			releaseGesture.Released += putCard;
		}

		private void OnDisable (){
			gesture.TouchMoved -= selectTile;
			releaseGesture.Released -= putCard;
		}

		private void selectTile (object sender, MetaGestureEventArgs metaGestureEventArgs){
			var touch = metaGestureEventArgs.Touch;
			var getTouchPos = Camera.main.ScreenToWorldPoint (touch.Position);
			touchPos = getTouchPos;

			if (touchPos.x < 0 || touchPos.y < 0) {
				iluminacao.SetActive (false);
				areaPoseidon.SetActive (false);
			} else {
				if (menu.cartaSelecionada != null) {
					iluminacao.SetActive (true);
					luzinha (menu.cartaSelecionada, tileDetectX (touchPos.x), tileDetectY (touchPos.y));
				}
			}
			menu.closeMenu (false);
			menu.cardStatus ();
		}

		private void putCard(object sender, System.EventArgs e){

			iluminacao.SetActive (false);
			if (touchPos.x < 0 || touchPos.y < 0) {
				menu.cartaSelecionada = null;
				return;
			}
				
			if (menu.cartaSelecionada != null) {
				if (string.Equals (menu.cartaSelecionada, "Poseidon") && gotas.quantidadeGotas >= menu.custo) {
					poderPoseidon.clear ();
					unitSet (menu.cartaSelecionada, 10, 2);
					menu.cartaSelecionada = null;
					return;
				}
				areaPoseidon.SetActive (false);
				unitSet (menu.cartaSelecionada, tileDetectX(touchPos.x), tileDetectY(touchPos.y));
				menu.cartaSelecionada = null;
			}
		}

		private int tileDetectY(float posY){

			for (var i = 1; i <= 7; i++) {
				if (posY < tileSize * i) {
					return i  - 1;
				}
			}
			return 0;
		}

		private int tileDetectX(float posX){

			for (var i = 1; i <= 13; i++) {
				if (posX < tileSize * i) {
					return i - 1;
				}
			}
			return 0;
		}

		private void luzinha(string name, int posX, int posY){

			luzPos.x = 0.228f * (posX);
			luzPos.y = 0.42f * (posY);

			trans.localPosition = luzPos;

			if (unitVerificar [posX, posY] && name != "Poseidon") {
				lightColor.g = 0;
				lightColor.b = 0;
				lightRender.color = lightColor;
				return;
			}

			if (string.Equals (name, "Poseidon")) {
				lightColor.g = 1;
				lightColor.b = 1;
				areaPoseidon.SetActive (true);
				areaPos.x = 0.228f * (posX);
				areaTrans.localPosition = areaPos;
				lightRender.color = lightColor;
				return;
			}

			if (posX < 4) {

				if (string.Equals (name, "Rastelo")) {
					lightColor.g = 1;
					lightColor.b = 1;
				} else {
					lightColor.g = 0;
					lightColor.b = 0;
				}
			} else if (posX < 9) {

				if (string.Equals (name, "Rede") || string.Equals (name, "Aspirador")) {
					lightColor.g = 1;
					lightColor.b = 1;
				} else {
					lightColor.g = 0;
					lightColor.b = 0;
				}
			} else {
				if (string.Equals (name, "Mergulhador")) {
					lightColor.g = 1;
					lightColor.b = 1;
				} else {
					lightColor.g = 0;
					lightColor.b = 0;
				}
			}

			lightRender.color = lightColor;
		}

		private void unitSet(string name, int posX, int posY){

			if (unitVerificar [posX, posY])
				return;

			if (gotas.quantidadeGotas < menu.custo)
				return;

			if (string.Equals (name, "Poseidon")) {

				var go = unitPool.spawnPoseidon ();
				unitPos.x = (posX) * tileSize - 1.2f;
				unitPos.y = (posY) * tileSize + 0.1f;
				go.setUnitPosition (unitPos, posX, posY);
				menu.cooldownBlock = true;
				menu.StartCoroutine (menu.cooldownGlobal ());
				unitVerificar [posX, posY] = true;
				gotas.gotasControl (-menu.custo);
				menu.playSound (tridenteSom);
				return;
			}

			if (posX < 4) {
				
				if (string.Equals (name, "Rastelo")) {
					
					var go = unitPool.spawnRastelo ();
					unitPos.x = (posX) * tileSize - 0.05f;
					unitPos.y = (posY) * tileSize + 0.3f;
					go.setUnitPosition (unitPos, posX, posY);
					menu.cooldownBlock = true;
					menu.StartCoroutine (menu.cooldownGlobal ());
					unitVerificar [posX, posY] = true;
					gotas.gotasControl (-menu.custo);
					menu.playSound (rasteloSom);
					return;
				}

			} else if (posX < 9) {
				
				if (string.Equals (name, "Rede")) {
					
					var go = unitPool.spawnRede ();
					unitPos.x = (posX) * tileSize - 0.05f;
					unitPos.y = (posY) * tileSize + 0.3f;
					go.setUnitPosition (unitPos, posX, posY);
					menu.cooldownBlock = true;
					menu.StartCoroutine (menu.cooldownGlobal ());
					unitVerificar [posX, posY] = true;
					gotas.gotasControl (-menu.custo);
					menu.playSound (redeSom);
					return;

				}else if (string.Equals (name, "Aspirador")) {
					
					var go = unitPool.spawnAspirador ();
					unitPos.x = (posX) * tileSize - 0.05f;
					unitPos.y = (posY) * tileSize;
					go.setUnitPosition (unitPos, posX, posY);
					menu.cooldownBlock = true;
					menu.StartCoroutine (menu.cooldownGlobal ());
					unitVerificar [posX, posY] = true;
					gotas.gotasControl (-menu.custo);
					menu.playSound (aspiradorSom);
					return;
				}

			} else {
				
				if (string.Equals (name, "Mergulhador")) {
					
					var go = unitPool.spawnMergulhador ();
					unitPos.x = (posX) * tileSize - 0.05f;
					unitPos.y = (posY) * tileSize;
					go.setUnitPosition (unitPos, posX, posY);
					menu.cooldownBlock = true;
					menu.StartCoroutine (menu.cooldownGlobal ());
					unitVerificar [posX, posY] = true;
					gotas.gotasControl (-menu.custo);
					menu.playSound (mergulhadorSom);
					return;

				}
			}



		}

		public void clearUnitInTile(int pX, int pY){
			unitVerificar [pX, pY] = false;
		}

	}
}
