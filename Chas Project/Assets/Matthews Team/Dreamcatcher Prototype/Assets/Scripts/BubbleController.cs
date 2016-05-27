using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class BubbleController : MonoBehaviour {

    public static float increaseRate;

    private float centreX = 0f; //used as a centre point, can test for trajectory paths (which direction to move in)

    private float minScale = 0.1f; //minimum and maximum relative sizes of the dreams
    private float maxScale = 2f; //max scale before popping
    private float scale; //the size of the bubble

    private float minY = -2.75f; //coordinate ranges for where the bubble can be within
    private float maxY = 3.25f;
    private float minX = -2.75f;
    private float maxX = 2.75f;

    private float movementSpeed; 
    private float rightScale; //movement scales
    private float upScale;

    private Rigidbody2D rb2D;
    private float spawnPositionX;

    int direction = 0; //right or left

    // Use this for initialization
    void Awake()
    {
        //initialisation
        spawnPositionX = this.transform.position.x;
        increaseRate = 0f;
        rb2D = GetComponent<Rigidbody2D>();
        scale = minScale;
        movementSpeed = 1f * (GameManagerController.growthRate); //movement speed relates to growth rate
        SetDirection(); //set horizontal direction
        UpdateScale();
	}
	
    void UpdateScale()
    {
        scale = scale + (Time.deltaTime * GameManagerController.growthRate); //update scale over time
        transform.localScale = new Vector3(scale, scale); //increase size
        if (scale >= maxScale)
        {
            BubblePop(); //pop if too big
        }
    }

    void BubblePop()
    {
        GameManagerController.bubbleNo--; //decrease number of bubbles

        Destroy(this.gameObject); //destroy bubble
    }

    void MoveBubble()
    {
        rb2D.AddForce(transform.up * upScale, ForceMode2D.Force); //upwards force
        rb2D.AddForce(transform.right * direction * rightScale, ForceMode2D.Force); //right or left force
    }

    void SetDirection() //determines whether the bubble will move right or left
    {
        float chanceLeft = Random.Range(0, 100);
        if (chanceLeft < 50)
        {
            direction = -1; //left
        }
        else
        {
            direction = 1; //right
        }
        upScale = Random.Range((movementSpeed * 0.8f), movementSpeed); //for variety, slightly random upwards speed
        rightScale = Random.Range(0, movementSpeed); //random horizontal speed
    }

    void CalculateHorizontalVelocity()
    {

    }

    void OnMouseDown()
    {
        BubblePop(); //if clicked, pop bubble
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        UpdateScale(); //scale updated every frame
        MoveBubble(); //bubble position updated every frame
	}
}
