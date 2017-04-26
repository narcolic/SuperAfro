using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Buffs : MonoBehaviour
{
    public Hero opponent;

    public Texture2D iceBuffFrame;
    public Rect iceBuffFramePosition;

    public Texture2D fireBuffFrame;
    public Rect fireBuffFramePosition;

    public Texture2D windBuffFrame;
    public Rect windBuffFramePosition;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(getScreenRectfortooltip(iceBuffFramePosition));
        //Debug.Log(Input.mousePosition);
        if (getScreenRectfortooltip(iceBuffFramePosition).Contains(Input.mousePosition))
        {
            Debug.Log("Inside");
        }
        if (getScreenRectfortooltip(fireBuffFramePosition).Contains(Input.mousePosition))
        {
            Debug.Log("Inside2");
        }
        if (getScreenRectfortooltip(windBuffFramePosition).Contains(Input.mousePosition))
        {
            Debug.Log("Inside3");
        }

    }

    private void OnGUI()
    {
        if (opponent.iceBuff)
        {
            GUI.DrawTexture(getScreenRect(iceBuffFramePosition), iceBuffFrame);

        }
        if (opponent.fireBuff)
        {
            GUI.DrawTexture(getScreenRect(fireBuffFramePosition), fireBuffFrame);
        }
        if (opponent.windBuff)
        {
            GUI.DrawTexture(getScreenRect(windBuffFramePosition), windBuffFrame);
        }
    }

    Rect getScreenRect(Rect rPostition)
    {
        return new Rect(Screen.width * rPostition.x, Screen.height * rPostition.y, Screen.width * rPostition.width, Screen.height * rPostition.height);
    }
    Rect getScreenRectfortooltip(Rect rPostition)
    {
        return new Rect(Screen.width * rPostition.x, Screen.height - ((Screen.height * rPostition.y) + Screen.height * rPostition.height), Screen.width * rPostition.width, Screen.height * rPostition.height);
    }
}
