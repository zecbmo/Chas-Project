using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum ButtonType
{
    Retry, Options, Exit_To_Game_Menu, Exit_To_Game_Select
}
public class MenuInput : MonoBehaviour
{
    public ButtonType type_;
    public int scene_to_load_;
    public string button_text_;
    public Vector3 position_;
    // Use this for initialization
    void Start ()
    {
        this.GetComponent<TextMesh>().text = button_text_;
        this.transform.position = position_;

    }

    // Update is called once per frame
    void Update()
    {
        //detects input 
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), transform.forward, Mathf.Infinity);

            if (hit.collider == this.gameObject.GetComponent<Collider2D>() && this.type_ == ButtonType.Retry)
            {
                SceneManager.LoadScene(scene_to_load_);
            }
            if (hit.collider == this.gameObject.GetComponent<Collider2D>() && this.type_ == ButtonType.Options)
            {
                SceneManager.LoadScene(scene_to_load_);
            }
            if (hit.collider == this.gameObject.GetComponent<Collider2D>() && this.type_ == ButtonType.Exit_To_Game_Menu)
            {
                SceneManager.LoadScene(scene_to_load_);
            }
            if (hit.collider == this.gameObject.GetComponent<Collider2D>() && this.type_ == ButtonType.Exit_To_Game_Select)
            {
                Application.Quit();
            }
        }
    }
}
