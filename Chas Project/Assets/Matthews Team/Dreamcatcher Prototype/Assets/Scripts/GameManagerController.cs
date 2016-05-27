using UnityEngine;
using System.Collections;

public class GameManagerController : MonoBehaviour {

    public static int bubbleNo; //number of bubbles on screen
    public static float growthRate;

    public GameObject goodBubble; 
    public GameObject badBubble; 

    private GameObject bubble; //bubble becomes either good or bad

    private int chanceGood; //percentage chance the next bubble will be good (may use this to change chance later on?)
    private bool isMaxSpawn; //is there the max number of bubbles on screen?
    //private int maxSpawnInt; //max number of bubbles

    private float minY = -2.75f; //coordinate ranges for where the bubble can be within
    private float minX = -2.75f; //spawn new bubbles at minY and between min and max Xs
    private float maxX = 2.75f;

    private float time; //used to calculate random spawn time between min and max times
    private float spawnTime;
    private float minTime;
    private float maxTime;


    // Use this for initialization
    void Start()
    {
        //initialisation
        isMaxSpawn = false; //spawn stuff
        //maxSpawnInt = 4;
        chanceGood = 50;

        bubbleNo = 0;

        minTime = 2f; //time stuff
        maxTime = 4f;

        time = minTime;
        SetRandomTime(); //set random spawn time for first bubble

        ChooseNextBubble(); //choose first bubble

        growthRate = 0.30f;
        SpawnBubble();
        //InvokeRepeating("IncreaseDifficulty", 2f, 2f); //increase growth rate and reduce spawn time every 2secs // could be made public var
        //InvokeRepeating("IncreaseMaxSpawn", 15f, 15f); //increase max number of bubbles every 15 seconds //could be made public var
        //InvokeRepeating("IncreaseGrowthRate", 1 / 60, 1 / 60);
        InvokeRepeating("SpawnBubble", 2f, 2f);
    }

    void IncreaseGrowthRate()
    {
        growthRate = growthRate + Time.deltaTime * 4;
    }

    void ChooseNextBubble()
    {
        int choice = Random.Range(0, 100); //random int between 0 and 100 (less than 100)

        if (choice < chanceGood) //if 0-49 (half the possible numbers and therefore 50% chance)
        { bubble = goodBubble; } //bubble either becomes good or bad
        else
        { bubble = badBubble; }

        /*if (bubbleNo < maxSpawnInt) //determines whether we are at the spawn limit or not
        {
            isMaxSpawn = false;
        }
        else
        {
            isMaxSpawn = true;
        }*/
    }

    Vector2 SetSpawnPoint()
    {
        float spawnX = Random.Range(minX, maxX); //random position between min and max x
        float yOffset = Random.Range(-0.25f, 0.25f); //to slightly vary the y position
        Vector2 spawnPoint = new Vector2(spawnX, minY + yOffset); //spawn at random point

        return spawnPoint;
    }

    void SpawnBubble()
    {
        //time = 0; //reset time

        ChooseNextBubble(); //next bubble chosen

        if (isMaxSpawn == false) //if spawning is possible
        {
            Instantiate(bubble, SetSpawnPoint(), Quaternion.identity); //spawn bubble at point

            bubbleNo++; //increase numbers
        }
    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime); //chooses random time
    }

    void IncreaseDifficulty() //placeholder
    {
        /*float reduxVal = 0.1f;
        growthRate = growthRate + 0.025f; //placeholder code
        if (minTime < reduxVal) //placeholder code
        {
            minTime = reduxVal; //reduxVal becomes the minimum time possible, no more subtraction
        }
        else
        {
            minTime = minTime - reduxVal;
        }
        if (maxTime < reduxVal * 2) //placeholder code
        {
            maxTime = reduxVal * 2;
        }
        else
        {
            maxTime = maxTime - reduxVal;
        }*/
    }

    /*void IncreaseMaxSpawn()
    {
        maxSpawnInt = maxSpawnInt + 1; //increase max spawn number
    }*/

    // Update is called once per frame
    void FixedUpdate ()
    {
        /*
        //Counts up
        time += Time.deltaTime; //this is necessary, trust me

        //Check if its the right time to spawn the object
        if (time >= spawnTime) //if spawning is possible
        {
            SpawnBubble(); 
            SetRandomTime(); //set new random time
        }*/
        Time.timeScale += 0.0005f;
        // 317 frames before first pop
    }

}
