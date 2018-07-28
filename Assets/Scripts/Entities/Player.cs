using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
	private WeaponManager weapon;

	void Start(){}

	public void SetWeaponManager(WeaponManager wep){
		weapon = wep;
	}

	public bool Attack(){
		return weapon.Attack();
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Mouse0))
			Attack();
	}
}
