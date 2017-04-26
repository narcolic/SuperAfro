using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill_Slot
{

    public Player_SpecialAttack skill;
    public Rect position;
    public KeyCode key;

    public void setKey(KeyCode keyCode)
    {
        if (skill != null)
        {
            skill.key = keyCode;
        }
    }
}
