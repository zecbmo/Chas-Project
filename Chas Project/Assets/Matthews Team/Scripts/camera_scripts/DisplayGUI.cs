﻿using UnityEngine;
using System.Collections;

public class DisplayGUI : MonoBehaviour {

    GameObject score; 
    // Use this for initialization
	void Start ()
    {
        score = GameObject.FindGameObjectWithTag("ScoreTrack");

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnGUI()
    { 
        GUILayout.Label("Score = " + score.GetComponent<Points>().Score);
    }
}
