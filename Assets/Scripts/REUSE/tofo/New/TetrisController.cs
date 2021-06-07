using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TetrisController : MonoBehaviour
{
    //public GameObject rig;
    float timer = 0f; 
    //GameLogic2 gameLogic;
    public string tage;
    bool move = true;
    public GameObject rig;
    GameLogic2 gameLogic2;
    
    // Start is called before the first frame update
    void Start()
    {
        gameLogic2 = FindObjectOfType<GameLogic2>();
    }
    void RegisterBlock()
    {
        foreach(Transform subBlock in rig.transform)
        {
            gameLogic2.grid[Mathf.FloorToInt(subBlock.position.x),Mathf.FloorToInt(subBlock.position.y)]=subBlock;
            
        }
    } 
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == gameObject.tag)
        {
            Destroy(other);
            Destroy(gameObject);
        }
    }
    void equal()
    {
        foreach(Transform subBlock in rig.transform)
        {
            if(subBlock.tag == tage)
            {
                Destroy(gameObject);
            }
        }
    }

    bool CheckValid()
    {
        foreach(Transform subBlock in rig.transform)
        {
            
            if(subBlock.transform.position.x >=GameLogic2.width ||
            subBlock.transform.position.x <0 ||
            subBlock.transform.position.y <0)
            {
                return false;
            }
            if(subBlock.position.y < GameLogic2.height && gameLogic2.grid[Mathf.FloorToInt(subBlock.position.x),Mathf.FloorToInt(subBlock.position.y)] != null)
            {
                return false;

            }
        }

        return true;
    }


    // Update is called once per frame
    void Update()
    {
        if (move)
        {

            timer += 1 * Time.deltaTime;

            if (Input.GetKey(KeyCode.DownArrow) && timer > GameLogic2.quickDropTime)
            {
                gameObject.transform.position -= new Vector3(0,1,0);
                timer = 0;
                if (!CheckValid())
                {
                    move = false;
                    gameObject.transform.position += new Vector3(0,1,0);
                    RegisterBlock();
                    //equal();
                    //Destroy(gameObject);
                    //gameLogic2.SpawnBlock();
                }
            } 
            else if (timer > GameLogic2.dropTime)
            {
                gameObject.transform.position -= new Vector3(0,1,0);
                timer = 0;
                if (!CheckValid())
                {
                    move = false;
                    gameObject.transform.position += new Vector3(0,1,0);
                    RegisterBlock();
                    //equal();
                    //Destroy(gameObject);
                    //gameLogic2.SpawnBlock();
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                gameObject.transform.position -= new Vector3(1,0,0);
                if (!CheckValid())
                {
                    //move = false;
                    gameObject.transform.position += new Vector3(1,0,0);
                }
            } 
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                gameObject.transform.position += new Vector3(1,0,0);
                if (!CheckValid())
                {
                    //move = false;
                    gameObject.transform.position -= new Vector3(1,0,0);
                }
            }

        }

    }

    
}
