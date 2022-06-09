using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
  public Animator animator;

  public int attackDamage=50;
  public Transform AttackPoint;
  public float AttackRange=0.4f;
  public LayerMask EnemyLayers;

  

  public float attackRate=2f;
  float nextAttackTime=0f;
    void Update()
    {

        if(Time.time>=nextAttackTime)
        {
              if(Input.GetKeyDown(KeyCode.Mouse0))
              {
                 Attack();
                 nextAttackTime = Time.time+ 1f/attackRate;
               }
        }
       
    
    }

    void Attack()
        {
            //Play an attack animation
            animator.SetTrigger("Attack");

            
            //Detect enemies in range of attack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);

            //Damage them 
            foreach(Collider2D enemy in hitEnemies)
            {
                Debug.Log("We hit" + enemy.name);
                enemy.GetComponent<BossHealth1>().TakeDamage(attackDamage);
            }

        }

    void OnDrawGizmosSelected()
     {
        if(AttackPoint==null)
        
         return;
        
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);

        
     }

}

