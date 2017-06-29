using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cleanOcean{
	public class Ondas : MonoBehaviour {

		private GameObject[] ondas;
		private WaitForSeconds tempoOnda;
		private int index;

		private void Awake () {

			ondas = new GameObject[gameObject.transform.childCount];

			for (var i = 0; i < ondas.Length; i++) {
				ondas [i] = gameObject.transform.GetChild (i).gameObject;
			}

			tempoOnda = new WaitForSeconds (5);
			index = Random.Range (0, 3);
			StartCoroutine (ondaWave ());
		}

		private IEnumerator ondaWave(){

			yield return tempoOnda;
			ondas [index].SetActive (true);
			index = (index + 1) % ondas.Length;
			StartCoroutine (ondaWave ());
		}
	}
}
