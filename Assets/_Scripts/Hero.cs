using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    //public CharacterController controller;

    public GameObject opponent;

    public AnimationClip attack;
    public AnimationClip die;
    private Animator anim;
    bool started;
    bool ended;

    public int damage;
    public int health;
    public int maxHealth;
    private bool impacted;
    public bool inAction;

    public float range;

    public float outOfCombatTime;
    public float countDown;

    public bool specialAttack;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hero Health: " + health);
        if (Input.GetKey(KeyCode.Space) && enemyInRange() && !specialAttack)
        {
            //anim.Play(attack.name);
            //Click_To_Move.atck = true;
            //if (opponent != null)
            //{
            //    transform.LookAt(opponent.transform.position);
            //}
            inAction = true;
        }

        if (inAction)
        {
            if (attackFunction(0, 1, KeyCode.Space, null))
            {

            }
            else
            {
                inAction = false;
            }
        }
        dieAction();

        //if (this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
        //{
        //    Click_To_Move.atck = false;
        //    impacted = false;
        //}

        //dieAction();
        //impact();
    }

    public bool attackFunction(int stunSeconds, double scaledDamage, KeyCode key, GameObject particleEffect)
    {
        if (Input.GetKey(key) && enemyInRange())
        {
            anim.Play(attack.name);
            Click_To_Move.atck = true;

            if (opponent != null)
            {
                transform.LookAt(opponent.transform.position);
            }
        }

        if (this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f)
        {
            Click_To_Move.atck = false;
            impacted = false;
            if (specialAttack)
            {
                specialAttack = false;
            }
            return false;
        }
        impact(stunSeconds, scaledDamage, particleEffect);
        return true;
    }

    public void resetAttackFunction()
    {
        Click_To_Move.atck = false;
        impacted = false;
        anim.Stop();
    }

    void impact(int stunSeconds, double scaledDamage, GameObject particleEffect)
    {
        if (opponent != null && this.anim.GetCurrentAnimatorStateInfo(0).IsName(attack.name) && !impacted)
        {
            if (this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.45f && this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.8f)
            {
                countDown = outOfCombatTime + 2;
                CancelInvoke("outOfCombatCountDown");
                InvokeRepeating("outOfCombatCountDown", 0, 1);
                opponent.GetComponent<Mob>().getHit((damage * scaledDamage));
                opponent.GetComponent<Mob>().getStun(stunSeconds);
                if (particleEffect != null)
                {
                    Instantiate(particleEffect, new Vector3(opponent.transform.position.x, opponent.transform.position.y + 1.5f, opponent.transform.position.z), Quaternion.identity);
                }
                impacted = true;
            }
        }
    }

    bool enemyInRange()
    {
        bool isInRange = false;
        if (opponent != null)
        {
            if (Vector3.Distance(opponent.transform.position, transform.position) <= range)
            {
                isInRange = true;
                return isInRange;
            }
            else
            {
                return isInRange;
            }
        }

        return isInRange;
    }

    public void getHit(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
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
        if (isDead() && !ended)
        {
            if (!started)
            {
                anim.Play(die.name);
                started = true;
                Click_To_Move.die = true;
            }

            if (started && !this.anim.GetCurrentAnimatorStateInfo(0).IsName(die.name))
            {
                //Action when hero dies.
                Debug.Log("You died!");
                health = maxHealth;

                ended = true;
                started = false;
                Click_To_Move.die = false;
            }
        }
    }

    void outOfCombatCountDown()
    {
        countDown -= 1;
        if (countDown == 0)
        {
            CancelInvoke("outOfCombatCountDown");
        }
    }
}
