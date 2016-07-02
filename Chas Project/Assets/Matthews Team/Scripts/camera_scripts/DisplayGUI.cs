using UnityEngine;
using System.Collections;

public class DisplayGUI : MonoBehaviour

{
    // menu  varaibles that are visible in editor 

    public Vector2 pos_pause_;
    public Vector2 size_pause_;
    public Texture pause_texture_;
    public float fade_in_speed_;
    public float fade_out_speed_;
    public float fade_limit_background_;
    public float fade_limit_text_;
    public float fade_out_limit_;
    public GameObject transparency_plane_;
    public GameObject[] menu_buttons_;
    public Color[] menu_transperancy_;



    // private varaibles

    [HideInInspector]
    private Color transparancy_;
    [HideInInspector]
    private Color transparancy_menu_;
    [HideInInspector]
    private bool menu_fade_;
    [HideInInspector]
    private bool paused_;
    [HideInInspector]
    private bool text_faded_out;
    private Rect pause_rec_;
    

    // Use this for initialization
    void Start ()
    {
        //sets  the plane transperecy color and sets all the varaibles in theire inital states (game isnt paused and menu isnt rendendered)
        paused_ = false;
        transparancy_.r = 1.0f;
        transparancy_.g = 1.0f;
        transparancy_.b = 1.0f;
        transparancy_.a = 0.0f;



        transparency_plane_.GetComponent<SpriteRenderer>().material.color = transparancy_;
        transparency_plane_.GetComponent<SpriteRenderer>().enabled = true;

        //initilizes the menu button system
        for (int i = 0; i < menu_buttons_.Length; i++)
        {
            menu_buttons_[i].GetComponent<MeshRenderer>().enabled = true;
            menu_buttons_[i].GetComponent<TextMesh>().color = transparancy_menu_;
            menu_buttons_[i].GetComponent<BoxCollider>().enabled = false;
            menu_transperancy_[i].r = 1.0f;
            menu_transperancy_[i].g = 1.0f;
            menu_transperancy_[i].b = 1.0f;
            menu_transperancy_[i].a = 0.0f;
        }
        //bool  for check is the menu buttons have faded in or out
        text_faded_out = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //This is menu animation none of these functions run  if the game isnt paused
        //fades the bacgraund in makes the game darker (change color of the plane for diffrent effects)

        FadeBackgraund();

        //loops to fade in or fade out the text menu buttons
        for (int button_index_ = 0; button_index_ < menu_buttons_.Length; button_index_++)
        {
            FadeText(button_index_);
            FadeOutText(button_index_);
        }
        //fades out the backgraund
        FadeOutBackgraund();
    }

    void OnGUI()
    {
        //creates the button at the positions and at cirtin size

        pause_rec_ = new Rect(pos_pause_, size_pause_);

        if (!pause_texture_)
        {
            // forgot to add texture
            Debug.LogError("Please assign a texture on the inspector");
            return;
        }
        if (GUI.Button(new Rect(245, 480, 200, 200), pause_texture_))
        {
            if (!paused_)
            {
                //pauses the game
                paused_ = true;
                Time.timeScale = 0.0f;
            }
            else
            {
                // tells menu to fade back out
                paused_ = false;
            }
           
        }
    }

    void FadeBackgraund()
    {
        if (paused_)
        {
            //checks if the game has been darkend to the set limit
            if (transparancy_.a <= fade_limit_background_)
            {

                //updates transperency 
                transparancy_.a = transparancy_.a + fade_in_speed_;

                //elimination of floating point precision
                if (transparancy_.a > fade_limit_background_)
                {
                    transparancy_.a = fade_limit_background_;
                }
            }
            //updates transperency
            transparency_plane_.GetComponent<SpriteRenderer>().material.color = transparancy_;
        }
    }

    void FadeText(int button_index_)
    {
        //checks if the game is paused and if the game has been faded
        if (paused_ && transparancy_.a >= fade_limit_background_)
        {
            //looks if the button needs to be faded in more
            if (menu_transperancy_[button_index_].a <= fade_limit_text_)
            {
                //update transperency 
                menu_transperancy_[button_index_].a = menu_transperancy_[button_index_].a + fade_in_speed_;
                //floting poiint precision 
                if (menu_transperancy_[button_index_].a > fade_limit_text_)
                {
                    menu_transperancy_[button_index_].a = fade_limit_text_;
                }
            }
            //text has been faded in change the bools and enable coliders
            if (menu_transperancy_[button_index_].a == fade_limit_text_)
            {
                text_faded_out = false;
                menu_buttons_[button_index_].GetComponent<BoxCollider>().enabled = true;
            }
            //apply transparncy to the object
            menu_buttons_[button_index_].GetComponent<TextMesh>().color = menu_transperancy_[button_index_];
            
        }
    }

    void FadeOutText(int button_index_)
    {
        //test to see if the game isnt paused anymore and if 
        if (!paused_ && transparancy_.a == fade_limit_background_)
        {
            //the button hasnt faded 
            if (menu_transperancy_[button_index_].a != fade_out_limit_)
            {
                //disables the menu buttons
                if (menu_buttons_[button_index_].GetComponent<BoxCollider>().enabled)
                {
                    menu_buttons_[button_index_].GetComponent<BoxCollider>().enabled = false;
                }
                // update transperency
                menu_transperancy_[button_index_].a = menu_transperancy_[button_index_].a - fade_out_speed_;
                //floating point precision test
                if (menu_transperancy_[button_index_].a < fade_out_limit_)
                {
                    menu_transperancy_[button_index_].a = fade_out_limit_; 
                }
              
            }
            //all text has been faded out  bool reset
            if (menu_transperancy_[button_index_].a == fade_out_limit_)
            {
                text_faded_out = true;
            }
            //apply transperancy
            menu_buttons_[button_index_].GetComponent<TextMesh>().color = menu_transperancy_[button_index_];
        }
    }

    void FadeOutBackgraund()
    {
        //test if the game isnt paused anymore and if all teh text has faded out
        if (!paused_ && text_faded_out)
        {
            //tests if the game has been facded back in
            if (transparancy_.a != fade_out_limit_)
            {
                //updates transperency
                transparancy_.a = transparancy_.a - fade_out_speed_;
                //floating point precision test
                if (transparancy_.a < fade_out_limit_)
                {
                    transparancy_.a = fade_out_limit_;
                }
            }
            //resumes the game
            if (transparancy_.a == fade_out_limit_)
            {
                Time.timeScale = 1.0f;
            } 
            //applys transperency 
            transparency_plane_.GetComponent<SpriteRenderer>().material.color = transparancy_;
        }  
    }
}


