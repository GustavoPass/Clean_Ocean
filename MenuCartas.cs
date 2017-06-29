using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

namespace cleanOcean{
	public class MenuCartas : MonoBehaviour {

		private TapGesture tapGesture;
		private Transform trans;
		private interfaceController interfeice;
		public bool openClose = false;
		public string cartaSelecionada;
		public int custo;

		private GameObject[] cartaArray;
		private BoxCollider2D[] bc;
		private Carta[] cartaSC;

		private WaitForSeconds cooldown;
		public bool cooldownBlock;

		private AudioSource inputAudio;
		public AudioClip somCarta;

		private void Awake(){
			tapGesture = GetComponent<TapGesture> ();
			trans = GetComponent<Transform> ();
			inputAudio = GetComponent<AudioSource> ();
			interfeice = FindObjectOfType<interfaceController> ();
			inputAudio.clip = somCarta;

			cartaArray = new GameObject[trans.childCount];
			bc = new BoxCollider2D[trans.childCount];
			cartaSC = new Carta[trans.childCount];

			for(var i = 0; i < cartaArray.Length; i++){
				cartaArray [i] = trans.GetChild (i).gameObject;
				bc [i] = cartaArray [i].GetComponent<BoxCollider2D> ();
				cartaSC [i] = cartaArray [i].GetComponent<Carta> ();
			}

			cartaSelecionada = null;
			cooldown = new WaitForSeconds (GameConstant.COOLDOWN_TIME_CARD);
		}

		private void OnEnable(){
			tapGesture.Tapped += menuCartasOnOff;
		}

		private void OnDisable(){
			tapGesture.Tapped -= menuCartasOnOff;
		}

		public void menuCartasOnOff (object sender, System.EventArgs e){
			//Animação do botão de esconder/mostrar menu de cartas.
			closeMenu (true);
		}

		public void closeMenu(bool state){
			openClose = state;
			if (state) {
				cartaSelecionada = null;
				custo = 0;
			}
		}

		private void Update () {

			//tentar travar o codigo pra evitar ficar chamando repetidamente !!!!!
			if (!cooldownBlock) {
				moveCards ();
			} else {
				for (var i = 0; i < bc.Length; i++) {
					if (!cartaSC [i].selecionado) {
						cartaSC [i].moveCard (0);
					}
					bc [i].enabled = false;
				}
			}
		}

		public void moveCards(){

			//Animação sobe/desce do menu de cartas.
			if (openClose) {
				//Abrir menu - sube cartas
				for (var i = 0; i < bc.Length; i++) {
					cartaSC [i].moveCard (2.3f);
					bc [i].enabled = true;
				}
			} else {
				//Fecha menu - baixa cartas
				for (var i = 0; i < bc.Length; i++) {
					if (!cartaSC [i].selecionado) {
						cartaSC [i].moveCard (0);
					}
					bc [i].enabled = false;
				}
			}
		}
			
		public void cardStatus(){

			for (var i = 0; i < cartaSC.Length; i++) {
				cartaSC [i].selecionado = false;
			}
		}

		public void playSound(){
			inputAudio.volume = GameConstant.GAME_VOLUME;
			if (!inputAudio.isPlaying) {
				inputAudio.clip = somCarta;
				inputAudio.Play ();
			}
		}

		public void playSound(AudioClip som){
			inputAudio.volume = GameConstant.GAME_VOLUME;
			if (!inputAudio.isPlaying || inputAudio.clip.Equals(somCarta)) {
				inputAudio.clip = som;
				inputAudio.Play ();
			}
		}

		public IEnumerator cooldownGlobal(){

			cooldownBlock = true;
			for (var i = 0; i < cartaSC.Length; i++) {
				cartaSC [i].colorChange (0.4f);
			}

			yield return cooldown;

			cooldownBlock = false;
			for (var i = 0; i < cartaSC.Length; i++) {
				if(interfeice.quantidadeGotas >= cartaSC[i].custo)
				cartaSC [i].colorChange (1f);
			}
		}	
	}
}

