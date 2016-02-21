using UnityEngine;
using System.Collections;

//This class inherits from the base evil guy defining colours


public class BaseClothes : EvilGuyBase
{
	
	SpriteRenderer sr;

	// Use this for initialization
	void Start () 
	{
		sr = GetComponentInChildren<SpriteRenderer>();

		GetClothesColour();
		SetSpriteColour();


	}

	void GetClothesColour()
	{
		clothesColour = (Colours)Random.Range(0,10);
	}

	void SetSpriteColour()
	{
		switch(clothesColour)
		{
		case Colours.BROWN: sr.color = brown;
							break;
		case Colours.RED: sr.color = red;
							break;
		case Colours.BLUE: sr.color = blue;
							break;
		case Colours.PINK: sr.color = pink;
							break;
		case Colours.YELLOW: sr.color = yellow;
							break;
		case Colours.GREEN: sr.color = green;
							break;
		case Colours.GREY: sr.color = grey;
							break;
		case Colours.WHITE: sr.color = white;
							break;
		case Colours.ORANGE: sr.color = orange; 
							break;
		}
	}
}
