using UnityEngine;
using System.Collections;

//This class is added to objects identified as clothing... only needs access to the sprite renderer as it is changed from the parent

public class BaseClothes : MonoBehaviour 
{
	//[HideInInspector]
	private SpriteRenderer sr;

	// Use this for initialization
	void Awake () 
	{
		sr = GetComponentInChildren<SpriteRenderer>();
	}
	public void SetColour(Color colour)
	{
		sr.color = colour;
	}
}
