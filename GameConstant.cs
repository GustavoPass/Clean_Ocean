using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cleanOcean{
	public class GameConstant : MonoBehaviour{

		public const int RASTELO_QUANTIDADE = 5;
		public const int REDE_QUANTIDADE = 5;
		public const int ASPIRADOR_QUANTIDADE = 5;
		public const int MERGULHADOR_QUANTIDADE = 5;
		public const int POSEIDON_QUANTIDADE = 1;

		public const int CHICLETE_QUANTIDADE = 15;
		public const int CERVEJA_QUANTIDADE = 15;
		public const int CIGARRO_QUANTIDADE = 15;
		public const int COCO_QUANTIDADE = 15;
		public const int GARRAFA_QUANTIDADE = 15;
		public const int VIDRO_QUANTIDADE = 15;

		public const string LIXO_TAG = "Lixo";
		public const string MAR_TAG = "Mar";
		public const string FIM_DA_LINHA_TAG = "Final";
		public const string PODER_POSEIDON_TAG = "PoderPoseidon";

		public const string RASTELO_INFORMATION = "Unidade mais simples usada pelos voluntários, só pode ser usada na areia. Pode limpar 2 lixos comuns ou 1 Lixo monstro.";
		public const string REDE_INFORMATION = "Unidade para remoção rápida de lixo no Inside, um pouco mais avançada do que  o rastelo. Pode limpar 2 lixos monstros.";
		public const string ASPIRADOR_INFORMATION = "Unidade para sucção de lixo, utilizada no Inside e possui uma duração prolongada.";
		public const string MERGULHADOR_INFORMATION = "Mergulhador especialista que atua somente o Outside. Pode limpar 2 lixos monstros.";
		public const string TRIDENTE_INFORMATION = "Ó Grande Poseidon, maior defensor dos mares e oceanos. Pode atuar em qualquer local limpando vários lixos.";

		public const int COOLDOWN_TIME_CARD = 2;

		public const float TILE_SIZE = 1.185f;

		public static int GAME_VOLUME = 1;

		public static bool tutorial = true;


	}
}
