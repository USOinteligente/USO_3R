using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserBehaviour : MonoBehaviour {

	// Start is called before the first frame update
	void Start() {
		float boxWidth = (float) gameObject.GetComponent<RectTransform>().rect.width;
		float boxHeight = (float) gameObject.GetComponent<RectTransform>().rect.height;
		gameObject.GetComponent<BoxCollider2D>().size = new Vector2(boxWidth, boxHeight);
	}
}
