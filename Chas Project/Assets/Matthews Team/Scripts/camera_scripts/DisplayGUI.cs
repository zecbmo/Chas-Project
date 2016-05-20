using UnityEngine;
using System.Collections;

public class DisplayGUI : MonoBehaviour {

    GameObject score;
    [HideInInspector]
    GameObject transparency_plane_;
    [HideInInspector]
    GameObject retry_button_;

    public Texture pause_texture_;
    Rect pause_rec_;




    [HideInInspector]
    private Vector2 pos_;
    [HideInInspector]
    private Vector2 size_;
    [HideInInspector]
    private Color transparancy_;
    [HideInInspector]
    private Color transparancy_menu_;
    [HideInInspector]
    private bool paused_;
    // Use this for initialization
    void Start ()
    {
        score = GameObject.FindGameObjectWithTag("GameUtility");
        transparency_plane_ = GameObject.FindGameObjectWithTag("MenuPlane");
        retry_button_ = GameObject.FindGameObjectWithTag("Retry");
        paused_ = false;
        transparancy_.r = 1.0f;
        transparancy_.g = 1.0f;
        transparancy_.b = 1.0f;
        transparancy_.a = 0.0f;

        transparancy_menu_.r = 1.0f;
        transparancy_menu_.g = 1.0f;
        transparancy_menu_.b = 1.0f;
        transparancy_menu_.a = 0.0f;

        transparency_plane_.GetComponent<SpriteRenderer>().material.color = transparancy_;
        transparency_plane_.GetComponent<SpriteRenderer>().enabled = true;
        retry_button_.GetComponent<TextMesh>().color = transparancy_menu_;
        retry_button_.GetComponent<BoxCollider>().enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // change this into functions but it works now 
        if (paused_)
        {
            if (transparancy_.a <= 0.5f)
            {
                transparancy_.a = transparancy_.a + 0.05f;
            }
            transparancy_.r = 1.0f;
            transparancy_.g = 1.0f;
            transparancy_.b = 1.0f;
            transparency_plane_.GetComponent<SpriteRenderer>().material.color = transparancy_;
            if (transparancy_.a > 0.5f)
            {
                if (transparancy_menu_.a <= 1.0f)
                {
                    transparancy_menu_.a = transparancy_menu_.a + 0.05f;
                }
                transparancy_menu_.r = 1.0f;
                transparancy_menu_.g = 1.0f;
                transparancy_menu_.b = 1.0f;
                retry_button_.GetComponent<TextMesh>().color = transparancy_menu_;
            }
            if (transparancy_menu_.a == 1.0f)
            {
                retry_button_.GetComponent<BoxCollider>().enabled = true;
            }
        }
        if (!paused_)
        {
            if (transparancy_menu_.a == 0.0f)
            {
                transparancy_.a = transparancy_.a - 0.05f;
            }
            transparancy_.r = 1.0f;
            transparancy_.g = 1.0f;
            transparancy_.b = 1.0f;
            transparancy_.a = 0.0f;
            transparency_plane_.GetComponent<SpriteRenderer>().material.color = transparancy_;

            if (transparancy_menu_.a != 0.0f)
            {
                transparancy_menu_.a = transparancy_menu_.a - 0.05f;
            }
            transparancy_menu_.r = 1.0f;
            transparancy_menu_.g = 1.0f;
            transparancy_menu_.b = 1.0f;
            retry_button_.GetComponent<TextMesh>().color = transparancy_menu_;

        }
    }

    void OnGUI()
    {
        pos_.Set(245.0f, 480.0f);
        size_.Set(50.0f, 50.0f);

        pause_rec_ = new Rect(pos_, size_);

        if (!pause_texture_)
        {
            Debug.LogError("Please assign a texture on the inspector");
            return;
        }
        if (GUI.Button(pause_rec_, pause_texture_))
        {
            if (!paused_)
            {
                paused_ = true;
                Time.timeScale = 0.0f;
            }
            else
            {
                paused_ = false;
                Time.timeScale = 1.0f;
            }
           
        }


        GUILayout.Label("Score = " + score.GetComponent<GameUtility>().Score);
        GUILayout.Label("Life = " + score.GetComponent<GameUtility>().Life);
        GUILayout.Label("Combo = " + score.GetComponent<GameUtility>().ComboHits);
    }
}
