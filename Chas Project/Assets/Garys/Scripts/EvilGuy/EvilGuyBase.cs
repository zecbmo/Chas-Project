using UnityEngine;
using System.Collections;

public class EvilGuyBase : MonoBehaviour 
{

	//public enum Colours {PINK, WHITE, YELLOW, GREY, BROWN, BLUE, RED, GREEN,  PURPLE,  ORANGE };

	[Header("Clothes Colours including cape/shoes")]
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

	private EvilGuyStruct this_villain_;
	private Color clothes_colour;
    private Color skin_colour;
    private Color shoe_colour;
    private Color cape_colour;
    private Color hat_colour;




    void Start()
	{


	}

	void Update()
	{
		//if main enemy
		//and on screen and person shouting 
		//win something

	}

	public void Init(EvilGuyStruct villain)
	{
		//Get info from the controller class
		this_villain_ =  villain;     ///////////WARNING GARY!!!! This line may cause some memory problems0(maybe)

		//set the colours
		SetColours();

		//update the sprites within this game object
		SetClothesColoursInChildren();

	}

	void SetColours()
	{
        //clothes
        SetColourFromEnum(ref clothes_colour, this_villain_.clothes_colour);
        //shoes
        SetColourFromEnum(ref shoe_colour, this_villain_.shoe_colour);
        //Skin
        SetSkinColourFromEnum(ref skin_colour, this_villain_.skin_colour);
        //cape
        SetColourFromEnum(ref cape_colour, this_villain_.cape_colour);
        //hat
        SetColourFromEnum(ref hat_colour, this_villain_.hat_colour);

    }

    void SetClothesColoursInChildren()
	{
		Component[] parts = GetComponentsInChildren<BaseColourChanger>();
	
        //Loop through children that colours need modified and set them
		foreach(BaseColourChanger item in parts) 
		{
            switch (item.colour_type)
            {
                case BaseColourChanger.Colour_Type.CLOTHES:
                    item.SetColour(clothes_colour);
                    break;
                case BaseColourChanger.Colour_Type.SKIN:
                    item.SetColour(skin_colour);
                    break;
                case BaseColourChanger.Colour_Type.SHOES:
                    item.SetColour(shoe_colour);
                    break;
                case BaseColourChanger.Colour_Type.CAPE:
                    item.SetColour(cape_colour);
                    break;
                case BaseColourChanger.Colour_Type.HAT:
                    item.SetColour(hat_colour);
                    break;
            }
		} 
    }

    void SetColourFromEnum(ref Color to_change, Colours colour_enum)
    {
        //uses the big set of colours
        switch (colour_enum)
        {
            case Colours.BROWN:
                to_change = brown;
                break;
            case Colours.RED:
                to_change = red;
                break;
            case Colours.BLUE:
                to_change = blue;
                break;
            case Colours.PINK:
                to_change = pink;
                break;
            case Colours.PURPLE:
                to_change = purple;
                break;
            case Colours.YELLOW:
                to_change = yellow;
                break;
            case Colours.GREEN:
                to_change = green;
                break;
            case Colours.GREY:
                to_change = grey;
                break;
            case Colours.WHITE:
                to_change = white;
                break;
            case Colours.ORANGE:
                to_change = orange;
                break;
        }
    }
    void SetSkinColourFromEnum(ref Color to_change, Colours colour_enum) //skin ranges fdrom 0-4 and will differ in colours from base colours
    {
        switch (colour_enum)
        {
            case Colours.PINK:
                to_change = skin_pink;
                break;         
            case Colours.YELLOW:
                to_change = skin_yellow;
                break;         
            case Colours.GREY:
                to_change = skin_grey;
                break;
            case Colours.WHITE:
                to_change = skin_white;
                break;                 
        }
    }

}
