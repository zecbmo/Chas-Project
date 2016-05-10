﻿using UnityEngine;
using System.Collections;

public class GameUtility : MonoBehaviour {

    private int score_;
    private int life_;

    public GameObject[] targets_;

    public int Score
    {
        get { return score_; }
        set { score_ = value; }
    }
    public int Life
    {
        get { return life_; }
        set { life_ = value; }
    }
    // Use this for initialization
    void Start ()
    {
        Score = 0;
        Life = 5;
        targets_ = GameObject.FindGameObjectsWithTag("Target");
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
