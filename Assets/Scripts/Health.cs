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
    public bool shouldDestroy = true;
    public GameObject DamageEffect;
    public GameObject DeathEffect;


    void Start()
    {
       
        if(health == 0) health = maxHealth;
    }


    public void Damage(int damage)
    {
        health -= damage;
        ondamage.Invoke();
        if (DamageEffect != null) Instantiate(DamageEffect, transform.position, Quaternion.identity);
        if (health <= 0)
        {
            Die();
        }
        if (health < 0) health = 0;
        
    }

    public void Die()
    {
        ondie.Invoke();
       if(shouldDestroy) Destroy(gameObject);
        if (DeathEffect != null) Instantiate(DeathEffect, transform.position, Quaternion.identity);
       

    }
}