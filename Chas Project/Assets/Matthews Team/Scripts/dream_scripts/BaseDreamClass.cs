using UnityEngine;
using System.Collections;

public class BaseDreamClass : MonoBehaviour
{
    //sets up private variables for each dream
    public int points_value_;
    public int move_speed_;
    public int target_index_;

    [HideInInspector]
    public int Points
    {
        get { return points_value_; }
        set { points_value_ = value; }
    }

    [HideInInspector]
    public int Target
    {
        get { return target_index_; }
        set { target_index_ = value; }
    }

    [HideInInspector]
    public int Speed
    {
        get { return move_speed_; }
        set { move_speed_ = value; }
    }



    // Use this for initialization

    void Start ()
    {
        Points = points_value_;
        Speed = move_speed_;
        Target = target_index_;
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    
}
