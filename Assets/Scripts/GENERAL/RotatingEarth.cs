using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatingEarth : MonoBehaviour {

	[SerializeField] private Sprite[] imageSet = new Sprite[10];
	[SerializeField] private Sprite[] toxicSet = new Sprite[10];

	// Start is called before the first frame update
	void Start() {
		StartCoroutine("rotate");
	}

	private IEnumerator rotate() {
		while(true) {
			for(int i = 0; i < 10; i++) {
				GetComponent<Image>().sprite = (ToxicBarUpdate.toxicLevel <= 5) ? imageSet[i] : toxicSet[i];
				yield return new WaitForSeconds(0.25f);
			}
		}
	}
}
