using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfWeapon{
	Fist = 0
}

public class WeaponBuilder : MonoBehaviour {
	public static WeaponBuilder instance;
	private GameObject weaponObj;

	void Awake(){
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}
	

	public GameObject Build(TypeOfWeapon type){
        weaponObj = WeaponFactory.instance.Create(type);
		weaponObj.layer = Layers.Weapon;
		
		switch (type)
		{
			default:
			return weaponObj;

			case TypeOfWeapon.Fist:

			weaponObj.name = "Fist";
			WeaponManager manager = weaponObj.AddComponent<WeaponManager>();
			MeleeWeapon weapon = weaponObj.AddComponent<MeleeWeapon>();
			manager.Build(weapon);
			weapon.Build(new Vector2(0.2f, 0.25f), 0.1f);
        	
			
			return weaponObj;
		}
		
		
	}
}
