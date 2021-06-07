using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic2 : MonoBehaviour
{
    
    public static float dropTime = 0.9f;
    public static float quickDropTime = 0.05f;
    public static int width = 15, height = 30;
    public GameObject[] blocks;
    //public GameObject Prefab;
    public float respawnTime = 5.0f;
    
    private Vector2 screenBounds;
    public Transform[,] grid = new Transform[width,height];
    public static bool SpawnPermit = true;
	public static int reuseScore;

	void Start() {
		reuseScore = 0;	

	}


    // Use this for initialization
    void Awake () {
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //StartCoroutine(blockSpawn());
		reuseScore = 0;	
        SpawnPermit = true;
    }
    void Update()
    {
        if(SpawnPermit)
        {
            Debug.Log("Aparecere uno");
            //spawnEnemy();
            //SpawnPermit = false;
            StartCoroutine(blockSpawn());
        }
    }
    private void spawnEnemy(){
        float guess = Random.Range(0,1f);
        guess *= blocks.Length;

        //GameObject a = Instantiate(Prefab) as GameObject;
        //a.transform.position = new Vector2(transform.position.x, transform.position.y);
        Instantiate(blocks[Mathf.FloorToInt(guess)]);
    }
    public IEnumerator blockSpawn(){
        
            spawnEnemy();
            SpawnPermit = false;
            Debug.Log("no pueden aparecer mas");
            yield return 1;
            //new WaitForSeconds(1);
            //spawnEnemy();
            
    
    }

    
    
}
