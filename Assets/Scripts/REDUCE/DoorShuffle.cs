using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorShuffle : MonoBehaviour {

	[SerializeField] private Image leftDoor, middleDoor, rightDoor, lBlink, mBlink, rBlink;
	private int leftPos, middlePos, rightPos, randSelect, doorSelect;

	public static DoorShuffle instance;

	// Start is called before the first frame update
	void Start() {
		leftPos = -1;
		middlePos = 0;
		rightPos = 1;
		instance = this;
	}

	public void shuffle() {
		StartCoroutine("shuffleCoroutine");
	}

	private IEnumerator shuffleCoroutine() {
		for(int i = 0; i < 10; i++) {

			doorSelect = Random.Range(-1,2);
			if(leftPos == doorSelect) {
				int tmp = middlePos;
				middlePos = rightPos;
				rightPos = tmp;
			} else if(middlePos == doorSelect) {
				int tmp = leftPos;
				leftPos = rightPos;
				rightPos = tmp;
			} else if(rightPos == doorSelect) {
				int tmp = middlePos;
				middlePos = leftPos;
				leftPos = tmp;
			}

			leftDoor.gameObject.GetComponent<DoorMovement>().makeTransition(leftPos);
			middleDoor.gameObject.GetComponent<DoorMovement>().makeTransition(middlePos);
			rightDoor.gameObject.GetComponent<DoorMovement>().makeTransition(rightPos);

			yield return new WaitForSeconds(0.15f);
		}
	}

	public void blink(int index) {
		switch(index) {
			case 0:
				StartCoroutine(blinkRepeat(lBlink));
				break;
			case 1:
				StartCoroutine(blinkRepeat(mBlink));
				break;
			case 2:
				StartCoroutine(blinkRepeat(rBlink));
				break;
		}
	}

	private IEnumerator blinkRepeat(Image blinkImg) {
		blinkImg.gameObject.SetActive(true);
		for(int i = 0; i < 2; i++) {
			blinkImg.canvasRenderer.SetAlpha(0);
			blinkImg.CrossFadeAlpha(1,0.75f,false);
			yield return new WaitForSeconds(0.75f);
			blinkImg.canvasRenderer.SetAlpha(1);
			blinkImg.CrossFadeAlpha(0,0.75f,false);
			yield return new WaitForSeconds(0.75f);
		}
		blinkImg.gameObject.SetActive(false);
	}

}



