using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth1 : MonoBehaviour
{
   
    public int maxHealth = 500;
	public int currentHealth;
    public HealthBar healthBar;

	public Animator animator;

	public GameObject deathEffect;

	public bool isInvulnerable = false;


    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }
	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		currentHealth -= damage;

		 animator.SetTrigger("Hurt");

		 healthBar.SetHealth(currentHealth);

		if (currentHealth <= 200)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
			Debug.Log("engraded attacking");
		}

		if (currentHealth <= 0)
		{
			Die();
		}
	}

    public void getHealth(int currentHealth)
	{
		currentHealth =+3;
		healthBar.SetMaxHealth(currentHealth);
	}
	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
		  //die animation
        Debug.Log("Enemy died");
        animator.SetBool("Dead",true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled=false;
	}





}
