using UnityEngine;
using System.Collections;

public class OverlaySelecter : MonoBehaviour {

    //over lays will be used to draw characters on to the base
    //there will be an array for each body part
    //the place in the array inidcates which overlay set it is from
    //eg. 0 will all be drawn by one child
    //eg. 1 will be drawn by someone else

    [Header("Array size should match the num_overlays variable in the GameController Class")]
    public Sprite[] overlay;
    private SpriteRenderer sr;

    // Use this for initialization
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void SetOverlay(int overlay_num)
    {
        sr.sprite = overlay[overlay_num];
    }
}
