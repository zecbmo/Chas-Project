using UnityEngine;
using System.Collections;

public class spawnerScript : MonoBehaviour
{

    [HideInInspector]
    public GameObject spawn;

    //timers
    public float goodDreamTimer;
    public float badDreamTimer;
    public float specialDreamTimer;

    //timers for dream spawing
    private float timer1;
    private float timer2;
    private float timer3;

    //dreams arrys
    public GameObject[] goodDreams;
    public GameObject[] badDreams;
    public GameObject[] specialDreams;

    // Use this for initialization
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        //deals with timers and spawnign objects
        if (updateGoodDreamTimer())
        {
            spawnGoodDream();
            timer1 = goodDreamTimer;
        }
        else if (updateBadDreamTimer())
        {
            spawnBadDream();
            timer2 = badDreamTimer;
        }
        else if (updateSpecialDreamTimer())
        {
            spawnSpecialDream();
            timer3 = specialDreamTimer;
        }
    }

    private bool updateGoodDreamTimer()
    {
        //simple spawn timer
        timer1 = timer1 - Time.deltaTime;
        if (timer1 <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool updateBadDreamTimer()
    {
        //simple spawn timer
        timer2 = timer2 - Time.deltaTime;
        if (timer2 <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool updateSpecialDreamTimer()
    {
        //simple spawn timer
        timer3 = timer3 - Time.deltaTime;
        if (timer3 <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void spawnGoodDream()
    {
        //picks a random dream from teh array and spawns it
        int index = Random.Range(0, goodDreams.Length);
        Instantiate(goodDreams[index], spawn.transform.position, spawn.transform.rotation);
    }

    private void spawnBadDream()
    {
        //picks a random dream from teh array and spawns it
        int index = Random.Range(0, badDreams.Length);
        Instantiate(badDreams[index], spawn.transform.position, spawn.transform.rotation);
    }

    private void spawnSpecialDream()
    {
        //picks a random dream from teh array and spawns it
        int index = Random.Range(0, specialDreams.Length);
        Instantiate(specialDreams[index], spawn.transform.position, spawn.transform.rotation);
    }

}
