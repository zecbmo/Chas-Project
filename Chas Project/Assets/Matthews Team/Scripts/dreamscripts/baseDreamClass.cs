using UnityEngine;
using System.Collections;

public class baseDreamClass : MonoBehaviour
{
    
    public int pointaValue;
    public int moveSpeed;

    [HideInInspector]
    public int Points
    {
        get { return pointaValue; }
        set { pointaValue = value; }
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
        Points = pointaValue;
        Speed = moveSpeed;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
            if (hit.collider == this.gameObject.GetComponent<Collider2D>())
            {
                Destroy(this.gameObject);
            }
        }

    }

    
}
