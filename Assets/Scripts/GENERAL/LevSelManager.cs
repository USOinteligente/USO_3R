using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevSelManager : MonoBehaviour {

	[SerializeField] private Text curiousText;

	// Start is called before the first frame update
	void Start() {
		dataList.loadCollection();
		StartCoroutine("curiousDataSelect");		
	}

	// Update is called once per frame
	void Update() {

	}

	public void gotoReduce() {
		SceneManager.LoadScene("Reduce");
	}
	public void gotoReuse() {
		SceneManager.LoadScene("Reuse");
	}
	public void gotoRecycle() {
		SceneManager.LoadScene("Recycle");
	}
	public void gotoMainMenu() {
		SceneManager.LoadScene("MainMenu");
	}

	private IEnumerator curiousDataSelect() {
		while(true) {
			int index = (int) Random.Range(0,27);
			curiousText.text = dataList.dataCollection[index];
			yield return new WaitForSeconds(5);
		}
	}
}




















