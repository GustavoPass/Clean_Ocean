using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace cleanOcean{
	public class Options : MonoBehaviour {

		public Image imgVolume;
		public Sprite volumeOn;
		public Sprite volumeOff;
		private int v;

		private void Start () {
			GameConstant.GAME_VOLUME = PlayerPrefs.GetInt ("volume");

			switch ( GameConstant.GAME_VOLUME) {
			case 1:
				imgVolume.sprite = volumeOn;
				break;
			case 0:
				imgVolume.sprite = volumeOff;
				break;
			}
		}

		public void menuInicial(){
			SceneManager.LoadScene ("MenuPrincipal");
		}

		public void soundChange(){

			v = GameConstant.GAME_VOLUME;

			switch (v) {
			case 1:
				PlayerPrefs.SetInt ("volume", 0);
				GameConstant.GAME_VOLUME = 0;
				imgVolume.sprite = volumeOff;
				break;

			case 0:
				PlayerPrefs.SetInt ("volume", 1);
				GameConstant.GAME_VOLUME = 1;
				imgVolume.sprite = volumeOn;
				break;

			}
		}
	}
}
