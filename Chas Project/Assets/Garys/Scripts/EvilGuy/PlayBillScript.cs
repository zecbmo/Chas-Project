using UnityEngine;
using System.Collections;

public class PlayBillScript : MonoBehaviour {

    public float speed = 10.0f;
    private bool clicked_ = false;
    private Vector2 start_pos_;
    private Vector2 end_pos_;
    // Use this for initialization


    public GameObject CanvasCentre;
	void Start ()
    {
        start_pos_ = transform.position;
        end_pos_ = CanvasCentre.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (clicked_)
        {
            if (transform.position.x < end_pos_.x)
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
        }
        else
        {
            if (transform.position.x > start_pos_.x)
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
        }

	}

    public void ButtonClicked()
    {
        clicked_ = !clicked_;
    }
}
