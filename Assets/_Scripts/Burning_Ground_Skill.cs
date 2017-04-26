using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning_Ground_Skill : MonoBehaviour
{

    private float timer;
    private float cooldown = 0.7f;
    private double maxHealth10percent;
    private double maxHealth5PercentHero;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            if (Time.time > timer)
            {
                timer = Time.time + cooldown;
                if (other.GetComponent<Mob>().health > 0)
                {
                    maxHealth10percent = 0.1 * other.GetComponent<Mob>().maxHealth;
                    other.GetComponent<Mob>().health -= (int)maxHealth10percent;
                }
            }
        }
    }
}
