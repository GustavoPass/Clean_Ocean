using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cleanOcean{
	public class Units : MonoBehaviour {

		public TouchPos tiles;

		private Transform trans;
		private SpriteRenderer render;
		[SerializeField]
		private byte trashClear;
		private WaitForSeconds timeDespawn;
		private int posX, posY;
		public int typeUnit;

		private void Awake (){
			tiles = GameObject.Find ("touchTiles").GetComponent<TouchPos> ();
			trans = GetComponent<Transform> ();
			render = GetComponent<SpriteRenderer> ();

			switch (typeUnit) {
			case 3:
				timeDespawn = new WaitForSeconds (20f);

				break;
				 
			default:
				timeDespawn = new WaitForSeconds (3f);
				break;
			}
		}

		public bool isActive(){ return gameObject.activeInHierarchy;}
		

		public void setUnitPosition (Vector2 pos, int pX, int pY){
			trashClear = 0;
			gameObject.SetActive (true);
			trans.position = pos;
			render.sortingOrder = 7 -(int)pos.y;
			posX = pX;
			posY = pY;

			if (typeUnit == 3) {
				StartCoroutine (despawn ());
			}
		}

		public void OnTriggerEnter2D(Collider2D hit){

			if (trashClear < 2)
			if (hit.gameObject.CompareTag (GameConstant.LIXO_TAG)) {
				hit.gameObject.GetComponent<Lixos> ().clearTrash ();

				switch (typeUnit) {

				case 1://rastelo

					if (hit.gameObject.GetComponent<Lixos> ().fase > 1) {
						trashClear += 2;
					} else {
						trashClear += 1;
					}

					break;

				case 5://Poseidon
					return;
					break;

				default:
					trashClear += 1;

					break;


				}
			}

			if (trashClear >= 2) {
				StartCoroutine (despawn ());
			}

			/*
				if (aspirador)
					return;

				if (hit.gameObject.GetComponent<Lixos> ().fase > 1) {
					trashClear += 2;
				} else {
					trashClear += 1;
				}
			}

			if (trashClear >= 2) {
				StartCoroutine (despawn ());
			}
*/



		}

		public IEnumerator despawn(){
			yield return timeDespawn;
			tiles.clearUnitInTile (posX, posY);
			gameObject.SetActive (false);
		}
	}
}
