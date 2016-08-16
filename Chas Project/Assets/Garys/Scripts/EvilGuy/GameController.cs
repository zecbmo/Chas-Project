using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Difficulty { EASY_0, EASY_1, MEDIUM_0, MEDIUM_1, HARD_0, HARD_1 ,NIGHTMARE_0, NIGHTMARE_1 };

public class GameController : MonoBehaviour 
{

	//public enum Difficulty{EASY, MEDIUM, HARD, NIGHTMARE};
	public Difficulty difficulty = Difficulty.EASY_0;

	public string[] first_names;
	public string[] middle_names;
	public string[] last_names;



	static public int num_eyes_ = 3; //!!the Amouont of images for each needs to be hard coded needs to be update when more images are added!!
    static public int num_hats_ = 3;
    static public int num_moustaches_ = 3;
    static public int num_weapons_ = 3;
    static public int num_overlays_ = 3;

    static public int spawn_layer = 0;
   



    //Main guy on screen
    static public bool main_guy_onscreen = false;
   

    //started working on spawner
    //have array of enemies to pick from


    static public int total_amount_of_villains = 5;


	void Start () 
	{

    }
      
	void Update () 
	{
      
    }




  
  

}
