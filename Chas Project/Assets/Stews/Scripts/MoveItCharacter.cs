using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum MovementType {    
    Land,
    Sea,
    Air
}

public class MoveItCharacter : MonoBehaviour {

    public MovementType movementType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D collider) {
        if(collider.gameObject.tag == "Death") {
            Die();
        }        
    }

    void Die() {
        Debug.Log("death");
        //SceneManager.UnloadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }
}
