using UnityEngine;
using System.Collections;

public class BaseDreamClass : MonoBehaviour
{
    //sets up private variables for each dream
    public int points_value_max_;
    public int points_value_medium_;
    public int points_value_min_;
    public int move_speed_;
    public int target_index_;

    

    [HideInInspector]
    public int PointsMax
    {
        get { return points_value_max_; }
        set { points_value_max_ = value; }
    }

    [HideInInspector]
    public int PointsMedium
    {
        get { return points_value_medium_; }
        set { points_value_medium_ = value; }
    }
    [HideInInspector]
    public int PointsMin
    {
        get { return points_value_min_; }
        set { points_value_min_ = value; }
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
        PointsMin = points_value_min_;
        PointsMedium = points_value_medium_;
        PointsMax = points_value_max_;
        Speed = move_speed_;
        Target = target_index_;
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    
}
