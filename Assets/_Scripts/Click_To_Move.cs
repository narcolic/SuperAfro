using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_To_Move : MonoBehaviour
{
    public AnimationClip run;
    public AnimationClip idle;
    private Animator anim;

    private Vector3 position;
    public CharacterController controller;
    public float speed;

    public static bool atck;
    public static bool die;

    public static Vector3 cursorPosition;

    // Use this for initialization
    void Start()
    {
        position = transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        locateCursorPosition();
        if (!atck && !die)
        {
            if (Input.GetMouseButton(0))
            {
                locateUserPosition();
            }

            moveToPosition();
        }
        else
        {

        }
    }

    private void locateUserPosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.tag != "Player" && hit.collider.tag != "enemy" && hit.collider.tag != "boss")
            {
                position = new Vector3(hit.point.x, hit.point.y + 1.7f, hit.point.z);
            }
        }
    }
    private void locateCursorPosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            cursorPosition = hit.point;
        }
    }

    void moveToPosition()
    {
        if (Vector3.Distance(transform.position, position) > 1)
        {
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position);

            newRotation.x = 0f;
            newRotation.z = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
            controller.SimpleMove(transform.forward * speed);

            anim.Play(run.name);
        }
        else
        {
            anim.Play(idle.name);
        }
    }
}
