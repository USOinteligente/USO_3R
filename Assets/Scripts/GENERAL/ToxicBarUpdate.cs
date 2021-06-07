using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToxicBarUpdate : MonoBehaviour {

	[SerializeField] private Image[] levelBars = new Image[10];
	public static int toxicLevel;

    // Start is called before the first frame update
    void Start() {
	if(PlayerPrefs.GetInt("toxLev") < 1) { PlayerPrefs.SetInt("toxLev", 1); }
	else if(PlayerPrefs.GetInt("toxLev") > 10) { PlayerPrefs.SetInt("toxLev", 10); }
	toxicLevel = PlayerPrefs.GetInt("toxLev");
    }

    // Update is called once per frame
    void Update() {
    	activeColorBars(toxicLevel);
    }
    
    void activeColorBars(int val) {
    	for(int i = 0; i < val; ++i) {
    		levelBars[i].gameObject.SetActive(true);
    	}
    	for(int j = val; j < 10; j++) {
    		levelBars[j].gameObject.SetActive(false);    	
    	}
    }
    
}
