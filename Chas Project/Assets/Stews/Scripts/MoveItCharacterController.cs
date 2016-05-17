using UnityEngine;
using System.Collections;

public class MoveItCharacterController : MonoBehaviour {

    public MoveItCharacter character;
    private Vector2 forceDirection;
	// Use this for initialization
	void Start () {
        forceDirection = GetForceDirection();
    }
	
	// Update is called once per frame
	void Update () {
        for(int i =0; i <Input.touchCount; i++) {
            if(Input.GetTouch(i).phase == TouchPhase.Began) {
                Debug.Log("tapped");
                character.GetComponent<Rigidbody2D>().AddForce(forceDirection);
            }
        }
	}

    Vector2 GetForceDirection() {
        Vector2 force_direction;
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

        return Vector2.zero;
    }
}
