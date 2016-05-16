using UnityEngine;
using System.Collections;

public class GameUtility : MonoBehaviour {

    private int score_;
    private int life_;
    private int combo_hits_;
    private int combo_one_;
    private int combo_two_;

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
    public int ComboHits
    {
        get { return combo_hits_; }
        set { combo_hits_ = value; }
    }

    public int ComboOne
    {
        get { return combo_one_; }
        set { combo_one_ = value; }
    }

    public int ComboTwo
    {
        get { return combo_two_; }
        set { combo_two_ = value; }
    }
    // Use this for initialization
    void Start ()
    {
        Score = 0;
        Life = 5;
        ComboHits = 0;
        ComboOne = 5;
        ComboTwo = 10;
        targets_ = GameObject.FindGameObjectsWithTag("Target");
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
