using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    private float timeBtwAttack = 0;
    public float startTimeBtwAttack;
    public Animator animator;

    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;

    void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if(Input.GetKey(KeyCode.Mouse0))
            {
                animator.SetTrigger("Attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                Debug.Log(enemiesToDamage.Length);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyAI>().TakeDamage(damage);
                }
                timeBtwAttack = startTimeBtwAttack;
            }
            
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
