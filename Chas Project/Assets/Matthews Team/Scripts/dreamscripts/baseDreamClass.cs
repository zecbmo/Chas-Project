using UnityEngine;
using System.Collections;

public class baseDreamClass : MonoBehaviour
{
    
    public int pointsValue;
    public int moveSpeed;

    [HideInInspector]
    public int Points
    {
        get { return pointsValue; }
        set { pointsValue = value; }
    }

    [HideInInspector]
    public int Speed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }



    // Use this for initialization

    void Start ()
    {
        Points = pointsValue;
        Speed = moveSpeed;

    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    
}
