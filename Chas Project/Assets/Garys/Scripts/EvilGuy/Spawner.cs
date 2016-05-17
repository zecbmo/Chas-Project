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

    public Difficulty difficulty;

    private int show_villain_count = 0; //used to track if the main villain has not been on screen in a while

    [Header("EASY 0 Settings")]
    public float e0_num_anims_to_use = 0; //number of animations that can be selected from 0 = sneaking. 1 = walking and sneaking. 2 = run,walk and sneak 
    public float e0_speed_range = 3; // defines the range that speed can be set from the default minimum. if minimum is 2 and speed rannge is 5. max_speed will be 7. will used to set the speed range for each animation type
    public float e0_spawn_rate_min = 5;
    public float e0_spawn_rate_max = 7;
    public float e0_max_villains = 5;
    public float e0_show_villain_count_max = 6; //a counter will be used to keep track of when the last time the main villain was spawned. (means that if the main villain hasn't been spawned lately it will spawn him) - will have a random variance on the max so you can't just count to cheat
    public Similarity e0_sim_max = Similarity.NONE; //the maxium similarity that another character can be to the main villian
    public Similarity e0_sim_min = Similarity.NONE; //change this flag if you want a minium similarity to be set
    public bool e0_match_sim_max = false; //set to true if all characters must match the similarity chosen in sim_max

    [Header("EASY 1 Settings")]
    public float e1_num_anims_to_use = 0; //number of animations that can be selected from 0 = sneaking. 1 = walking and sneaking. 2 = run,walk and sneak 
    public float e1_speed_range = 3; // defines the range that speed can be set from the default minimum. if minimum is 2 and speed rannge is 5. max_speed will be 7. will used to set the speed range for each animation type
    public float e1_spawn_rate_min = 5;
    public float e1_spawn_rate_max = 7;
    public float e1_max_villains = 5;
    public float e1_show_villain_count_max = 6; //a counter will be used to keep track of when the last time the main villain was spawned. (means that if the main villain hasn't been spawned lately it will spawn him) - will have a random variance on the max so you can't just count to cheat
    public Similarity e1_sim_max = Similarity.NONE; //the maxium similarity that another character can be to the main villian
    public Similarity e1_sim_min = Similarity.NONE; //change this flag if you want a minium similarity to be set
    public bool e1_match_sim_max = false; //set to true if all characters must match the similarity chosen in sim_max

    [Header("MEDIUM 0 Settings")]
    public float m0_num_anims_to_use = 0; //number of animations that can be selected from 0 = sneaking. 1 = walking and sneaking. 2 = run,walk and sneak 
    public float m0_speed_range = 3; // defines the range that speed can be set from the default minimum. if minimum is 2 and speed rannge is 5. max_speed will be 7. will used to set the speed range for each animation type
    public float m0_spawn_rate_min = 5;
    public float m0_spawn_rate_max = 7;
    public float m0_max_villains = 5;
    public float m0_show_villain_count_max = 6; //a counter will be used to keep track of when the last time the main villain was spawned. (means that if the main villain hasn't been spawned lately it will spawn him) - will have a random variance on the max so you can't just count to cheat
    public Similarity m0_sim_max = Similarity.NONE; //the maxium similarity that another character can be to the main villian
    public Similarity m0_sim_min = Similarity.NONE; //change this flag if you want a minium similarity to be set
    public bool m0_match_sim_max = false; //set to true if all characters must match the similarity chosen in sim_max


    [Header("MEDIUM 1 Settings")]
    public float m1_num_anims_to_use = 0; //number of animations that can be selected from 0 = sneaking. 1 = walking and sneaking. 2 = run,walk and sneak 
    public float m1_speed_range = 3; // defines the range that speed can be set from the default minimum. if minimum is 2 and speed rannge is 5. max_speed will be 7. will used to set the speed range for each animation type
    public float m1_spawn_rate_min = 5;
    public float m1_spawn_rate_max = 7;
    public float m1_max_villains = 5;
    public float m1_show_villain_count_max = 6; //a counter will be used to keep track of when the last time the main villain was spawned. (means that if the main villain hasn't been spawned lately it will spawn him) - will have a random variance on the max so you can't just count to cheat
    public Similarity m1_sim_max = Similarity.NONE; //the maxium similarity that another character can be to the main villian
    public Similarity m1_sim_min = Similarity.NONE; //change this flag if you want a minium similarity to be set
    public bool m1_match_sim_max = false; //set to true if all characters must match the similarity chosen in sim_max

    [Header("HARD 0 Settings")]
    public float h0_num_anims_to_use = 0; //number of animations that can be selected from 0 = sneaking. 1 = walking and sneaking. 2 = run,walk and sneak 
    public float h0_speed_range = 3; // defines the range that speed can be set from the default minimum. if minimum is 2 and speed rannge is 5. max_speed will be 7. will used to set the speed range for each animation type
    public float h0_spawn_rate_min = 5;
    public float h0_spawn_rate_max = 7;
    public float h0_max_villains = 5;
    public float h0_show_villain_count_max = 6; //a counter will be used to keep track of when the last time the main villain was spawned. (means that if the main villain hasn't been spawned lately it will spawn him) - will have a random variance on the max so you can't just count to cheat
    public Similarity h0_sim_max = Similarity.NONE; //the maxium similarity that another character can be to the main villian
    public Similarity h0_sim_min = Similarity.NONE; //change this flag if you want a minium similarity to be set
    public bool h0_match_sim_max = false; //set to true if all characters must match the similarity chosen in sim_max

    [Header("HARD 1 Settings")]
    public float h1_num_anims_to_use = 0; //number of animations that can be selected from 0 = sneaking. 1 = walking and sneaking. 2 = run,walk and sneak 
    public float h1_speed_range = 3; // defines the range that speed can be set from the default minimum. if minimum is 2 and speed rannge is 5. max_speed will be 7. will used to set the speed range for each animation type
    public float h1_spawn_rate_min = 5;
    public float h1_spawn_rate_max = 7;
    public float h1_max_villains = 5;
    public float h1_show_villain_count_max = 6; //a counter will be used to keep track of when the last time the main villain was spawned. (means that if the main villain hasn't been spawned lately it will spawn him) - will have a random variance on the max so you can't just count to cheat
    public Similarity h1_sim_max = Similarity.NONE; //the maxium similarity that another character can be to the main villian
    public Similarity h1_sim_min = Similarity.NONE; //change this flag if you want a minium similarity to be set
    public bool h1_match_sim_max = false; //set to true if all characters must match the similarity chosen in sim_max

    [Header("NIGHTMARE 0 Settings")]
    public float n0_num_anims_to_use = 0; //number of animations that can be selected from 0 = sneaking. 1 = walking and sneaking. 2 = run,walk and sneak 
    public float n0_speed_range = 3; // defines the range that speed can be set from the default minimum. if minimum is 2 and speed rannge is 5. max_speed will be 7. will used to set the speed range for each animation type
    public float n0_spawn_rate_min = 5;
    public float n0_spawn_rate_max = 7;
    public float n0_max_villains = 5;
    public float n0_show_villain_count_max = 6; //a counter will be used to keep track of when the last time the main villain was spawned. (means that if the main villain hasn't been spawned lately it will spawn him) - will have a random variance on the max so you can't just count to cheat
    public Similarity n0_sim_max = Similarity.NONE; //the maxium similarity that another character can be to the main villian
    public Similarity n0_sim_min = Similarity.NONE; //change this flag if you want a minium similarity to be set
    public bool n0_match_sim_max = false; //set to true if all characters must match the similarity chosen in sim_max

    [Header("NIGHTMARE 1 Settings")]
    public float n1_num_anims_to_use = 0; //number of animations that can be selected from 0 = sneaking. 1 = walking and sneaking. 2 = run,walk and sneak 
    public float n1_speed_range = 3; // defines the range that speed can be set from the default minimum. if minimum is 2 and speed rannge is 5. max_speed will be 7. will used to set the speed range for each animation type
    public float n1_spawn_rate_min = 5;
    public float n1_spawn_rate_max = 7;
    public float n1_max_villains = 5;
    public float n1_show_villain_count_max = 6; //a counter will be used to keep track of when the last time the main villain was spawned. (means that if the main villain hasn't been spawned lately it will spawn him) - will have a random variance on the max so you can't just count to cheat
    public Similarity n1_sim_max = Similarity.NONE; //the maxium similarity that another character can be to the main villian
    public Similarity n1_sim_min = Similarity.NONE; //change this flag if you want a minium similarity to be set
    public bool n1_match_sim_max = false; //set to true if all characters must match the similarity chosen in sim_max

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
        SpawnerSetByDifficulty(difficulty);
        

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

    private EvilGuyStruct GenerateVillainStructSimilarity(Similarity sim)
    {
        EvilGuyStruct temp_guy = new EvilGuyStruct();

        do
        {
            temp_guy.RandomiseVillain();

        } while (temp_guy.HowSimilar(main_villain_) != sim); //chnage similarity here
        return temp_guy;
    }

    public void SpawnerSetByDifficulty(Difficulty dif)
    {
        switch (dif)
        {
            case Difficulty.EASY_0:
                SpawnVillain(e0_num_anims_to_use, e0_speed_range, e0_spawn_rate_min, e0_spawn_rate_max, e0_max_villains, e0_show_villain_count_max, e0_sim_max, e0_sim_min, e0_match_sim_max);
                break;
            case Difficulty.EASY_1:
                SpawnVillain(e1_num_anims_to_use, e1_speed_range, e1_spawn_rate_min, e1_spawn_rate_max, e1_max_villains, e1_show_villain_count_max, e1_sim_max, e1_sim_min, e1_match_sim_max);
                break;
            case Difficulty.MEDIUM_0:
                SpawnVillain(m0_num_anims_to_use, m0_speed_range, m0_spawn_rate_min, m0_spawn_rate_max, m0_max_villains, m0_show_villain_count_max, m0_sim_max, m0_sim_min, m0_match_sim_max);
                break;
            case Difficulty.MEDIUM_1:
                SpawnVillain(m1_num_anims_to_use, m1_speed_range, m1_spawn_rate_min, m1_spawn_rate_max, m1_max_villains, m1_show_villain_count_max, m1_sim_max, m1_sim_min, m1_match_sim_max);
                break;
            case Difficulty.HARD_0:
                SpawnVillain(h0_num_anims_to_use, h0_speed_range, h0_spawn_rate_min, h0_spawn_rate_max, h0_max_villains, h0_show_villain_count_max, h0_sim_max, h0_sim_min, h0_match_sim_max);
                break;
            case Difficulty.HARD_1:
                SpawnVillain(h1_num_anims_to_use, h1_speed_range, h1_spawn_rate_min, h1_spawn_rate_max, h1_max_villains, h1_show_villain_count_max, h1_sim_max, h1_sim_min, h1_match_sim_max);
                break;       
            case Difficulty.NIGHTMARE_0:
                SpawnVillain(n0_num_anims_to_use, n0_speed_range, n0_spawn_rate_min, n0_spawn_rate_max, n0_max_villains, n0_show_villain_count_max, n0_sim_max, n0_sim_min, n0_match_sim_max);
                break;
            case Difficulty.NIGHTMARE_1:
                SpawnVillain(n1_num_anims_to_use, n1_speed_range, n1_spawn_rate_min, n1_spawn_rate_max, n1_max_villains, n1_show_villain_count_max, n1_sim_max, n1_sim_min, n1_match_sim_max);
                break;
         
        }
    }

    private void SpawnVillain(
            float num_anims_to_use, //number of animations that can be selected from 0 = sneaking. 1 = walking and sneaking. 2 = run,walk and sneak 
            float speed_range, // defines the range that speed can be set from the default minimum. if minimum is 2 and speed rannge is 5. max_speed will be 7. will used to set the speed range for each animation type
            float spawn_rate_min,
            float spawn_rate_max,
            float max_villains,
            float show_villain_count_max, //a counter will be used to keep track of when the last time the main villain was spawned. (means that if the main villain hasn't been spawned lately it will spawn him) - will have a random variance on the max so you can't just count to cheat
            Similarity sim_max, //the maxium similarity that another character can be to the main villian
            Similarity sim_min = Similarity.NONE, //change this flag if you want a minium similarity to be set
            bool match_sim = false) //set to true if all characters must match the similarity chosen in sim_max
    {
        if ((Time.time > next_spawn))
        {
            spawn_rate = Random.Range(spawn_rate_min, spawn_rate_max);
            next_spawn = Time.time + spawn_rate;
           


            //set the similar variables first ...walking/speed
            EvilGuyRender.Anim anim_to_use = (EvilGuyRender.Anim)Random.Range(0, num_anims_to_use);
            EvilGuyStruct evil_guy_data = new EvilGuyStruct();

            //set similarities
            Similarity selected_sim;
            if (match_sim == true)
            {
                selected_sim = sim_max;
            }
            else
            {
                selected_sim = (Similarity)Random.Range((int)sim_min, (int)sim_max+1);
            }



            //update show villain count and choose villain to be spawned
            int villain_to_spawn = 0; //select main villain if the count is lest than the max + a random value then spawn the main villain
            int count_max = (int)Random.Range(show_villain_count_max, show_villain_count_max + 10);

            if (show_villain_count < count_max)
            {
                //pick a random villain if the count is less than the max count
                villain_to_spawn = (int)Random.Range(0, max_villains); //zero acts as the main villain

                if (villain_to_spawn != 0) //check it is the main villain
                {
                    evil_guy_data = GenerateVillainStructSimilarity(selected_sim);
                    count++;
                }
            }

            if (show_villain_count > count_max || villain_to_spawn == 0)  //check it is the main villain
            {
                count = 0;
                evil_guy_data = main_villain_;
            }

            //generate the villain on screen
            new_villain = (GameObject)Instantiate(villain_prefab, transform.position, Quaternion.identity);
            EvilGuyRender script = new_villain.GetComponent<EvilGuyRender>();

            //get a directtion
            EvilGuyRender.Direction dir = (EvilGuyRender.Direction)Random.Range(0, 2);

            script.Init(evil_guy_data, dir, speed_range, anim_to_use);

            //move starting point if facing right
            if (dir == EvilGuyRender.Direction.RIGHT)
            {
                script.SetStartingPosition(other_spawner.transform.position);
            }

        }
    }
    

}
