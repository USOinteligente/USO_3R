using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic_Reduce : MonoBehaviour {

	public static int reduceScore;

	private int index, resources, time;
	private bool chooseStage, clicked;
	private string[] doors = new string[3];

	[SerializeField] private Text scoreText, timeText;
	[SerializeField] private Image defeatScreen, indicatorPanel;
	[SerializeField] private Slider healthBarSlider;
	[SerializeField] private GameObject postProcessVol;

	// Start is called before the first frame update
	void Start() {
		// Resets necessary variables to the corresponding value
		chooseStage = false;
		clicked = false;
		time = 5;
		reduceScore = 0;
		resources = 1;
		doors[0] = "LeftDoor";
		doors[1] = "MiddleDoor";
		doors[2] = "RightDoor";
		StartCoroutine("timeControl");
	}

	// Update is called once per frame
	void Update() {
		healthBarSlider.value = resources;
		scoreText.text = "Puntaje:\n" + reduceScore;
		timeText.text = time.ToString();
		if(resources <= 0 || (chooseStage && time <= 0)) {
			DefeatScreenLogic.postProcessToQuit = postProcessVol;
			DefeatScreenLogic.levelFinished = "Reduce";
			defeatScreen.gameObject.SetActive(true);
		}
		if(clicked) {
			StopCoroutine("timeControl");
			time = 6;
			chooseStage = false;
			clicked = false;
			StartCoroutine("timeControl");
		}
	}

	public void validateClick(string doorTag) {
		if(chooseStage && !clicked) {
			if(doors[index] == doorTag) {
				reduceScore++;
				if(resources < 3) resources++;
				StartCoroutine(rightWrongIndicator(true));
			} else {
				resources--;
				StartCoroutine(rightWrongIndicator(false));
			}
			clicked = true;
		}
	}

	private IEnumerator timeControl() {
		while(true) {
			yield return new WaitForSeconds(0.2f);
			index = (int) Random.Range(0,3);
			DoorShuffle.instance.blink(index);
			for(int i = 0; i < 5; i++) {
				time--;
				yield return new WaitForSeconds(1);
			}
			DoorShuffle.instance.shuffle();
			time = 5;
			yield return new WaitForSeconds(2.5f);
			chooseStage = true;
			for(int i = 0; i < 5; i++) {
				time--;
				yield return new WaitForSeconds(1);
			}
		}
	}

	private IEnumerator rightWrongIndicator(bool right) {
		indicatorPanel.GetComponent<Image>().color = (right) ? Color.green : Color.red;
		indicatorPanel.gameObject.SetActive(true);
		indicatorPanel.canvasRenderer.SetAlpha(0.4f);
		yield return new WaitForSeconds(0.2f);
		indicatorPanel.gameObject.SetActive(false);
	}

}










