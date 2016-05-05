﻿using UnityEngine;
using System.Collections;

public class DreamUtil : BaseDreamClass
{
    [HideInInspector]
    GameObject game_utility_; 
	// Use this for initialization
	void Start ()
    {
        game_utility_ = GameObject.FindGameObjectWithTag("GameUtility");
        this.GetComponent<Rigidbody2D>().velocity = (this.transform.up * this.Speed);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
            if (hit.collider == this.gameObject.GetComponent<Collider2D>())
            {
                game_utility_.GetComponent<Points>().Score = (game_utility_.GetComponent<Points>().Score + this.Points);   
                Destroy(this.gameObject);
            }
        }
        if (!this.gameObject.GetComponentInChildren<SpriteRenderer>().isVisible)
        {
            game_utility_.GetComponent<Points>().Life = (game_utility_.GetComponent<Points>().Life - 1);
            Destroy(this.gameObject);
        }
        if (game_utility_.GetComponent<Points>().Life == 0)
        {
            Debug.Log("end game");
        }
    }
}