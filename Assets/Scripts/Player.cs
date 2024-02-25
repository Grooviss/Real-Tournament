using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text ammoText;
    [Header("Components")]
    public Health health;
    public Weapon weapon;
    public CameraShake Shake;
     void Start()
    {
        UpdateUI();
        weapon.onshoot.AddListener(UpdateUI);
       health.ondamage.AddListener(UpdateUI);
        health.ondie.AddListener(respawn);
    }

     void UpdateUI()
    {
        healthText.text = "HP: " + health.health;
        ammoText.text = weapon.clipAmmo + "/"  + weapon.ammo;
    }
   void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            health.Damage(10);

            
        }
    }
    void respawn()
    {
        health.health = health.maxHealth;
        transform.position = Vector3.zero;
        UpdateUI();
    }
}
