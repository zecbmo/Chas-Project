using UnityEngine;
using System.Collections;

public class DreamUtil : BaseDreamClass
{
    [HideInInspector]
    GameObject game_utility_;

    [HideInInspector]
    public bool is_destroyable_;

    [HideInInspector]
    GameObject target_;

    // Use this for initialization
    void Start ()
    {
        game_utility_ = GameObject.FindGameObjectWithTag("GameUtility");
        //moves the dream
        this.GetComponent<Rigidbody2D>().velocity = (this.transform.up * this.Speed);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //detects if the dream is in the pop area and if it is pop it

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), transform.forward, Mathf.Infinity);

            if (hit.collider == this.gameObject.GetComponent<Collider2D>() && is_destroyable_)
            {
                game_utility_.GetComponent<GameUtility>().Score = (game_utility_.GetComponent<GameUtility>().Score + this.Points);
                //last working
                Vector3 distance = this.transform.position - game_utility_.GetComponent<GameUtility>().targets_[0].transform.position;
                Destroy(this.gameObject);
            }
        }
        //Player missed something decrese life

        if (!this.gameObject.GetComponentInChildren<SpriteRenderer>().isVisible)
        {
            game_utility_.GetComponent<GameUtility>().Life = (game_utility_.GetComponent<GameUtility>().Life - 1);
            Destroy(this.gameObject);
        }
        //ends game if player hp is  0 

        if (game_utility_.GetComponent<GameUtility>().Life == 0)
        {
            Debug.Log("end game");
        }
    }

    void CalculatePoints()
    {

    }



    //colision detection 
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Target")
        {
            is_destroyable_ = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Target")
        {
            is_destroyable_ = true;
        }
    }

}

