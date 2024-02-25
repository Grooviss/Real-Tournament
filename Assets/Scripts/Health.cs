using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public UnityEvent ondamage;
    public UnityEvent ondie;


    void Start()
    {
        if(health == 0) health = maxHealth;
    }


    public void Damage(int damage)
    {
        health -= damage;
        ondamage.Invoke();
        if (health <= 0)
        {
            Die();
        }
        
    }

    public void Die()
    {
        ondie.Invoke();
        Destroy(gameObject);
        
    }
}