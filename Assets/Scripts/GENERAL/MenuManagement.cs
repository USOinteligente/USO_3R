using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagement : MonoBehaviour {

	[SerializeField] private Image background, creditsPanel;
	[SerializeField] private Sprite goodBack, badBack;
	private bool creditsActive;

	// Start is called before the first frame update
	void Start() {
		PlayerPrefs.SetInt("toxLev", (int) Random.Range(5,11)); 
		creditsActive = false;
		StartCoroutine("AnimateBackground");
	}

	// Update is called once per frame
	void Update() {

	}

	// Method to go to level selection
	public void gotoLevSelect() { 
		if(PlayerPrefs.GetInt("NotFirstTime")!=1) {
			PlayerPrefs.SetInt("NotFirstTime", 1);
			SceneManager.LoadScene("Story");
		} else {
			SceneManager.LoadScene("LevelSelection"); 
		}
	}

	private IEnumerator AnimateBackground() {
		while(true) {
			background.GetComponent<Image>().sprite = goodBack;
			background.canvasRenderer.SetAlpha(0);		
			background.CrossFadeAlpha(1, 0.5f, false);
			yield return new WaitForSeconds(2.5f);

			background.canvasRenderer.SetAlpha(1);		
			background.CrossFadeAlpha(0, 0.5f, false);
			yield return new WaitForSeconds(0.5f);

			background.GetComponent<Image>().sprite = badBack;
			background.canvasRenderer.SetAlpha(0);		
			background.CrossFadeAlpha(1, 0.5f, false);
			yield return new WaitForSeconds(2.5f);

			background.canvasRenderer.SetAlpha(1);		
			background.CrossFadeAlpha(0, 0.5f, false);
			yield return new WaitForSeconds(0.5f);
		}
	}

	public void displayCredits() {
		creditsActive = !creditsActive;
		creditsPanel.gameObject.SetActive(creditsActive);
	}

	public void displayStory() {
		PlayerPrefs.SetInt("NotFirstTime", 1);
		SceneManager.LoadScene("Story");
	}
}












