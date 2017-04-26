using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    //public CharacterController controller;

    public GameObject opponent;
    private GameObject burningGround;

    private bool burningGroundSkillActive;

    public AnimationClip attack;
    public AnimationClip die;
    private Animator anim;
    bool started;
    bool ended;

    public int damage;
    public int health;
    public int maxHealth;
    private double maxHealth5Percent;
    private bool impacted;
    public bool inAction;
    private float timer;
    private float cooldown;

    public float range;

    public float outOfCombatTime;
    public float countDown;

    public bool specialAttack;

    public bool iceBuff;
    public bool fireBuff;
    public bool windBuff;

    // Use this for initialization
    void Start()
    {
        cooldown = 0.7f;
        anim = GetComponent<Animator>();
        health = maxHealth;
        burningGround = GameObject.FindGameObjectWithTag("skill3");
        burningGround.SetActive(false);
        burningGroundSkillActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("buffs " + iceBuff);
        maxHealth5Percent = 0.05 * maxHealth;
        if (Input.GetKey(KeyCode.Space) && enemyInRange() && !specialAttack)
        {
            inAction = true;
        }

        if (inAction)
        {
            if (attackFunction(0, 1, KeyCode.Space, true))
            {

            }
            else
            {
                inAction = false;
            }
        }
        if (burningGroundSkillActive)
        {
            if (Time.time > timer)
            {
                timer = Time.time + cooldown;
                if (health > maxHealth5Percent)
                {
                    health -= (int)maxHealth5Percent;
                }
                else
                {
                    health = 1;
                }
            }
        }

        dieAction();
        //Debug.Log(this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }

    public bool attackFunction(int stunSeconds, double scaledDamage, KeyCode key, bool opponentBased)
    {
        if (opponentBased)
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
        }
        else
        {
            if (Input.GetKey(key))
            {
                if (!burningGroundSkillActive)
                {
                    burningGround.SetActive(true);
                    burningGroundSkillActive = true;
                }
                else
                {
                    burningGround.SetActive(false);
                    burningGroundSkillActive = false;
                }
                Click_To_Move.atck = true;
            }
        }

        if (this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f)
        {
            Click_To_Move.atck = false;
            impacted = false;
            if (specialAttack)
            {
                specialAttack = false;
            }
            return false;
        }
        impact(stunSeconds, scaledDamage, opponentBased);
        return true;
    }

    public void resetAttackFunction()
    {
        Click_To_Move.atck = false;
        impacted = false;
        //anim.Stop();
    }

    void impact(int stunSeconds, double scaledDamage, bool opponentBased)
    {
        if ((!opponentBased || opponent != null) && this.anim.GetCurrentAnimatorStateInfo(0).IsName(attack.name) && !impacted)
        {
            if (this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f && this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.7f)
            {
                countDown = outOfCombatTime + 2;
                CancelInvoke("outOfCombatCountDown");
                InvokeRepeating("outOfCombatCountDown", 0, 1);
                if (opponentBased)
                {
                    opponent.GetComponent<Mob>().getHit((damage * scaledDamage));
                    opponent.GetComponent<Mob>().getStun(stunSeconds);
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
