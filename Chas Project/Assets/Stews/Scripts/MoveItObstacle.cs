using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveItObstacle : MonoBehaviour {
    [Tooltip("Distance from centre to edge")]
    public float SeperationHorizontal = 0.0f;
    [Tooltip("Chance of obstacle turning up")]
    [Range(0, 100)]
    public float Weight = 100.0f;    

    public void SetSpeed(float obstacleSpeed) {
        speed = obstacleSpeed;
        speedUpdated = true;
    }
    [SerializeField]
    private float speed = 1;
    private Vector2 forceDirection = new Vector2(-1,0);
    private Rigidbody2D characterRigidBody;

    bool speedUpdated = false;

    void Start() {        
        characterRigidBody = gameObject.GetComponent<Rigidbody2D>();
        characterRigidBody.velocity = (forceDirection * speed);
    }
        
    void Update () {
        if (speedUpdated) {
            characterRigidBody.velocity = (forceDirection * speed);
        }       
    }

    void OnTriggerExit2D(Collider2D collider) {

        if (collider.gameObject.tag == "GameSpace") {
            Die();
        }
    }

    void Die() {
        Destroy(gameObject);      
    }
}
