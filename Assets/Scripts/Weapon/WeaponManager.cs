using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Weapon weapon;
    private TypeOfWeapon type;

    void Start(){}

    public void Build(Weapon wep, TypeOfWeapon type){
        weapon = wep;
        this.type = type;
    }

    public bool Attack(){
        return weapon.Attack();
    }

    public TypeOfWeapon GetTypeOfWeapon(){
        return type;
    }
}
