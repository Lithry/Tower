using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfWeapon{
	Empty = 0,
	Fist,
	_1000sReloadToTest
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
		WeaponManager manager = weaponObj.AddComponent<WeaponManager>();
		MeleeWeapon weapon = weaponObj.AddComponent<MeleeWeapon>();
		
		switch (type)
		{
			default:
			return weaponObj;

			case TypeOfWeapon.Empty:
			weaponObj.name = "Empty";
			manager.Build(weapon, type);
			weapon.Build(new Vector2(0f, 0f), 0f);
			return weaponObj;

			case TypeOfWeapon.Fist:
			weaponObj.name = "Fist";
			manager.Build(weapon, type);
			weapon.Build(new Vector2(8f, 8f), 0.3f);
			return weaponObj;

			case TypeOfWeapon._1000sReloadToTest:
			weaponObj.name = "Empty";
			manager.Build(weapon, type);
			weapon.Build(new Vector2(0f, 0f), 1000.0f);
			return weaponObj;
		}	
	}
}
