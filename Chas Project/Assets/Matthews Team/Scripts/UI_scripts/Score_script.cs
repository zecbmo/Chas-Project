using UnityEngine;
using System.Collections;

public class Score_script : MonoBehaviour
{
    GameObject game_util_;
	// Use this for initialization
	void Start ()
    {
        game_util_ = GameObject.FindGameObjectWithTag("GameUtility");
        this.GetComponent<TextMesh>().text = "Score : " + game_util_.GetComponent<GameUtility>().Score.ToString();

    }
	
	// Update is called once per frame
	void Update ()
    {
        this.GetComponent<TextMesh>().text = "Score : " + game_util_.GetComponent<GameUtility>().Score.ToString();
    }
}
