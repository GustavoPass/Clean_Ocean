using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace cleanOcean
{
	public class PauseConfig : MonoBehaviour
	{

		public GameObject pause;

		public GameObject loading;

		public Image imgVolume;
		public Sprite volumeOn;
		public Sprite volumeOff;
		private AudioSource somJoao;
		public AudioSource music;
		public AudioSource somToque;

		private int v;

		private void Start ()
		{
			GameConstant.GAME_VOLUME = PlayerPrefs.GetInt ("volume");
			somJoao = GetComponent<AudioSource> ();

			switch (GameConstant.GAME_VOLUME) {
			case 1:
				imgVolume.sprite = volumeOn;
				somJoao.volume = 1f;
				music.volume = 0.2f;
				break;
			case 0:
				imgVolume.sprite = volumeOff;
				somJoao.volume = 0f;
				music.volume = 0;
				break;
			}
		}

		public void menuInicial ()
		{
			somToque.volume = GameConstant.GAME_VOLUME;
			somToque.Play ();
			Time.timeScale = 1;
			loading.SetActive (true);
			SceneManager.LoadSceneAsync (0);
		}

		public void soundChange ()
		{

			v = GameConstant.GAME_VOLUME;

			switch (v) {
			case 1:
				PlayerPrefs.SetInt ("volume", 0);
				GameConstant.GAME_VOLUME = 0;
				imgVolume.sprite = volumeOff;
				somJoao.volume = 0;
				music.volume = 0;
				break;

			case 0:
				PlayerPrefs.SetInt ("volume", 1);
				GameConstant.GAME_VOLUME = 1;
				imgVolume.sprite = volumeOn;
				somJoao.volume = 1f;
				music.volume = 0.2f;
				break;
			}
		}

		public void pauseGame ()
		{

			somToque.volume = GameConstant.GAME_VOLUME;
			somToque.Play ();

			switch ((int)Time.timeScale) {
			case 0:
				Time.timeScale = 1;
				pause.SetActive (false);
				break;
			case 1:
				Time.timeScale = 0;
				pause.SetActive (true);
				break;
			}
		}
	}
}
