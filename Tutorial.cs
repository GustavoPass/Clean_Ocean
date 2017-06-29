using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using UnityEngine.UI;

namespace cleanOcean{
	public class Tutorial : MonoBehaviour {

		private TapGesture tapGesture;
		public MenuCartas menuCarta;
		public interfaceController interfeice;
		public TouchPos touchTiles;
		public LixoManager lixos;

		public GameObject cvTutorial;
		public Text fala;

		public GameObject chiclete;
		public GameObject tutorialMost;
		private SpriteRenderer render;
		private Transform transClete;
		public Sprite fase2;
		public Sprite fase3;
		public Sprite faseAgua;
		private Vector2 setPos;

		public GameObject[] cartas;
		private SpriteRenderer[] rendCard;
		private TapGesture[] tapCard;
		private LongPressGesture[] pressCard;
		public BoxCollider2D bc;

		private WaitForSeconds tempo;
		private WaitForSeconds change;
		private int despacito;

		public AudioClip[] falasAudio;
		private AudioSource inputAudio;
		private int audioChange;

		private void Awake () {

			if (!GameConstant.tutorial) {
				lixos.StartCoroutine (lixos.comecaWave ());
				tutorialMost.SetActive(false);
				var tuto = GetComponent<Tutorial> ();
				tuto.enabled = false;
			}else{
				
				bc.enabled = false;
				tutorialMost.SetActive(true);

				tapGesture = cvTutorial.GetComponent<TapGesture> ();
				render = chiclete.GetComponent<SpriteRenderer> ();
				transClete = chiclete.GetComponent<Transform> ();

				inputAudio = GetComponent<AudioSource> ();
				inputAudio.volume = GameConstant.GAME_VOLUME;

				rendCard = new SpriteRenderer[cartas.Length];
				tapCard = new TapGesture[cartas.Length];
				pressCard = new LongPressGesture[cartas.Length];

				for (var i = 0; i < cartas.Length; i++) {
					rendCard [i] = cartas [i].GetComponent<SpriteRenderer> ();
					tapCard[i] = cartas [i].GetComponent<TapGesture> ();
					pressCard[i] = cartas [i].GetComponent<LongPressGesture> ();
					tapCard [i].enabled = false;
					pressCard [i].enabled = false;
				}

				touchTiles.enabled = false;

				setPos = new Vector2 (-1.5f, 0);

				tempo = new WaitForSeconds (2);
				change = new WaitForSeconds (1);

				seila ();

			}
		}

		private void Update(){

			if (despacito < 18) 
				return;
			
			if (despacito == 18) {
				transClete.localPosition = Vector2.MoveTowards (transClete.localPosition, setPos, Time.deltaTime);
				if (transClete.localPosition.x == -1.5f) {
					render.sprite = faseAgua;
				}
			}else if (despacito == 20 || despacito == 22) {
				transClete.localPosition = Vector2.MoveTowards (transClete.localPosition, setPos, Time.deltaTime);

				if (transClete.localPosition.x >= 9.5f) {
					interfeice.life = 25;
				}
			}
		}

		private void OnEnable(){
			if(GameConstant.tutorial)
			tapGesture.Tapped += skip;
		}

		private void OnDisable(){
			if(GameConstant.tutorial)
			tapGesture.Tapped -= skip;
		}

		public void skip (object sender, System.EventArgs e){
			despacito += 1;
			seila ();
		}
			

		private void dialogue(bool b){
			cvTutorial.SetActive (b);
		}
			
