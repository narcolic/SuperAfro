using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mist_Health_Reduction_Wind : MonoBehaviour
{

    public Hero hero;
    private float timer;
    private float cooldown = 0.7f;
    private double maxHealth10percent;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        maxHealth10percent = 0.1 * hero.maxHealth;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player") && !hero.windBuff)
        {
            if (Time.time > timer)
            {
                timer = Time.time + cooldown;
                if (hero.health > 0)
                {
                    hero.health -= (int)maxHealth10percent;
                }
            }
        }
    }
}
