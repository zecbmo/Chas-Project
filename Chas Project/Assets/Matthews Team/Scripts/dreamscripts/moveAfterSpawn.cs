using UnityEngine;
using System.Collections;

public class moveAfterSpawn : baseDreamClass
{
    [HideInInspector]
    GameObject scoreCon; 
	// Use this for initialization
	void Start ()
    {
        scoreCon = GameObject.FindGameObjectWithTag("ScoreTrack");
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
                scoreCon.GetComponent<Points>().Score = (scoreCon.GetComponent<Points>().Score + this.Points);   
                Destroy(this.gameObject);
            }
        }
        if (!this.gameObject.GetComponentInChildren<SpriteRenderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }
}
