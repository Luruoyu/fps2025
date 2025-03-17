using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private int HP;
    private Animator m_Animator;
    private float m_Power = 500;
    private float m_AttackLoopTime = 0.5f;
    private bool m_IsAttacking;
    private bool m_WasAttacking = false;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        HP = 1000;
        m_Animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("MainCamera");
        }
        if (HP <= 0)
        {
            Dead();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hurt"></param>
    public void Hit(int hurt)
    {
        HP -= hurt;
    }

    /// <summary>
    /// 
    /// </summary>
    private void Dead()
    {
        DeadAnimation();
        m_IsAttacking = false;
        m_WasAttacking = false;
        Destroy(this.gameObject, 2.0f);
    }

    public void Attack()
    {
        AttackAnimation();
        m_IsAttacking = true;
        if (m_WasAttacking == false)
        {
            StartCoroutine(Attack2());
        }
        m_WasAttacking = true;
    }

    public void Walk()
    {
        m_IsAttacking = false;
        m_WasAttacking = false;
        WalkAnimation();
    }

    private void DeadAnimation()
    {
        m_Animator.SetBool("isDead", true);
        m_Animator.SetBool("isWalking", false);
        m_Animator.SetBool("isAttacking", false);
    }

    private void WalkAnimation()
    {
        m_Animator.SetBool("isDead", false);
        m_Animator.SetBool("isWalking", true);
        m_Animator.SetBool("isAttacking", false);
    }

    private void AttackAnimation()
    {
        m_Animator.SetBool("isDead", false);
        m_Animator.SetBool("isWalking", false);
        m_Animator.SetBool("isAttacking", true);
    }

    IEnumerator Attack2()
    {
        // 目前的问题：会一直循环调用
        while (true)
        {
            yield return new WaitForSeconds(m_AttackLoopTime);            
            if (m_IsAttacking == false)
            {
                yield break;
            }
            Debug.Log(player.gameObject.name);
            player.GetComponent<PlayerController>().GetAttack(m_Power);
        }
    }
}
