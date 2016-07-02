using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DreamUtil : BaseDreamClass
{
    public float poor_hit_;
    public float good_hit_;
    public float perfect_hit_;

    public int mini_combo_multiplayer_;
    public int max_combo_multiplayer_;

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

        //calculates the direcion which it sould go
        int size_ = game_utility_.GetComponent<GameUtility>().targets_.Length;
        this.Target = Random.Range(0, size_);
        target_ = game_utility_.GetComponent<GameUtility>().targets_[this.Target];
        Vector3 direction_ = target_.transform.position -  this.transform.position;

       //moves the dream
       this.GetComponent<Rigidbody2D>().velocity = (direction_.normalized * this.Speed);
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
                
                if (this.tag == "BadDream")
                {
                    game_utility_.GetComponent<GameUtility>().Life = (game_utility_.GetComponent<GameUtility>().Life - 1);
                    game_utility_.GetComponent<GameUtility>().ComboHits = 0;
                }
                //calculets how far away it is from the colider center and adds poits acordingly if it isnt a perfect hit  it resets combo
                Vector3 distance_vector_ = this.transform.position - game_utility_.GetComponent<GameUtility>().targets_[this.Target].transform.position;
                float distance_ = distance_vector_.magnitude;
                if (distance_ < poor_hit_ && distance_ > good_hit_)
                {
                    game_utility_.GetComponent<GameUtility>().Score = (game_utility_.GetComponent<GameUtility>().Score + this.PointsMin);
                    game_utility_.GetComponent<GameUtility>().ComboHits = 0;
                    Destroy(this.gameObject);
                }
                else if (distance_ < good_hit_ && distance_ > perfect_hit_)
                {
                    game_utility_.GetComponent<GameUtility>().Score = (game_utility_.GetComponent<GameUtility>().Score + this.PointsMedium);
                    game_utility_.GetComponent<GameUtility>().ComboHits = 0;
                    Destroy(this.gameObject);
                }
                else if (this.tag != "BadDream")
                {
                    //looks if you are in a combo and if you are multiplys points 

                    if (game_utility_.GetComponent<GameUtility>().ComboHits > game_utility_.GetComponent<GameUtility>().ComboOne && game_utility_.GetComponent<GameUtility>().ComboHits < game_utility_.GetComponent<GameUtility>().ComboTwo)
                    {
                        game_utility_.GetComponent<GameUtility>().Score = (game_utility_.GetComponent<GameUtility>().Score + this.PointsMax * mini_combo_multiplayer_);
                    }
                    else if (game_utility_.GetComponent<GameUtility>().ComboHits > game_utility_.GetComponent<GameUtility>().ComboTwo)
                    {
                        game_utility_.GetComponent<GameUtility>().Score = (game_utility_.GetComponent<GameUtility>().Score + this.PointsMax * max_combo_multiplayer_);
                    }
                    else
                    {
                        game_utility_.GetComponent<GameUtility>().Score = (game_utility_.GetComponent<GameUtility>().Score + this.PointsMax);
                    }
                    game_utility_.GetComponent<GameUtility>().ComboHits++;

                    Destroy(this.gameObject);
                }
                else
                {
                    game_utility_.GetComponent<GameUtility>().Score = (game_utility_.GetComponent<GameUtility>().Score + this.PointsMax);
                    Destroy(this.gameObject);
                }
                
            }
        }
        //Player missed something decrese life

        if (!this.gameObject.GetComponentInChildren<SpriteRenderer>().isVisible)
        {
            if (this.gameObject.tag != "BadDream")
            {
                game_utility_.GetComponent<GameUtility>().ComboHits = 0;
                game_utility_.GetComponent<GameUtility>().Life = (game_utility_.GetComponent<GameUtility>().Life - 1);

            }
            Destroy(this.gameObject);
        }
        //ends game if player hp is  0 

        if (game_utility_.GetComponent<GameUtility>().Life == 0)
        {
            SceneManager.LoadScene(1);
        }
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