		private void seila(){

			switch (despacito) {

			case 0:
				StartCoroutine (nsei (true));
				break;

			case 1:
				inputAudio.clip = falasAudio [audioChange];
				audioChange += 1;
				inputAudio.Play ();
				fala.text = "Oi, eu sou o João! Sou diretor da EcoSurf e irei mostrar para vocês o problema dos lixos nas praias e como podemos combatê-los!";
				break;

			case 2:
				inputAudio.clip = falasAudio [audioChange];
				audioChange += 1;
				inputAudio.Play ();
				fala.text = "Algumas pessoas que frequentam as praias acabam deixando lixos jogados na areia. Isso acaba prejudicando a praia e o ambiente.";
				break;

			case 3:
				inputAudio.clip = falasAudio [audioChange];
				audioChange += 1;
				inputAudio.Play ();
				fala.text = "Para combater o lixo na praia você deve usar as cartas. Ao usá-las, você gasta gotas que são obtidas por tempo ou por lixo limpado.";
				break;

			case 4:
				dialogue (false);
				StartCoroutine (nsei (true));
				menuCarta.openClose = true;

				rendCard [0].sortingLayerName = "Canvas";
				rendCard [0].sortingOrder = 5;
				fala.text = "A carta do rastelo é usada na areia. Ela possui uma borda laranja para facilitar a identificação de sua área de ação";
				break;

			case 6:
				dialogue (false);
				StartCoroutine (nsei (true));
				rendCard [0].sortingLayerName = "Cartas";
				rendCard [0].sortingOrder = 1;

				rendCard [1].sortingLayerName = "Canvas";
				rendCard [1].sortingOrder = 5;
				rendCard [2].sortingLayerName = "Canvas";
				rendCard [2].sortingOrder = 5;
				fala.text = "As cartas rede e aspirador são usadas na área inside, destinada aos banhistas. Elas possuem uma borda com cor turquesa.";
				break;

			case 8:
				dialogue (false);
				StartCoroutine (nsei (true));
				rendCard [1].sortingLayerName = "Cartas";
				rendCard [1].sortingOrder = 1;
				rendCard [2].sortingLayerName = "Cartas";
				rendCard [2].sortingOrder = 1;

				rendCard [3].sortingLayerName = "Canvas";
				rendCard [3].sortingOrder = 5;
				fala.text = "A carta mergulhador é usa na área outside, destinada aos navios de pesca e lanchas. Ela possui uma borda roxa.";
				break;

			case 10:
				dialogue (false);
				StartCoroutine (nsei (true));
				rendCard [3].sortingLayerName = "Cartas";
				rendCard [3].sortingOrder = 1;

				rendCard [4].sortingLayerName = "Canvas";
				rendCard [4].sortingOrder = 5;
				fala.text = "Já a carta Poseidon, uma das cartas mais poderosas, é usada em qualquer local. Ela possui uma borda colorida.";
				break;

			case 12:
				dialogue (false);
				StartCoroutine (spriteChange (0));
				rendCard [4].sortingLayerName = "Cartas";
				rendCard [4].sortingOrder = 1;
				menuCarta.openClose = false;
				fala.text = "Jogaram um chiclete na areia. Caso não o limpe, ele se transformará em um pequeno monstro.";
				tempo = new WaitForSeconds (2.5f);
				setPos.y = transClete.localPosition.y;
				StartCoroutine (nsei (true));
				break;

			case 14:
				dialogue (false);
				StartCoroutine (spriteChange(1));
				StartCoroutine (nsei (true));
				fala.text = "Conforme vai passando o tempo e o chiclete continuar jogado na areia, ele continuará evoluindo.";
				break;

			case 16:
				dialogue (false);
				StartCoroutine (spriteChange(2));
				StartCoroutine (nsei (true));
				fala.text = "Último estágio do monstro permite que ele possa caminhar. Ele andará até a água";
				break;

			case 18:
				dialogue (false);
				tempo = new WaitForSeconds (4f);
				StartCoroutine (nsei (true));
				fala.text = "O lixo entrou na água, mas continuará seguindo.";
				break;

			case 20:
				dialogue (false);
				setPos.x = 10; 
				tempo = new WaitForSeconds (7f);
				StartCoroutine (nsei (true));
				fala.text = "O chiclete tentará chegar ao final do mar, caso isso aconteça, sua saúde cairá!";
				break;

			case 22:
				dialogue (false);
				tempo = new WaitForSeconds (4f);
				StartCoroutine (nsei (true));
				fala.text = "O chiclete chegou no final e sua saúde diminuiu. Você deverá evitar com que isso aconteça.";
				break;

			case 24:
				fala.text = "Caso você precise, pressionar sobre uma carta abrirá um menu monstrando informações sobre ela! ";
				break;

			case 25:
				fala.text = "Espero tê-lo ajudado. Agora é sua vez! Boa sorte!";
				interfeice.life = 50;
				interfeice.quantidadeGotas = 5;
				inputAudio.clip = falasAudio [0];
				inputAudio.Play ();
				for (var i = 0; i < cartas.Length; i++) {
					tapCard [i].enabled = true;
					pressCard [i].enabled = true;
				}
				touchTiles.enabled = true;
				bc.enabled = true;
				break;

			case 26:
				dialogue (false);
				interfeice.StartCoroutine (interfeice.ganharGota ());
				interfeice.gotasControl (0);
				lixos.StartCoroutine (lixos.comecaWave ());
				GameConstant.tutorial = false;
				tutorialMost.SetActive(false);
				var tuto = GetComponent<Tutorial> ();
				tuto.enabled = false;
				break;

			default:
				dialogue(false);
				break;

			}
		}

		public IEnumerator nsei(bool b){
			yield return tempo;
			despacito += 1;
			seila ();
			dialogue (b);
			inputAudio.clip = falasAudio [audioChange];
			audioChange = (audioChange + 1) % falasAudio.Length;
			inputAudio.Play ();
		}

		public IEnumerator spriteChange(int i){
			yield return change;

			switch (i) {
			case 0:
				chiclete.SetActive (true);
				break;

			case 1:
				render.sprite = fase2;
				break;

			case 2:
				render.sprite = fase3;
				break;
			}
		}
	}
}
