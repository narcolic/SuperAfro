﻿using UnityEngine;
using System.Collections;

public class Player_SpecialAttack : MonoBehaviour
{
    public Hero player;
    public KeyCode key;
    public double damagePercentage;
    public int stunTime;
    public bool inAction;
    public bool opponentBased;

    public Texture2D pictureOfSkill;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) && !player.specialAttack)
        {
            player.resetAttackFunction();
            player.specialAttack = true;
            inAction = true;
        }

        if (inAction)
        {
            if (player.attackFunction(stunTime, damagePercentage, key, opponentBased))
            {

            }
            else
            {
                inAction = false;
            }

        }
    }
}
