using UnityEngine;
using System.Collections;

public class hp_bar : MonoBehaviour
{
    public GameObject life_bar_;
    public float life_bar_width_;
    private GameObject game_util_;
    private GameObject[] bars_;
    private Vector3 spawn_location_;
    private bool done_ = false;
    private int number_of_bars_;

	// Use this for initialization
	void Start ()
    {
        //finds game utility object
        game_util_ = GameObject.FindGameObjectWithTag("GameUtility");  
	}
	
	// Update is called once per frame
	void Update ()
    {
        //draws all life bars
        if (!done_)
        {
            //draws the abars
            for (int i = 0; i < game_util_.GetComponent<GameUtility>().Life; i++)
            {
                spawn_location_ = this.transform.position;
                spawn_location_.y = spawn_location_.y - (i * life_bar_width_);
                Instantiate(life_bar_, spawn_location_, this.transform.rotation);
                if (i == game_util_.GetComponent<GameUtility>().Life - 1)
                {
                    //breaks the loop and add all  abrs into and array
                    done_ = true;
                    number_of_bars_ = game_util_.GetComponent<GameUtility>().Life;
                    bars_ = GameObject.FindGameObjectsWithTag("Life");
                }
            }
        }
        //if life has changed destroy one bar
        if (number_of_bars_ != game_util_.GetComponent<GameUtility>().Life)
        {
            Destroy(bars_[number_of_bars_ -1]);
            number_of_bars_ = game_util_.GetComponent<GameUtility>().Life;
            
        } 
    }
}
