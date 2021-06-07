using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USOsocialNet : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

	public void openFacebook() {
		Application.OpenURL("https://www.facebook.com/usointeligenteASV.AC/");
	}
	
	public void openTwitter() {
		Application.OpenURL("https://twitter.com/usonouso");
	}
	
	public void openWebsite() {
		Application.OpenURL("http://www.usomx.com/");
	}

}
