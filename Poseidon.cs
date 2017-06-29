using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cleanOcean{
	public class Poseidon : MonoBehaviour {

		public TouchPos tiles;
		public GameObject areaPoder;
		private GameObject poseidon;
		private BoxCollider2D bc;
		private WaitForSeconds tempo;

		private void Start(){
			bc = areaPoder.GetComponent<BoxCollider2D> ();
			tempo = new WaitForSeconds (4f);
			poseidon = transform.GetChild (0).gameObject;
		}
		

		public void clear(){
			StartCoroutine (poder ());
		}

		private IEnumerator poder(){

			bc.enabled = true;
			yield return tempo;
			bc.enabled = false;
			areaPoder.SetActive (false);
			poseidon.SetActive (false);
			tiles.clearUnitInTile (10, 2);
		}
	}
}
