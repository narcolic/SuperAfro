using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{

    public float speed;
    public float range;
    public float chaseRange;
    public CharacterController controller;
    public Transform player;
    private Hero opponent;

    public AnimationClip run;
    public AnimationClip idle;
    public AnimationClip die;
    public AnimationClip attack;
    private Animator anim;

    public int maxHealth;
    public int health;
    public int damage;
    public int mobXP;
    private bool impacted;
    private bool stun;

    public int stunTime;

    public Level_System playerLvl;

    public float dieTime = 2.0f;

    // Use this for initialization
    void Start()
    {
        health = maxHealth;
        anim = GetComponent<Animator>();
        opponent = player.GetComponent<Hero>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead())
        {
            if (stunTime <= 0)
            {
                if (!inRange() && inChaseRange())
                {
                    chasePlayer();
                }
                else if (!inRange() && !inChaseRange())
                {
                    anim.Play(idle.name);
                }
                else
                {
                    anim.Play(attack.name);
                    mobAttack();
                    if (this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f)
                    {
                        impacted = false;
                    }
                }
            }
            //Debug.Log(impacted);
        }
        else
        {
            dieAction();
        }
    }

    bool inRange()
    {
        if (Vector3.Distance(transform.position, player.position) < range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool inChaseRange()
    {
        if (Vector3.Distance(transform.position, player.position) < chaseRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void chasePlayer()
    {

        transform.LookAt(player.position);
        controller.SimpleMove(transform.forward * speed);
        anim.Play(run.name);
    }

    private void OnMouseOver()
    {
        player.GetComponent<Hero>().opponent = gameObject;
    }

    public void getHit(double damage)
    {
        health -= (int)damage;
        if (health < 0)
        {
            health = 0;
        }
    }

    public void getStun(int seconds)
    {
        CancelInvoke("stunCountDown");
        stunTime = seconds;
        InvokeRepeating("stunCountDown", 0f, 1f);
    }

    void stunCountDown()
    {
        stunTime = stunTime - 1;

        if (stunTime == 0)
        {
            CancelInvoke("stunCountDown");
        }
    }

    bool isDead()
    {
        if (health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void dieAction()
    {
        anim.Play(die.name);
        if (Time.time > dieTime)
        {
            playerLvl.exp += mobXP;
            Destroy(gameObject);
        }
        if (gameObject.tag == "boss1")
        {
            opponent.iceBuff = true;
        }
        if (gameObject.tag == "boss2")
        {
            opponent.fireBuff = true;
        }
        if (gameObject.tag == "boss3")
        {
            opponent.windBuff = true;
        }

    }

    void mobAttack()
    {
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName(attack.name) && !impacted && this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.7f)
        {
            impacted = true;
            opponent.getHit(damage);
        }

    }
}
