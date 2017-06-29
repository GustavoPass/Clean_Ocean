 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cleanOcean{
	public class Lixos : MonoBehaviour{
		
		private LixoManager lixoControl;

		private Transform trans;
		private WaitForSeconds timeWait;
		private SpriteRenderer render;

		public Sprite fase1;
		public Sprite fase2;
		public Sprite fase3;
		public Sprite faseAgua;

		private string lixoName;
		public byte fase;
		private WaitForSeconds evolveTime;
		private int posX, posY;
		private Vector2 toPos;

		private bool parado;

		private void Awake (){
			lixoControl = GameObject.Find ("Monster").GetComponent<LixoManager> ();
			render = GetComponent<SpriteRenderer> ();
			trans = GetComponent<Transform> ();
			timeWait = new WaitForSeconds (2);
			evolveTime = new WaitForSeconds (Random.Range(5,8));
			lixoName = this.name;
			toPos = new Vector2 (16, 0);
		}

		private void Update(){
			if (fase >= 2 && !parado) {
				trans.localPosition = Vector2.MoveTowards (trans.localPosition, toPos, 0.3f * Time.deltaTime);
			}
		}

		public bool isActive (){
			return gameObject.activeInHierarchy;
		}

		public void setMonsterPosition (Vector2 pos, int pX, int pY){
			gameObject.SetActive (true);
			render.sprite = fase1;
			render.sortingOrder = 0;
			trans.position = pos;
			posX = pX;
			posY = pY;
			fase = 0;
			parado = false;
			StartCoroutine (evolve ());
		}

		public void clearTrash(){
			parado = true;
			StartCoroutine (timeDespawn ());
		}

		private IEnumerator timeDespawn(){
			yield return timeWait;
			gameObject.SetActive (false);
			lixoControl.vidaControl (1);

			if (fase < 2) {
				lixoControl.clearTrashInTile (posX, posY, 1, true);
			} else {
				lixoControl.clearTrashInTile (posX, posY, 2, true);
			}
		}

		public void OnTriggerEnter2D(Collider2D hit){

			if (hit.gameObject.CompareTag (GameConstant.PODER_POSEIDON_TAG)) {
				clearTrash ();
				Debug.Log ("EEE");
				return;
			}
				
			if (hit.gameObject.CompareTag (GameConstant.MAR_TAG)) {
				render.sprite = faseAgua;
				return;
			}

			if (hit.gameObject.CompareTag (GameConstant.FIM_DA_LINHA_TAG)) {
				gameObject.SetActive (false);
				lixoControl.vidaControl (-15);
				return;
			}
		}

		private IEnumerator evolve(){
			yield return evolveTime;

			fase += 1;
			switch (fase) {

			case 1:
				render.sprite = fase2;
				StartCoroutine (evolve ());
				break;
			case 2:
				render.sprite = fase3;
				render.sortingOrder = 1;
				toPos.y = trans.position.y;
				lixoControl.clearTrashInTile (posX, posY, 0, false);
				break;
			}
		}
	}
}