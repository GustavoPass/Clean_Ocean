using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace cleanOcean{
	[RequireComponent(typeof(Button))]
	public class ClickSound : MonoBehaviour {

		public AudioClip sound;

		private Button button { get { return GetComponent<Button> (); } }
		private AudioSource source { get { return GetComponent<AudioSource> (); } }

		// Use this for initialization
		void Start () {
				gameObject.AddComponent<AudioSource> ();
				source.clip = sound;
				source.playOnAwake = false;

				button.onClick.AddListener (() => PlaySound ());
		}
		
		// Update is called once per frame
		void PlaySound () {
				source.PlayOneShot (sound);
		}
	}
}