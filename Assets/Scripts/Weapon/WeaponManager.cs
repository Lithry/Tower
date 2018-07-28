using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Weapon weapon;

    void Start(){}

    public void Build(Weapon wep){
        weapon = wep;
    }

    public bool Attack(){
        return weapon.Attack();
    }
}
