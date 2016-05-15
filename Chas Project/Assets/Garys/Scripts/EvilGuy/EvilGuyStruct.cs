using UnityEngine;
using System.Collections;

//keep colours in order.. first four are skin colours
public enum Colours { PINK, WHITE, YELLOW, GREY, BROWN, BLUE, RED, GREEN, PURPLE, ORANGE };
public enum Similarity { NONE, SIMILAR, VERY_SIMILAR, VERY_VERY_SIMILAR, EXACT_SAME };
//none less than half similar
//similar half or more
//very similar, only three things different
//very very similar, only one thing different

public struct EvilGuyStruct //Struct seperate from villian prefab!! - prefab is essentially the visual controller for the evil guy
{
    //this will be the main controller for the villains
    //it acts as a helper for initialising the villain prefabs
    //containing all information about each
    public string name;
    public Colours clothes_colour;
    public Colours skin_colour;
    public Colours shoe_colour;
    public Colours cape_colour;
    public Colours hat_colour;
    public int eye_type;
    public int hat_type;
    public int moustache_type;
    public int weapon_type;
    public int overlay_type;
    public bool main_villian;

    public static bool operator ==(EvilGuyStruct lhs, EvilGuyStruct rhs)
    {
        if (lhs.clothes_colour != rhs.clothes_colour)
        {
            return false;
        }
        if (lhs.skin_colour != rhs.skin_colour)
        {
            return false;
        }
        if (lhs.shoe_colour != rhs.shoe_colour)
        {
            return false;
        }
        if (lhs.eye_type != rhs.eye_type)
        {
            return false;
        }
        if (lhs.cape_colour != rhs.cape_colour)
        {
            return false;
        }
        if (lhs.hat_colour != rhs.hat_colour)
        {
            return false;
        }
        if (lhs.hat_type != rhs.hat_type)
        {
            return false;
        }
        if (lhs.moustache_type != rhs.moustache_type)
        {
            return false;
        }
        if (lhs.weapon_type != rhs.weapon_type)
        {
            return false;
        }
        if (lhs.overlay_type != rhs.overlay_type)
        {
            return false;
        }

        return true;
    }

    public static bool operator !=(EvilGuyStruct lhs, EvilGuyStruct rhs)
    {
        //dont use this
        return false;
    }

    public Similarity HowSimilar(EvilGuyStruct rhs)
    {
        Similarity amount = Similarity.NONE;
        int count = 0;

        if (clothes_colour == rhs.clothes_colour)
        {
            count++;
        }
        if (skin_colour == rhs.skin_colour)
        {
            count++;
        }
        if (shoe_colour == rhs.shoe_colour)
        {
            count++;
        }
        if (eye_type == rhs.eye_type)
        {
            count++;
        }
        if (cape_colour == rhs.cape_colour)
        {
            count++;
        }
        if (hat_colour == rhs.hat_colour)
        {
            count++;
        }
        if (hat_type == rhs.hat_type)
        {
            count++;
        }
        if (moustache_type == rhs.moustache_type)
        {
            count++;
        }
        if (weapon_type == rhs.weapon_type)
        {
            count++;
        }
        if (overlay_type == rhs.overlay_type)
        {
            count++;
        }

        if (count >= 4 && count <= 5)
        {
            amount = Similarity.SIMILAR;
        }
        if (count >= 6 && count <= 7)
        {
            amount = Similarity.VERY_SIMILAR;
        }
        if (count >= 8 && count <= 8)
        {
            amount = Similarity.VERY_VERY_SIMILAR;
        }
        if (count == 10)
        {
            amount = Similarity.EXACT_SAME;
        }


        return amount;
    }

    public void RandomiseVillain(bool main_villain = false)
    {
        name = GetRandomName();
        clothes_colour = (Colours)Random.Range(0, 10);
        skin_colour = (Colours)Random.Range(0, 4);
        shoe_colour = (Colours)Random.Range(0, 10);
        cape_colour = (Colours)Random.Range(0, 10);
        hat_colour = (Colours)Random.Range(0, 10);
        eye_type = Random.Range(0, GameController.num_eyes_);
        hat_type = Random.Range(0, GameController.num_hats_);
        moustache_type = Random.Range(0, GameController.num_moustaches_);
        weapon_type = Random.Range(0, GameController.num_weapons_);
        overlay_type = Random.Range(0, GameController.num_overlays_);
        main_villian = main_villain;
    }
    public string GetRandomName()
    {
        string newName = "";

        //TODO:: shit inbetween

        return newName;

    }
}

