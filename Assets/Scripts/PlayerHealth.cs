using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public int maxHealth = 100;
	public int currentHealth;
    public Animator animator;
	public HealthBar healthBar;

	public GameObject deathEffect;
  // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
       
	   healthBar.SetHealth(currentHealth);

		animator.SetTrigger("Hurt");
        
		Debug.Log("Taking Damage");

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Debug.Log("Player died");
        animator.SetBool("IsDead",true);

	}

	IEnumerator DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < 3; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);
		}
    }
}
