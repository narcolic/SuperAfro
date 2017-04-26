using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_EXP : MonoBehaviour
{
    public Level_System expStats;

    public Hero player;
    public float expPercentage;

    public Texture2D frame;
    public Rect framePosition;

    public float width;

    public Texture2D expBar;
    public Rect expBarPosition;

    public Texture2D expPercentageBar;
    public Rect expPercentageBarPosition;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        expPercentage = expStats.exp / expStats.nextLevelExp();
    }

    private void OnGUI()
    {
        drawFrame();
        drawExpBar();
        drawExpPercentageFrame();
    }

    private void drawExpBar()
    {
        expBarPosition.x = framePosition.x;
        expBarPosition.y = framePosition.y;
        expBarPosition.width = framePosition.width * width * expPercentage;
        expBarPosition.height = framePosition.height;

        GUI.DrawTexture(expBarPosition, expBar);
    }

    private void drawFrame()
    {
        framePosition.x = Screen.width * 0.037f;
        framePosition.y = Screen.height - framePosition.height;
        framePosition.width = Screen.width - Screen.width * 0.075f;
        framePosition.height = Screen.height * 0.02f;

        GUI.DrawTexture(framePosition, frame);
    }

    private void drawExpPercentageFrame()
    {
        expPercentageBarPosition.x = framePosition.x;
        expPercentageBarPosition.y = framePosition.y;
        expPercentageBarPosition.width = framePosition.width;
        expPercentageBarPosition.height = framePosition.height;

        GUI.DrawTexture(expPercentageBarPosition, expPercentageBar);
    }
}
