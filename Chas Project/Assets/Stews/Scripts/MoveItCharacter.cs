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
    private float oxygenLostRate = 0.01f;
    [SerializeField]
    private float oxygenGainRate = 0.01f;
    private float currentOxygen = 1.0f;
    private float maxOxygen = 1.0f;
    private bool canBreath = false;

    // Update is called once per frame
    void Update() {
        if (currentOxygen < 0) {
            Die();
        }
        // Gain or lose oxygen if character can breath
        if (canBreath) {
            currentOxygen += oxygenGainRate;
        } else {
            currentOxygen -= oxygenLostRate;
        }
    }
    void OnCollisionEnter2D(Collision2D collider) {
        if (collider.gameObject.tag == "Death") {
            Die();
        }

    }

    public void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Death") {
            Die();
        }
    }

    void Die() {
        Debug.Log("death");
        // TODO: load death scene, or start ui for game over?
        //SceneManager.UnloadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }
}
