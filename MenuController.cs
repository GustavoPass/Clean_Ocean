using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace cleanOcean
{
	public class MenuController : MonoBehaviour
	{
		
		public GameObject menu;
		public GameObject creditos;
		public GameObject options;
		public GameObject loading;
		public Image imgVolume;
		public Sprite volumeOn;
		public Sprite volumeOff;
		public AudioSource audioMenu;
		public AudioSource audioClick;
		public AudioClip sound;
		private int v;

		private void Start ()
		{
			switch (GameConstant.GAME_VOLUME) {
			case 1:
				audioMenu.volume = 1;
				audioClick.volume = 1;
				imgVolume.sprite = volumeOn;
				break;
			case 0:
				audioMenu.volume = 0;
				audioClick.volume = 0;
				audioMenu.Stop ();
				imgVolume.sprite = volumeOff;
				break;
			}
		}

		public void PlayVolume ()
		{

			v = GameConstant.GAME_VOLUME;

			switch (v) {
			case 1:
				PlayerPrefs.SetInt ("volume", 0);
				GameConstant.GAME_VOLUME = 0;
				audioMenu.volume = 0;
				audioMenu.Stop ();
				audioClick.volume = 0;
				imgVolume.sprite = volumeOff;
				break;

			case 0:
				PlayerPrefs.SetInt ("volume", 1);
				GameConstant.GAME_VOLUME = 1;
				audioMenu.volume = 1;
				audioMenu.Play ();
				audioClick.volume = 1;
				imgVolume.sprite = volumeOn;
				break;

			}
		}


		public void Option (int opt)
		{

			switch (opt) {
			case 0:
				audioClick.PlayOneShot (sound);
				loading.SetActive (true);
				SceneManager.LoadSceneAsync ("Inter");
				break;
			case 1:
				audioClick.PlayOneShot (sound);
				menu.SetActive (false);
				options.SetActive (true);
				break;
			case 2:
				audioClick.PlayOneShot (sound);
				menu.SetActive (true);
				options.SetActive (false);
				break;
			case 3:
				audioClick.PlayOneShot (sound);
				menu.SetActive (false);
				creditos.SetActive (true);
				break;
			case 4:
				audioClick.PlayOneShot (sound);
				menu.SetActive (true);
				creditos.SetActive (false);
				break;
			}				
		}
	}
}
