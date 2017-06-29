using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

namespace cleanOcean{
	public class Carta : MonoBehaviour {

		private TapGesture tapGesture;
		private LongPressGesture longPress;
		private ReleaseGesture releaseGesture;
		public MenuCartas menuControl;
		public CardInformation cardInfo;

		private Transform trans;
		private SpriteRenderer cardImage;
		public bool selecionado;

		private Vector2 toPos;
		private Color ActiveColor;

		private string cardName;
		public byte cardNumber;
		public int custo;

		private void Awake () {
			tapGesture = GetComponent<TapGesture> ();
			longPress = GetComponent<LongPressGesture> ();
			releaseGesture = GetComponent<ReleaseGesture> ();

			trans = GetComponent<Transform> ();
			cardImage = GetComponent<SpriteRenderer> ();

			toPos = new Vector2 (trans.localPosition.x,trans.localPosition.y);
			ActiveColor = new Color (1, 1, 1);

			cardName = this.name;
		}

		private void OnEnable(){
			tapGesture.Tapped += selectCard;
			longPress.LongPressed += showCardInfo;
			releaseGesture.Released += hideCardInfo;

		}

		private void OnDisable(){
			tapGesture.Tapped -= selectCard;
			longPress.LongPressed -= showCardInfo;
			releaseGesture.Released -= hideCardInfo;
		}

		public void selectCard (object sender, System.EventArgs e){

			menuControl.cartaSelecionada = cardName;
			menuControl.custo = custo;
			menuControl.cardStatus ();
			selecionado = true;
			menuControl.playSound ();
			menuControl.closeMenu (false);

		}

		public void showCardInfo(object sender, System.EventArgs e){

			switch (cardNumber) {

			case 1:
				cardInfo.setImage (cardImage.sprite, cardName, GameConstant.RASTELO_INFORMATION);
				break;

			case 2:
				cardInfo.setImage (cardImage.sprite, cardName, GameConstant.REDE_INFORMATION);
				break;

			case 3:
				cardInfo.setImage (cardImage.sprite, cardName, GameConstant.ASPIRADOR_INFORMATION);
				break;

			case 4:
				cardInfo.setImage (cardImage.sprite, cardName, GameConstant.MERGULHADOR_INFORMATION);
				break;

			case 5:
				cardInfo.setImage (cardImage.sprite, cardName, GameConstant.TRIDENTE_INFORMATION);
				break;
			}
			cardInfo.setInfoVisible (true);
		}

		public void hideCardInfo(object sender, System.EventArgs e){
			cardInfo.setInfoVisible (false);
		}


		public void moveCard(float posY){
			toPos.y = posY;
			trans.localPosition = Vector2.MoveTowards (trans.localPosition, toPos, 15 * Time.deltaTime);
		}

		public void colorChange(float porcent){
			ActiveColor.r = porcent;
			ActiveColor.g = porcent;
			ActiveColor.b = porcent;
			cardImage.color = ActiveColor;
		}
	}
}
