using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public float timer = 3;
    bool reduce = false;
    bool inZone = false;
    bool objectToLose = false;
    public GameObject DeadScene, postProcessVol;
	[SerializeField] private Image defeatScreen;
    void Awake()
    {
        Time.timeScale = 1;
        reduce = false;
    }



    void OnTriggerEnter2D (Collider2D col){
    
        reduce = true;
        
    }

    void OnTriggerExit2D (Collider2D col){
        
            reduce = false;
            timer = 3;
            Debug.Log("Ya no estoy en la zona");
            inZone = false;
        
    }
    void OnTriggerStay2D(Collider2D col)
    {
        inZone=true;
        if(col.gameObject.GetComponent<Rigidbody2D>().velocity== new Vector2(0,0) )
        {
            objectToLose = true;
        }
    }
    
     // Update is called once per frame
    void Update () {

        if (reduce == true) {
            //Debug.Log (timer);
             timer -= 1 * Time.deltaTime;
        }

        if (timer <= 0) {
		DefeatScreenLogic.levelFinished = "Reuse";
		DefeatScreenLogic.postProcessToQuit = postProcessVol;
		defeatScreen.gameObject.SetActive(true);
            Debug.Log ("Perdiste");
//            DeadScene.SetActive(true);
            Time.timeScale = 0;
            reduce = false;
             //put teleport part here
        }
        if(inZone && objectToLose){
		DefeatScreenLogic.levelFinished = "Reuse";
		DefeatScreenLogic.postProcessToQuit = postProcessVol;
		defeatScreen.gameObject.SetActive(true);
            Debug.Log("estoy en la zona");
            Debug.Log ("Perdiste");
//            DeadScene.SetActive(true);
            Time.timeScale = 0;
            reduce = false;

        }
    }
}
