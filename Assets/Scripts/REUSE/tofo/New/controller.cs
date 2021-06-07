using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public Rigidbody2D rb;
    //private bool moving = false;
    
    //public static bool spawnPermit = true;

    // Update is called once per frame
    private Vector2 startTouchPosition,endTouchPosition;
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if(Input.touchCount >0 && Input.GetTouch(0).phase==TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            if((endTouchPosition.x<startTouchPosition.x))
            {
                //transform.position=new Vector2(transform.position.x - 1.75f,transform.position.y);
                
                rb.velocity = new Vector2(-2.0f,-1f);
            }
            if((endTouchPosition.x > startTouchPosition.x))
            {
                //transform.position = new Vector2(transform.position.x +1.75f,transform.position.y);
                
                rb.velocity = new Vector2(2.0f, -1f);
            }
           // if((endTouchPosition.y < startTouchPosition.y))
           // {
           //     rb.velocity += new Vector2(0f,-9.0f);
           // }
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!(other.tag=="Wall"))
        {
            StartCoroutine(checkSpawn());
            
        }
        
        if(other.tag == this.tag && !(other.tag =="Respawn"))
        {
            GameLogic2.reuseScore += 100;
            GameLogic2.SpawnPermit = true;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            
        }
    }
    public IEnumerator checkSpawn()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("Congele este y aparecere uno nuevo");
        yield return new WaitForSeconds(1);
        GameLogic2.SpawnPermit = true;
        
    }
    
    


}
