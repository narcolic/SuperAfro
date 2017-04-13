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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        DrawActionBar();
    }

    private void DrawActionBar()
    {
        GUI.DrawTexture(new Rect(Screen.width * position.x, Screen.height * position.y, Screen.width * position.width, Screen.height * position.height), actionBar);
        GUI.DrawTexture(new Rect(Screen.width * actionBarOverlayPosition.x, Screen.height * actionBarOverlayPosition.y, Screen.width * actionBarOverlayPosition.width, Screen.height * actionBarOverlayPosition.height), actionBarOverlay);
    }
}
