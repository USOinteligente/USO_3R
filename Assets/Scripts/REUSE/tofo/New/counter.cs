using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counter : MonoBehaviour
{
    // Start is called before the first frame update
    
    Text text;
        void Start()
    {
        
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameLogic2.reuseScore.ToString();
        
    }
}
