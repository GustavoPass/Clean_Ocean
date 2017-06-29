using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cleanOcean{
	public class MonsterPooling : MonoBehaviour{

		public GameObject chicletePrefab;
		public Transform chicleteContainer;
		private int chichleteIndex;
		private List<Lixos> chiclete;

		public GameObject cervejaPrefab;
		public Transform cervejaContainer;
		private int cervejaIndex;
		private List<Lixos> cerveja;

		public GameObject cigarroPrefab;
		public Transform cigarroContainer;
		private int cigarroIndex;
		private List<Lixos> cigarro;

		public GameObject cocoPrefab;
		public Transform cocoContainer;
		private int cocoIndex;
		private List<Lixos> coco;

		public GameObject garrafaPrefab;
		public Transform garrafaContainer;
		private int garrafaIndex;
		private List<Lixos> garrafa;

		public GameObject vidroPrefab;
		public Transform vidroContainer;
		private int vidroIndex;
		private List<Lixos> vidro;

		private void Awake (){
			
			chiclete = new List<Lixos> ();
			chiclete.Capacity = GameConstant.CHICLETE_QUANTIDADE;
			addChiclete ();

			cerveja = new List<Lixos> ();
			cerveja.Capacity = GameConstant.CERVEJA_QUANTIDADE;
			addCerveja ();

			cigarro = new List<Lixos> ();
			cigarro.Capacity = GameConstant.CIGARRO_QUANTIDADE;
			addCigarro ();

			coco = new List<Lixos> ();
			coco.Capacity = GameConstant.COCO_QUANTIDADE;
			addCoco ();

			garrafa = new List<Lixos> ();
			garrafa.Capacity = GameConstant.GARRAFA_QUANTIDADE;
			addGarrafa ();

			vidro = new List<Lixos> ();
			vidro.Capacity = GameConstant.VIDRO_QUANTIDADE;
			addVidro ();
		}


		private void addChiclete (){
			for (var i = 0; i < GameConstant.CHICLETE_QUANTIDADE; i++) {
				var un = Instantiate (chicletePrefab);
				un.SetActive (false);
				un.transform.parent = chicleteContainer;
				chiclete.Add (un.GetComponent<Lixos> ());
			}
		}

		public Lixos spawnChiclete (){
			Lixos un = chiclete [chichleteIndex];
			if (un.isActive ()) {
				for (var i = 0; i < chiclete.Count; i++) {
					un = chiclete [i];
					if (!un.isActive ()) {
						chichleteIndex = (chichleteIndex + 1) % chiclete.Count;
						return un;
					}
				}
				Debug.Log ("Chiclete insuficiente");
				return null;
			}

			chichleteIndex = (chichleteIndex + 1) % chiclete.Count;
			return un;
		}

		private void addCerveja (){
			for (var i = 0; i < GameConstant.CERVEJA_QUANTIDADE; i++) {
				var un = Instantiate (cervejaPrefab);
				un.SetActive (false);
				un.transform.parent = cervejaContainer;
				cerveja.Add (un.GetComponent<Lixos> ());
			}
		}

		public Lixos spawnCerveja (){
			Lixos un = cerveja [cervejaIndex];
			if (un.isActive ()) {
				for (var i = 0; i < cerveja.Count; i++) {
					un = cerveja [i];
					if (!un.isActive ()) {
						cervejaIndex = (cervejaIndex + 1) % cerveja.Count;
						return un;
					}
				}
				Debug.Log ("Cerveja insuficiente");
				return null;
			}

			cervejaIndex = (cervejaIndex + 1) % cerveja.Count;
			return un;
		}

		private void addCigarro (){
			for (var i = 0; i < GameConstant.CIGARRO_QUANTIDADE; i++) {
				var un = Instantiate (cigarroPrefab);
				un.SetActive (false);
				un.transform.parent = cigarroContainer;
				cigarro.Add (un.GetComponent<Lixos> ());
			}
		}

		public Lixos spawnCigarro (){
			Lixos un = cigarro [cigarroIndex];
			if (un.isActive ()) {
				for (var i = 0; i < cigarro.Count; i++) {
					un = cigarro [i];
					if (!un.isActive ()) {
						cigarroIndex = (cigarroIndex + 1) % cigarro.Count;
						return un;
					}
				}
				Debug.Log ("Cigarro insuficiente");
				return null;
			}

			cigarroIndex = (cigarroIndex + 1) % cigarro.Count;
			return un;
		}

		private void addCoco (){
			for (var i = 0; i < GameConstant.COCO_QUANTIDADE; i++) {
				var un = Instantiate (cocoPrefab);
				un.SetActive (false);
				un.transform.parent = cocoContainer;
				coco.Add (un.GetComponent<Lixos> ());
			}
		}

		public Lixos spawnCoco (){
			Lixos un = coco [cocoIndex];
			if (un.isActive ()) {
				for (var i = 0; i < coco.Count; i++) {
					un = coco [i];
					if (!un.isActive ()) {
						cocoIndex = (cocoIndex + 1) % coco.Count;
						return un;
					}
				}
				Debug.Log ("Coco insuficiente");
				return null;
			}

			cocoIndex = (cocoIndex + 1) % coco.Count;
			return un;
		}

		private void addGarrafa (){
			for (var i = 0; i < GameConstant.GARRAFA_QUANTIDADE; i++) {
				var un = Instantiate (garrafaPrefab);
				un.SetActive (false);
				un.transform.parent = garrafaContainer;
				garrafa.Add (un.GetComponent<Lixos> ());
			}
		}

		public Lixos spawnGarrafa (){
			Lixos un = garrafa [garrafaIndex];
			if (un.isActive ()) {
				for (var i = 0; i < garrafa.Count; i++) {
					un = garrafa [i];
					if (!un.isActive ()) {
						garrafaIndex = (garrafaIndex + 1) % garrafa.Count;
						return un;
					}
				}
				Debug.Log ("Garrafa insuficiente");
				return null;
			}

			garrafaIndex = (garrafaIndex + 1) % garrafa.Count;
			return un;
		}

		private void addVidro (){
			for (var i = 0; i < GameConstant.VIDRO_QUANTIDADE; i++) {
				var un = Instantiate (vidroPrefab);
				un.SetActive (false);
				un.transform.parent = vidroContainer;
				vidro.Add (un.GetComponent<Lixos> ());
			}
		}

		public Lixos spawnVidro (){
			Lixos un = vidro [vidroIndex];
			if (un.isActive ()) {
				for (var i = 0; i < vidro.Count; i++) {
					un = vidro [i];
					if (!un.isActive ()) {
						vidroIndex = (vidroIndex + 1) % vidro.Count;
						return un;
					}
				}
				Debug.Log ("Vidro insuficiente");
				return null;
			}

			vidroIndex = (vidroIndex + 1) % vidro.Count;
			return un;
		}
	}
}
