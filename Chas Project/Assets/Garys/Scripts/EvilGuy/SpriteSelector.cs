using UnityEngine;
using System.Collections;

public class SpriteSelector : MonoBehaviour {

    [Header("Array size should match the num of sprites available to that part in the GameController Class")]
    public Sprite[] sprites;
    private SpriteRenderer sr;

    public enum Sprite_type  {EYES, WEAPON, BEARD, HAT };
    public Sprite_type sprite_type  = Sprite_type.EYES;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void SetSprite(int sprite_num)
    {
        sr.sprite = sprites[sprite_num];
    }
}
