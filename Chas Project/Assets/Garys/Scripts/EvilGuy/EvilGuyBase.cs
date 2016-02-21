using UnityEngine;
using System.Collections;

public class EvilGuyBase : MonoBehaviour {

	[HideInInspector]
	public enum Colours {BROWN, BLUE, RED, GREEN, YELLOW, PURPLE, PINK, ORANGE, GREY, WHITE };

	[HideInInspector]
	public Colours clothesColour;

	[HideInInspector]
	public Color brown = new Color(1.0f, 0.0f, 0.0f);

	[HideInInspector]
	public Color blue = new Color(0.0f, 0.0f, 1.0f);

	[HideInInspector]
	public Color red = new Color(1.0f, 0.0f, 0.0f);

	[HideInInspector]
	public Color green = new Color(1.0f, 0.0f, 0.0f);

	[HideInInspector]
	public Color yellow = new Color(1.0f, 0.0f, 0.0f);

	[HideInInspector]
	public Color purple = new Color(1.0f, 0.0f, 0.0f);

	[HideInInspector]
	public Color pink = new Color(1.0f, 0.0f, 0.0f);

	[HideInInspector]
	public Color orange = new Color(1.0f, 0.0f, 0.0f);

	[HideInInspector]
	public Color grey = new Color(1.0f, 0.0f, 0.0f);

	[HideInInspector]
	public Color white = new Color(1.0f, 1.0f, 1.0f);


}
