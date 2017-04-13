using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public Hero player;
    public Mob target;
    public float healthPrcnt;

    public Texture2D frame;
    public Rect framePosition;

    public float width;

    public Texture2D healthbar;
    public Rect healthBarPosition;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player.opponent != null)
        {
            target = player.opponent.GetComponent<Mob>();
            healthPrcnt = (float)target.health / target.maxHealth;
        }
        else
        {
            healthPrcnt = 0;
            target = null;
        }

    }

    private void OnGUI()
    {
        if (target != null && player.countDown > 0)
        {
            drawFrame();
            drawHealthBar();
        }
    }

    private void drawHealthBar()
    {
        healthBarPosition.x = framePosition.x;
        healthBarPosition.y = framePosition.y;
        healthBarPosition.width = framePosition.width * width * healthPrcnt;
        healthBarPosition.height = framePosition.height;

        GUI.DrawTexture(healthBarPosition, healthbar);
    }

    private void drawFrame()
    {
        framePosition.x = (Screen.width - framePosition.width) / 2;
        framePosition.width = Screen.width * 0.16f;
        framePosition.height = Screen.height * 0.04f;

        GUI.DrawTexture(framePosition, frame);
    }

}
