using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ActionBar : MonoBehaviour
{
    public Texture2D actionBar;
    public Rect position;

    public Texture2D actionBarOverlay;
    public Rect actionBarOverlayPosition;

    public int numberOfSkills;

    public Player_Skill_Slot[] skill;

    public float skillX;
    public float skillY;
    public float skillWidth;
    public float skillHeight;
    public float skillDistance;

    // Use this for initialization
    void Start()
    {
        //skill = new Player_Skill_Slot[numberOfSkills];
        init();
    }

    void init()
    {
        Player_SpecialAttack[] attacks = GameObject.FindGameObjectWithTag("Player").GetComponents<Player_SpecialAttack>();

        skill = new Player_Skill_Slot[attacks.Length];
        for (int i = 0; i < attacks.Length; i++)
        {
            skill[i] = new Player_Skill_Slot();
            skill[i].skill = attacks[i];
        }

        skill[0].setKey(KeyCode.Q);
        skill[1].setKey(KeyCode.W);
        skill[2].setKey(KeyCode.E);
    }

    // Update is called once per frame
    void Update()
    {
        updateSkillSlots();
    }

    private void updateSkillSlots()
    {
        for (int i = 0; i < skill.Length; i++)
        {
            skill[i].position.Set(skillX + i * (skillWidth + skillDistance), skillY, skillWidth, skillHeight);

        }
    }

    private void OnGUI()
    {
        GUI.DrawTexture(getScreenRect(position), actionBar);
        DrawSkillSlot();
        GUI.DrawTexture(getScreenRect(actionBarOverlayPosition), actionBarOverlay);
    }

    private void DrawSkillSlot()
    {
        for (int i = 0; i < skill.Length; i++)
        {
            GUI.DrawTexture(getScreenRect(skill[i].position), skill[i].skill.pictureOfSkill);
            //Debug.Log(skill[i].position);
        }
    }

    Rect getScreenRect(Rect rPostition)
    {
        return new Rect(Screen.width * rPostition.x, Screen.height * rPostition.y, Screen.width * rPostition.width, Screen.height * rPostition.height);
    }
}
