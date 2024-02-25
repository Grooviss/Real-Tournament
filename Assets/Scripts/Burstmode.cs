using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burstmode : MonoBehaviour
{
    public Weapon weapon;
    public bool isburstfire;
    private void Start()
    {
        weapon.onRightClick.AddListener(burstfire);
    }
    public void burstfire()
    {
        isburstfire = !isburstfire;
        if(isburstfire)
        {
            weapon.multiMode = 7;
            weapon.isAutoFire = false;
        }
        else
        {
            weapon.multiMode = 1;
            weapon.isAutoFire = true;
        }
       
        
        
    }
}
