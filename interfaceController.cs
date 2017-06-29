using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace cleanOcean{
	public class interfaceController : MonoBehaviour {
		
		private float rr;
		private float gg;

		public GameObject barraDeVida;

		private SpriteRenderer cor;
		private Color corBarra;

		public int life;
		public int quantidadeGotas;
		public int pontuacao;
		public Text gotas;
		public Text pontos;
		public Text record;
		private WaitForSeconds tempo;
		public GameObject derrota;

		public Carta[] cartas;

		private void Awake(){
			cor = barraDeVida.GetComponent<SpriteRenderer> ();
			rr = 0;
			gg = 1;
			life = 50;
			//Iniciar com a cor verde
			corBarra = new Color (rr, gg, 0);
			cor.color = corBarra;
			tempo = new WaitForSeconds (8);
			if (!GameConstant.tutorial)
			StartCoroutine (ganharGota ());

		}

		private void Start(){
			if (!GameConstant.tutorial)
			gotasControl (5);
		}

		private void Update () {
			if (life < 0) {
				life = 0;
				derrota.SetActive (true);

				if (PlayerPrefs.GetInt ("HighScore") < pontuacao) {
					PlayerPrefs.SetInt ("HighScore", pontuacao);
				}

				pontos.text = "Pontos:  " + pontuacao.ToString ();
				record.text = "Record:  " + PlayerPrefs.GetInt ("HighScore").ToString();
				Time.timeScale = 0;
			}
			colorChange ();
		}

		private void colorChange(){
			
				if (life > 30) {
					//Verde
					rr = Mathf.MoveTowards (rr, 0, 0.5f * Time.deltaTime);
					gg = Mathf.MoveTowards (gg, 1, 0.5f * Time.deltaTime);
				} else if (life > 20) {
					//Amarelo
					rr = Mathf.MoveTowards (rr, 1, 0.5f * Time.deltaTime);
					gg = Mathf.MoveTowards (gg, 1, 0.5f * Time.deltaTime);
				} else if (life > 10) {
					//Laranja
					rr = Mathf.MoveTowards (rr, 1, 0.5f * Time.deltaTime);
					gg = Mathf.MoveTowards (gg, 0.6f, 0.5f * Time.deltaTime);
				} else {
					//Vermelho
					rr = Mathf.MoveTowards (rr, 1, 0.5f * Time.deltaTime);
					gg = Mathf.MoveTowards (gg, 0, 0.5f * Time.deltaTime);
				}

				corBarra.r = rr;
				corBarra.g = gg;
				cor.color = corBarra;
		}

		public void gotasControl(int number){
			quantidadeGotas += number;
			gotas.text = quantidadeGotas.ToString();

			cardColorEnable ();
		}

		private void cardColorEnable(){
			for (var i = 0; i < cartas.Length; i++) {

				if (quantidadeGotas >= cartas [i].custo) {
					cartas [i].colorChange (1f);
				} else {
					cartas [i].colorChange (0.4f);
				}
			}
		}

		public IEnumerator ganharGota(){
			yield return tempo;
			gotasControl (1);
			StartCoroutine (ganharGota ());
		}
	}
}

