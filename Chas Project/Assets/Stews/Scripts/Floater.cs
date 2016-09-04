using UnityEngine;
using System.Collections;

public class Floater : MonoBehaviour {
    [SerializeField]
    private Transform buoyancyCentreOffset;
    [SerializeField]
    private float bounceDamp;    
    [SerializeField]
    private WaterInfo waterInfo;

    private Rigidbody2D characterRigidBody;

    void Start() {
        characterRigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
		Vector2 actionPoint = transform.position + buoyancyCentreOffset.transform.position;
		float forceFactor = 1f - ((actionPoint.y - waterInfo.WaterLevel) / waterInfo.WaterHeight);
		
		if (forceFactor > 0f) {
			Vector2 uplift = -Physics.gravity * (forceFactor - characterRigidBody.velocity.y * bounceDamp);            
            characterRigidBody.AddForceAtPosition(uplift, actionPoint,ForceMode2D.Force);
		}
	}
}
