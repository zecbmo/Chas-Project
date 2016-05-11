using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        //detects input 
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), transform.forward, Mathf.Infinity);

            if (hit.collider == this.gameObject.GetComponent<Collider2D>() && this.gameObject.tag == "Retry")
            {
                SceneManager.LoadScene(0);
            }
            if (hit.collider == this.gameObject.GetComponent<Collider2D>() && this.gameObject.tag == "Quit")
            {
                Application.Quit();
            }
        }
    }
}
