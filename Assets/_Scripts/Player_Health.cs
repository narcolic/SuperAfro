using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public Hero myPlayer;
    public float healthPercentage;

    public float height;

    public Image healthBar;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        healthPercentage = (float)myPlayer.health / myPlayer.maxHealth;
        healthBar.fillAmount = healthPercentage;
    }


}
