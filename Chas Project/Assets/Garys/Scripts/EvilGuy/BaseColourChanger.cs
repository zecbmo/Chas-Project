using UnityEngine;
using System.Collections;

//This class is added to objects identified as clothing... only needs access to the sprite renderer as it is changed from the parent
//Changes the base clothes colour
//Added to objects within the Evil Guy prefab that would be clothing 
//When the guy is spawned clothes will change to the colour set by the evil guy base


public class BaseColourChanger : MonoBehaviour
{
    //[HideInInspector]
    private SpriteRenderer sr;

    public enum Colour_Type { CLOTHES, SKIN, SHOES, CAPE, HAT };
    public Colour_Type colour_type = Colour_Type.CLOTHES;

    // Use this for initialization
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void SetColour(Color colour)
    {
        sr.color = colour;
    }
}

