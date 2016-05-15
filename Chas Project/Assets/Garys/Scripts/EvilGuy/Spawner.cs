using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    //Used to spawn evil doers at either side of the screen


    public float min_spawn_rate = 1;
    public float max_spawn_rate = 5;
    private float next_spawn = 0.0f;
    private float spawn_rate;


    private int count = 0;

    public GameObject other_spawner;

    //villain objects and controllers
    public GameObject villain_prefab;
    private GameObject new_villain;

    private EvilGuyStruct main_villain_ = new EvilGuyStruct();
    private List<EvilGuyStruct> villain_array = new List<EvilGuyStruct>();

    // Use this for initialization
    void Start()
    {
        BuildVillainList();
    }

    // Update is called once per frame
    void Update()
    {
        TestVillainCreationWithSimilarities();

    }

    void FixedUpdate()
    {
      
        //if ((Time.time > next_spawn))
        //{
        //    spawn_rate = Random.Range(min_spawn_rate, max_spawn_rate);
        //    next_spawn = Time.time + spawn_rate;
        //    createEnemy();
        //}

        

    }

    void BuildVillainList()
    {
        EvilGuyStruct temp = new EvilGuyStruct();
        bool do_once = true;
        for (int i = 0; i < GameController.total_amount_of_villains; i++)
        {
            if (do_once == true)
            {
                temp.RandomiseVillain(true);
                do_once = false;
            }
            else
            {
                temp.RandomiseVillain();
            }
            villain_array.Add(temp);
        }


        main_villain_.RandomiseVillain(true);
    }

    void createEnemy()
    {
        GameObject villain = null;
        Instantiate(villain, transform.position, Quaternion.identity);
    }



    private void TestVillainCreation() //Selected from a list of villains
    {
        if (Input.GetMouseButtonDown(0))
        {
            //RandomiseVillain(ref main_villain_);
            int temp = Random.Range(0, GameController.total_amount_of_villains);
            new_villain = (GameObject)Instantiate(villain_prefab, transform.position, Quaternion.identity);
            EvilGuyRender script = new_villain.GetComponent<EvilGuyRender>();
            script.Init(villain_array[temp], EvilGuyRender.Direction.LEFT, 5, EvilGuyRender.Anim.WALK);


        }
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(new_villain);


        }
    }

    private void TestVillainCreationWithSimilarities() //creates villains/checks if they are too similar
    {
        if (Input.GetMouseButtonDown(0))
        {
            //RandomiseVillain(ref main_villain_);
            // int temp = Random.Range(0, total_amount_of_villains);
            //if the rng is == 0 
            //select the main villain
            if (count % 2 == 0)
            {
                new_villain = (GameObject)Instantiate(villain_prefab, transform.position, Quaternion.identity);
                EvilGuyRender script = new_villain.GetComponent<EvilGuyRender>();
                script.Init(main_villain_, EvilGuyRender.Direction.LEFT, 5, EvilGuyRender.Anim.WALK);
            }
            else
            {
                GenerateVillainSimilarity();
            }

            count++;

        }
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(new_villain);


        }
    }

    private EvilGuyStruct GenerateVillainSimilarity()
    {
        EvilGuyStruct temp_guy = new EvilGuyStruct();

        do
        {
            temp_guy.RandomiseVillain();

        } while (temp_guy.HowSimilar(main_villain_) != Similarity.NONE); //chnage similarity here
        new_villain = (GameObject)Instantiate(villain_prefab, transform.position, Quaternion.identity);
        EvilGuyRender script = new_villain.GetComponent<EvilGuyRender>();
        script.Init(temp_guy, EvilGuyRender.Direction.RIGHT, 10, EvilGuyRender.Anim.WALK);
        script.SetStartingPosition(other_spawner.transform.position);

        return temp_guy;
    }
}
