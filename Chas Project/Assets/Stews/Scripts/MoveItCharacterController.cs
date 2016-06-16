using UnityEngine;
using System.Collections;


public class MoveItCharacterController : MonoBehaviour {

    public MoveItCharacter character;
    public float magnitudeOfForce = 1;
    private Vector2 forceDirection;

    private Rigidbody2D characterRigidBody;

	// Use this for initialization
	void Start () {
        forceDirection = GetForceDirection();
        characterRigidBody = character.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {        
        for (int i =0; i <Input.touchCount; i++) {            
            if (Input.GetTouch(i).phase == TouchPhase.Began) {                
                characterRigidBody.velocity = Vector2.zero;
                characterRigidBody.AddForce(forceDirection * magnitudeOfForce);
            }
        }
	}
    Vector2 GetForceDirection() {
        Vector2 force_direction = Vector2.zero;
        switch (character.movementType) {
            case MovementType.Air: {
                    force_direction = new Vector2(0, 1);
                    break;
                }
            case MovementType.Land: {
                    force_direction = new Vector2(0, 1);
                    break;
                }
            case MovementType.Sea: {
                    force_direction = new Vector2(0, -1);
                    break;
                }
            default:
                break;
        }

        return force_direction;
    }
    
}
