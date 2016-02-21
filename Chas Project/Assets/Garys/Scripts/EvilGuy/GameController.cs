using UnityEngine;
using System.Collections;

public enum Colours {PINK, WHITE, YELLOW, GREY, BROWN, BLUE, RED, GREEN,  PURPLE,  ORANGE };
public enum Similarity {NONE, SIMILAR, VERY_SIMILAR, VERY_VERY_SIMILAR  };
						//none less than half similar
						//similar half or more
						//very similar, only three things different
						//very very similar, only one thing different

public struct EvilGuy 
{
	//this will be the main controller for the villains
	//it acts as a helper for initialising the villain prefabs
	//containing all information about each
	public string name;
	public Colours clothes_colour;
	public Colours skin_colour;
	public Colours shoe_colour;
	public Colours cape_colour;
	public int eye_type;
	public int hat_type;
	public int moustache_type;
	public int weapon_type;

	public static bool operator ==(EvilGuy lhs, EvilGuy rhs)
	{
		if(lhs.clothes_colour != rhs.clothes_colour)
		{
			return false;
		}
		if(lhs.skin_colour != rhs.skin_colour)
		{
			return false;
		}
		if(lhs.shoe_colour != rhs.shoe_colour)
		{
			return false;
		}
		if(lhs.eye_type != rhs.eye_type)
		{
			return false;
		}
		if(lhs.cape_colour != rhs.cape_colour)
		{
			return false;
		}
		if(lhs.hat_type != rhs.hat_type)
		{
			return false;
		}
		if(lhs.moustache_type != rhs.moustache_type)
		{
			return false;
		}
		if(lhs.weapon_type != rhs.weapon_type)
		{
			return false;
		}

		return true;
	}

	public static bool operator !=(EvilGuy lhs, EvilGuy rhs)
	{
		//dont use this
		return false;
	}

	public Similarity CheckIfSimilar(EvilGuy rhs)
	{
		Similarity amount = Similarity.NONE;


		//TODO:: shit inbetween

		return amount;
	}

}

public class GameController : MonoBehaviour 
{

	public enum Difficulty{EASY, MEDIUM, HARD, NIGHTMARE};
	public Difficulty difficulty = Difficulty.EASY;

	public string[] first_names;
	public string[] middle_names;
	public string[] last_names;


	private EvilGuy mainVillain_ = new EvilGuy();

	private int num_eyes_ = 5; //!!the Amouont of images for each needs to be hard coded needs to be update when more images are added!!
	private int num_hats_ = 5;
	private int num_moustaches_ = 5;
	private int num_weapons_ = 5;

	private int total_villains_;
	private int min_villains_;

	void Start () 
	{
		RandomiseVillain(mainVillain_);
	}
	

	void Update () 
	{
		//checking git
	}

	private void RandomiseVillain(EvilGuy villain)
	{
		villain.name = GetRandomName();
		villain.clothes_colour = (Colours)Random.Range(0,10);
		villain.skin_colour = (Colours)Random.Range(0,4);
		villain.shoe_colour = (Colours)Random.Range(0,10);
		villain.cape_colour = (Colours)Random.Range(0,10);
		villain.eye_type = Random.Range(0, num_eyes_);
		villain.hat_type = Random.Range(0, num_hats_);
		villain.moustache_type = Random.Range(0, num_moustaches_);
		villain.weapon_type = Random.Range(0, num_weapons_ );
	}
	private string GetRandomName()
	{
		string newName = "";

		//TODO:: shit inbetween

		return newName;

	}
}
