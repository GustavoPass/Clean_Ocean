using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cleanOcean{
	public class LixoManager : MonoBehaviour{
		private MonsterPooling enemyPool;
		public interfaceController vida;

		private bool[,] lixoVerificar;
		private int posX, posY;

		private WaitForSeconds tempo1;
		private WaitForSeconds tempo2;

		private Vector2 setPos;

		private void Awake (){

			enemyPool = GetComponent<MonsterPooling> ();
			tempo1 = new WaitForSeconds (1);
			tempo2 = new WaitForSeconds (5);

			lixoVerificar = new bool[4,7];

		}

		private void setMonsterOnGame (){

			posX = randomTileWidth ();
			posY = randomTileHeight ();

			if (lixoVerificar [posX, posY]) {
				return;
			}

			setPos.x = posX  * GameConstant.TILE_SIZE;
			setPos.y = posY * GameConstant.TILE_SIZE;

			switch (randomMonster ()) {

			case 0:
				enemyPool.spawnChiclete ().setMonsterPosition (setPos, posX, posY);
				break;
			case 1:
				enemyPool.spawnCerveja ().setMonsterPosition (setPos, posX, posY);
				break;
			case 2:
				enemyPool.spawnCigarro ().setMonsterPosition (setPos, posX, posY);
				break;
			case 3:
				enemyPool.spawnCoco ().setMonsterPosition (setPos, posX, posY);
				break;
			case 4:
				enemyPool.spawnGarrafa ().setMonsterPosition (setPos, posX, posY);
				break;
			case 5:
				enemyPool.spawnVidro ().setMonsterPosition (setPos, posX, posY);
				break;
			}
			vidaControl (-1);
			lixoVerificar [posX, posY] = true;
		}

		private int randomMonster (){
			return Random.Range (0, 6);
		}

		private int randomTileHeight (){
			return Random.Range (0, 7);
		}

		private int randomTileWidth (){
			//return Random.Range (0, 4);
			return 0;
		}

		public void clearTrashInTile(int px, int py, int gotas, bool cleaned){
			lixoVerificar [px, py] = false;
			if (cleaned) {
				vida.gotasControl (gotas);
				vida.pontuacao += gotas;
			}
		}

		public void vidaControl(int value){
			vida.life += value;
		}
			

		public IEnumerator comecaWave(){
			yield return tempo1;
			StartCoroutine (spawnMonster ());
		}

		public IEnumerator spawnMonster(){
			yield return tempo2;
			setMonsterOnGame ();
			StartCoroutine (spawnMonster ());
		}
	}
}