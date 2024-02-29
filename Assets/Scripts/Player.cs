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
    public LayerMask WeaponLayer;
    public GameObject GrabText;
    public Transform hand;
     void Update()
    {
        var cam = Camera.main.transform;
        var collided = Physics.Raycast(cam.position, cam.forward,out var hit, 2f, WeaponLayer);
        GrabText.SetActive(!weapon && collided);
        
            if(Input.GetKeyDown(KeyCode.E))
            {
                
                if(weapon == null && collided)
                {
                    Grab(hit.collider.gameObject);
                }
                else
                {
                    Drop();
                }
            }
        
        if (weapon == null) return;
        if (!weapon.isAutoFire && Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapon.Shoot();
        }

        // auto mode
        if (weapon.isAutoFire && Input.GetKey(KeyCode.Mouse0))
        {
            weapon.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && weapon.ammo < weapon.maxAmmo)
        {
            weapon.Reload();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            weapon.onRightClick.Invoke();
        }
    }
    public void Grab(GameObject gun)
    {
        if (weapon != null) return;
       
        weapon.GetComponent<Rigidbody>().isKinematic = true;
        weapon = gun.GetComponent<Weapon>();
        weapon.transform.position = hand.position;
        weapon.transform.position = hand.position;
        weapon.transform.parent = hand;
    }
    public void Drop()
    {
        if (weapon == null) return;
        weapon.transform.parent = null;
        weapon = null;
        weapon.GetComponent<Rigidbody>().isKinematic = false;
    }
    void Start()
    {
        UpdateUI();
        weapon.onshoot.AddListener(UpdateUI);
       health.ondamage.AddListener(UpdateUI);
        health.ondie.AddListener(respawn);
    }

     void UpdateUI()
    {
        //healthText.text = "HP: " + health.health;
        //ammoText.text = weapon.clipAmmo + "/"  + weapon.ammo;
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
