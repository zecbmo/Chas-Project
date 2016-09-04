using UnityEngine;
using UnityEngine.SceneManagement;

public enum MovementType {    
    Land,
    Sea,
    Air
}

public class MoveItCharacter : MonoBehaviour {
    public MovementType movementType;
    [SerializeField]
    private float magnitudeOfForce = 1.0f;
    [SerializeField]
    private float oxygenLostRate = 1.0f;
    [SerializeField]
    private float oxygenGainRate = 1.0f;
    private bool canBreath = false;    
    [SerializeField]
    private Stat oxygen;
    

    public float MagnitudeOfForce { get { return magnitudeOfForce; } }

    void Awake() {
        oxygen.Initialize();
    }

    // Update is called once per frame
    void Update() {
        if (oxygen.CurrentValue <= 0) {
            Debug.Log("Death by drowning");
            Die();
        }
        // Gain or lose oxygen if character can breath
        if (canBreath) {
            oxygen.CurrentValue += oxygenGainRate;
        } else {
            oxygen.CurrentValue -= oxygenLostRate;
        }

        // testing shite
        
    }
    void OnCollisionEnter2D(Collision2D collider) {
        if (collider.gameObject.tag == "Death") {
            Die();
        }
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "WaterLevel") {
            canBreath = false;
            Debug.Log("cannnot breath");
        }
    }   

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "WaterLevel") {
            canBreath = true;
            Debug.Log("can breath");
        }
    }

    void Die() {
        Debug.Log("death");
        // TODO: load death scene, or start ui for game over?
        //SceneManager.UnloadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }

    public void OnValidate() {
        // Ensures changes in editor show up in game, as if using oxygen get/setters for max/current        
        oxygen.Initialize();
    }
}
