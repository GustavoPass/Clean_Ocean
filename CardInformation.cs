using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace cleanOcean{
	public class CardInformation : MonoBehaviour {

		public GameObject cardInformation;

		public Image cardImage;
		public Text cardName;
		public Text cardInfo;

		public void setImage(Sprite cardIcon, string nameC, string info){
			//Mudar informações da carta
			cardImage.sprite = cardIcon;
			cardName.text = nameC;
			cardInfo.text = info;
		}

		public void setInfoVisible(bool ver){
			cardInformation.SetActive (ver);
		}
	}
}
