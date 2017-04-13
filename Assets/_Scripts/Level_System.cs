using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_System : MonoBehaviour
{

    public int level;
    public int exp;
    public Hero player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        levelUp();
    }

    void levelUp()
    {
        if (exp >= nextLevelExp())
        {
            level += 1;
            levelUpStats();
            exp = exp - (int)nextLevelExp();
            player.health = player.maxHealth;
            
        }
    }

    public float nextLevelExp()
    {
        return Mathf.Pow(level, 3) + 100;
    }


    void levelUpStats()
    {
        //TODO: add math stats
        player.maxHealth += 50;
        player.damage += 10;
    }
}
