﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LVL : MonoBehaviour
{
    public Level_System expStats;

    public Texture2D frame;
    public Rect framePosition;
    public Rect levelArea;

    public Texture2D nextLevelFrame;
    public Rect nextLevelFramePosition;
    public Rect nextLevelArea;

    public int currentLevel;
    public int nextLevel;
    private GUIStyle guiStyle;

    // Use this for initialization
    void Start()
    {
        guiStyle = new GUIStyle();
    }

    // Update is called once per frame
    void Update()
    {
        currentLevel = expStats.level;
        nextLevel = currentLevel + 1;
    }

    private void OnGUI()
    {
        drawLevelFrame();
        drawNextLevelFrame();
    }

    private void drawNextLevelFrame()
    {
        nextLevelFramePosition.x = Screen.width - nextLevelFramePosition.width;
        nextLevelFramePosition.y = framePosition.y;

        nextLevelFramePosition.width = framePosition.width;
        nextLevelFramePosition.height = framePosition.height;

        nextLevelArea = new Rect(nextLevelFramePosition.x + Screen.width * 0.01f, nextLevelFramePosition.y + Screen.height * 0.01f, nextLevelFramePosition.width, nextLevelFramePosition.height);

        guiStyle.fontSize = 25;
        guiStyle.normal.textColor = Color.white;
        GUI.DrawTexture(nextLevelFramePosition, nextLevelFrame);
        GUI.Label(nextLevelArea, nextLevel.ToString(), guiStyle);
    }

    private void drawLevelFrame()
    {
        framePosition.x = 0;
        framePosition.y = Screen.height - framePosition.height;

        framePosition.width = Screen.width * 0.04f;
        framePosition.height = Screen.height * 0.05f;

        levelArea = new Rect(framePosition.x + Screen.width * 0.01f, framePosition.y + Screen.height * 0.01f, framePosition.width, framePosition.height);

        guiStyle.fontSize = 25;
        guiStyle.normal.textColor = Color.white;
        GUI.DrawTexture(framePosition, frame);
        GUI.Label(levelArea, currentLevel.ToString(), guiStyle);
    }
}
