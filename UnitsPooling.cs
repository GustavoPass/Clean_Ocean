using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cleanOcean{
	public class UnitsPooling : MonoBehaviour{

		public GameObject rasteloPrefab;
		public Transform rasteloContainer;
		private int rasteloIndex;
		private List<Units> rastelo;

		public GameObject redePrefab;
		public Transform redeContainer;
		private int redeIndex;
		private List<Units> rede;

		public GameObject aspiradorPrefab;
		public Transform aspiradorContainer;
		private int aspiradorIndex;
		private List<Units> aspirador;

		public GameObject mergulhadorPrefab;
		public Transform mergulhadorContainer;
		private int mergulhadorIndex;
		private List<Units> mergulhador;

		public GameObject poseidonPrefab;
		public Transform poseidonContainer;
		private int poseidonIndex;
		private List<Units> poseidon;

		private void Awake (){

			rastelo = new List<Units> ();
			rastelo.Capacity = GameConstant.RASTELO_QUANTIDADE;
			addRastelo ();

			rede = new List<Units> ();
			rede.Capacity = GameConstant.REDE_QUANTIDADE;
			addRede ();

			aspirador = new List<Units> ();
			aspirador.Capacity = GameConstant.ASPIRADOR_QUANTIDADE;
			addAspirador ();

			mergulhador = new List<Units> ();
			mergulhador.Capacity = GameConstant.MERGULHADOR_QUANTIDADE;
			addMergulhador ();

			poseidon = new List<Units> ();
			poseidon.Capacity = GameConstant.POSEIDON_QUANTIDADE;
			addPoseidon ();

		}

		private void addRastelo (){
			for (var i = 0; i < GameConstant.RASTELO_QUANTIDADE; i++) {
				var un = Instantiate (rasteloPrefab);
				un.SetActive (false);
				un.transform.parent = rasteloContainer;
				rastelo.Add (un.GetComponent<Units> ());
			}
		}

		private void addRede (){
			for (var i = 0; i < GameConstant.REDE_QUANTIDADE; i++) {
				var un = Instantiate (redePrefab);
				un.SetActive (false);
				un.transform.parent = redeContainer;
				rede.Add (un.GetComponent<Units> ());
			}
		}

		private void addAspirador (){
			for (var i = 0; i < GameConstant.ASPIRADOR_QUANTIDADE; i++) {
				var un = Instantiate (aspiradorPrefab);
				un.SetActive (false);
				un.transform.parent = aspiradorContainer;
				aspirador.Add (un.GetComponent<Units> ());
			}
		}

		private void addMergulhador (){
			for (var i = 0; i < GameConstant.MERGULHADOR_QUANTIDADE; i++) {
				var un = Instantiate (mergulhadorPrefab);
				un.SetActive (false);
				un.transform.parent = mergulhadorContainer;
				mergulhador.Add (un.GetComponent<Units> ());
			}
		}

		private void addPoseidon (){
			for (var i = 0; i < GameConstant.POSEIDON_QUANTIDADE; i++) {
				var un = Instantiate (poseidonPrefab);
				un.SetActive (false);
				un.transform.parent = poseidonContainer;
				poseidon.Add (un.GetComponent<Units> ());
			}
		}


		public Units spawnRastelo (){

			Units un = rastelo [rasteloIndex];
			if (un.isActive ()) {
				for (var i = 0; i < rastelo.Count; i++) {
					un = rastelo [i];
					if (!un.isActive ()) {
						rasteloIndex = (rasteloIndex + 1) % rastelo.Count;
						return un;
					}
				}
				Debug.Log ("Rastelo insuficiente");
				return null;
			}
			rasteloIndex = (rasteloIndex + 1) % rastelo.Count;
			return un;
		}

		public Units spawnRede (){

			Units un = rede [redeIndex];
			if (un.isActive ()) {
				for (var i = 0; i < rede.Count; i++) {
					un = rede [i];
					if (!un.isActive ()) {
						redeIndex = (redeIndex + 1) % rede.Count;
						return un;
					}
				}
				Debug.Log ("Rede insuficiente");
				return null;
			}

			redeIndex = (redeIndex + 1) % rede.Count;
			return un;
		}

		public Units spawnAspirador (){
			Units un = aspirador [aspiradorIndex];
			if (un.isActive ()) {
				for (var i = 0; i < aspirador.Count; i++) {
					un = aspirador [i];
					if (!un.isActive ()) {
						aspiradorIndex = (aspiradorIndex + 1) % aspirador.Count;
						return un;
					}
				}
				Debug.Log ("Aspirador insuficiente");
				return null;
			}

			aspiradorIndex = (aspiradorIndex + 1) % aspirador.Count;
			return un;
		}

		public Units spawnMergulhador (){
			Units un = mergulhador [mergulhadorIndex];
			if (un.isActive ()) {
				for (var i = 0; i < mergulhador.Count; i++) {
					un = mergulhador [i];
					if (!un.isActive ()) {
						mergulhadorIndex = (mergulhadorIndex + 1) % mergulhador.Count;
						return un;
					}
				}
				Debug.Log ("Mergulhador insuficiente");
				return null;
			}

			mergulhadorIndex = (mergulhadorIndex + 1) % mergulhador.Count;
			return un;
		}

		public Units spawnPoseidon (){
			Units un = poseidon [poseidonIndex];
			if (un.isActive ()) {
				for (var i = 0; i < poseidon.Count; i++) {
					un = poseidon [i];
					if (!un.isActive ()) {
						poseidonIndex = (poseidonIndex + 1) % poseidon.Count;
						return un;
					}
				}
				Debug.Log ("Poseidon insuficiente");
				return null;
			}

			poseidonIndex = (poseidonIndex + 1) % poseidon.Count;
			return un;
		}
	}
}
