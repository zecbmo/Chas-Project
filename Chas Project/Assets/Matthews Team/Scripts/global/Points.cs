using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {

    private int score;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
	// Use this for initialization
	void Start ()
    {
        Score = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
