using UnityEngine;
using System.Collections;

public class Combo_Display : MonoBehaviour
{
    private GameObject game_util_;
	// Use this for initialization
	void Start ()
    {
        this.GetComponent<TextMesh>().text = null;
        game_util_ = GameObject.FindGameObjectWithTag("GameUtility");

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (game_util_.GetComponent<GameUtility>().ComboHits > 0 && game_util_.GetComponent<GameUtility>().ComboHits < game_util_.GetComponent<GameUtility>().ComboOne)
        {
            this.GetComponent<TextMesh>().text = game_util_.GetComponent<GameUtility>().ComboHits.ToString() + " Hit"; 
        }
        if (game_util_.GetComponent<GameUtility>().ComboHits >= game_util_.GetComponent<GameUtility>().ComboOne && game_util_.GetComponent<GameUtility>().ComboHits < game_util_.GetComponent<GameUtility>().ComboTwo)
        {
            this.GetComponent<TextMesh>().text = game_util_.GetComponent<GameUtility>().ComboHits.ToString() + " Hit"  + " Combo 2X";
        }
        if (game_util_.GetComponent<GameUtility>().ComboHits >= game_util_.GetComponent<GameUtility>().ComboTwo)
        {
            this.GetComponent<TextMesh>().text = game_util_.GetComponent<GameUtility>().ComboHits.ToString() + " Hit" + " Combo 4X";
        }
        if (game_util_.GetComponent<GameUtility>().ComboHits == 0)
        {
            this.GetComponent<TextMesh>().text = null;
        }
    }
}
