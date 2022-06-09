using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickableType { ITEM }

public class Items : MonoBehaviour
{
   [SerializeField] private PickableType type;
    [SerializeField] private int health = 0;
    [SerializeField] private int spike = 0;    
    bool isCollected = false;

    BossHealth1 boss;
 
    private void Update()
    {
        if (isCollected)
        {
            if (type.Equals(PickableType.ITEM))
            {
                boss.getHealth(health);
            }
            else if (type.Equals(PickableType.ITEM))
            {
                boss.TakeDamage(spike);
            }
            Destroy(gameObject);
        }
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.tag.Equals("Enemy"))
            isCollected = true;
    }
}
