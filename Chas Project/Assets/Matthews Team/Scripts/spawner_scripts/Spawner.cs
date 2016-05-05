using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    [HideInInspector]
    public GameObject spawn_;


    //timers for dream spawing
    public float spawn_time_;
    public float min_time_;
    public float max_time_;

    //chances for spawning each  type of dream 
    public float good_dream_chance_;
    public float bad_dream_chance_;
    public float special_dream_chance_;

    //dreams arrys
    public GameObject[] good_dreams_;
    public GameObject[] bad_dreams_;
    public GameObject[] special_dreams_;

    // Use this for initialization
    void Start()
    {
        spawn_ = GameObject.FindGameObjectWithTag("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        if (UpdateMainTimer())
        {
            // generates a random chance 
            float chance_ = Random.Range(0.0f, 100.0f);
            //looks what type of object it needs to spawn
            if (chance_ <= good_dream_chance_)
            {
                SpawnGoodDream();
            }
            else if (chance_ <= bad_dream_chance_ + good_dream_chance_) 
            {
                SpawnBadDream();
            }
            else
            {
                SpawnSpecialDream();
            }
        }
    }

    private bool UpdateMainTimer()
    {
        //resets tiemr if it reaches 0 
        if (spawn_time_ <= 0.0f)
        {
            spawn_time_ = Random.Range(min_time_, max_time_);
            return true;
        }
        else
        {
            //updates timer
            spawn_time_ -= Time.deltaTime;
            return false;
        }
    }

    private void SpawnGoodDream()
    {
        //picks a random dream from teh array and spawns it
        int index = Random.Range(0, good_dreams_.Length);
        Instantiate(good_dreams_[index], spawn_.transform.position, spawn_.transform.rotation);
    }

    private void SpawnBadDream()
    {
        //picks a random dream from teh array and spawns it
        int index = Random.Range(0, bad_dreams_.Length);
        Instantiate(bad_dreams_[index], spawn_.transform.position, spawn_.transform.rotation);
    }

    private void SpawnSpecialDream()
    {
        //picks a random dream from teh array and spawns it
        int index = Random.Range(0, special_dreams_.Length);
        Instantiate(special_dreams_[index], spawn_.transform.position, spawn_.transform.rotation);
    }

}
