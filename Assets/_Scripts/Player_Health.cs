using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public Hero myPlayer;
    public float healthPercentage;

    //public Texture2D frame;
    //public Rect framePosition;

    public float height;

    public Image healthBar;
    // public Rect healthBarPosition;

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

    //private void OnGUI()
    //{
    //    GUI.DrawTexture(getScreenRect(framePosition), frame);
    //}

    //Rect getScreenRect(Rect rPostition)
    //{
    //    return new Rect(Screen.width * rPostition.x, Screen.height * rPostition.y, Screen.width * rPostition.width, Screen.height * rPostition.height);
    //}
}
