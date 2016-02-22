using UnityEngine;
using System.Collections;

public class EvilGuyBase : MonoBehaviour 
{

	//public enum Colours {PINK, WHITE, YELLOW, GREY, BROWN, BLUE, RED, GREEN,  PURPLE,  ORANGE };

	[Header("Clothes Colours")]
	public Color brown; 
	public Color blue;
	public Color red; 
	public Color green;
	public Color yellow;
	public Color purple;
	public Color pink; 
	public Color orange; 
	public Color grey; 
	public Color white;

	[Header("Skin Colours")]
	public Color skin_pink;
	public Color skin_white;
	public Color skin_yellow;
	public Color skin_grey;

	private EvilGuy this_villain_;
	private Color clothes_colour;

	void Start()
	{


	}

	void Update()
	{
		//if main enemy
		//and on screen and person shouting 
		//win something

	}

	public void Init(EvilGuy villain)
	{
		//Get info from the controller class
		this_villain_ =  villain;                                   ///////////WARNING GARY!!!! This line may cause some memory problems

		//set the colours
		SetClothesColour();

		//update the sprites within this game object
		SetClothesColoursInChildren();

	}

	void SetClothesColour()
	{
		switch(this_villain_.clothes_colour)
		{
		case Colours.BROWN: clothes_colour = brown;
			break;
		case Colours.RED: clothes_colour = red;
			break;
		case Colours.BLUE: clothes_colour = blue;
			break;
		case Colours.PINK: clothes_colour = pink;
			break;
		case Colours.PURPLE: clothes_colour = purple;
			break;
		case Colours.YELLOW: clothes_colour = yellow;
			break;
		case Colours.GREEN: clothes_colour = green;
			break;
		case Colours.GREY: clothes_colour = grey;
			break;
		case Colours.WHITE: clothes_colour = white;
			break;
		case Colours.ORANGE: clothes_colour = orange; 
			break;
		}
	}

	void SetClothesColoursInChildren()
	{
		Component[] clothes = GetComponentsInChildren<BaseClothes>();
	
		foreach(BaseClothes item in clothes )
		{
			item.SetColour(clothes_colour);
		}
	}
}
