using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashBehaviour : MonoBehaviour {

	[SerializeField] private Sprite[] organicImgs = new Sprite[6];
	[SerializeField] private Sprite[] inorganicImgs = new Sprite[6];
	[SerializeField] private Sprite[] specialImgs = new Sprite[6];

	private string thisTag, otherTag, otherTag_wrong1, otherTag_wrong2;

	// Start is called before the first frame update
	void Start() {
		switch((int) Random.Range(0f, 3f)) {
			case 0:
				thisTag = "Organic";
				otherTag_wrong1 = "InorganicLaser";
				otherTag_wrong2 = "SpecialLaser";
				GetComponent<Image>().sprite = organicImgs[(int) Random.Range(0f, 6f)];
				break;
			case 1:
				thisTag = "Inorganic";
				otherTag_wrong1 = "OrganicLaser";
				otherTag_wrong2 = "SpecialLaser";
				GetComponent<Image>().sprite = inorganicImgs[(int) Random.Range(0f, 6f)];
				break;
			case 2:
				thisTag = "Special";
				otherTag_wrong1 = "InorganicLaser";
				otherTag_wrong2 = "OrganicLaser";
				GetComponent<Image>().sprite = specialImgs[(int) Random.Range(0f, 6f)];
				break;
		}
		otherTag = thisTag+"Laser";
		gameObject.tag = thisTag;
		// Modifies both image size and box collider size
		gameObject.GetComponent<BoxCollider2D>().size = new Vector2((float) Screen.width*0.1f, (float) Screen.height*0.1f);
	}

	// Update is called once per frame
	void Update() {
		if(gameObject.transform.position.y <= -6f) {
			if(GameLogic.recycleScore > 0) GameLogic.recycleScore--;
			Destroy(gameObject);	
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(gameObject.CompareTag(thisTag) && other.gameObject.CompareTag(otherTag)) {
			Destroy(gameObject);
			GameLogic.recycleScore++;
		} else if(other.gameObject.CompareTag(otherTag_wrong1) || other.gameObject.CompareTag(otherTag_wrong2)) {
			GameLogic.defeat = true;
		}
	}
}





