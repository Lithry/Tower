using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory : MonoBehaviour {
	static public WeaponFactory instance;
    public GameObject weaponPrefab;

    void Awake() {
        if (instance == null)
			instance = this;
		else
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
    }

    public GameObject Create(TypeOfWeapon type) {
        switch (type) {
            case TypeOfWeapon.Fist:
                return Instantiate(weaponPrefab);
            default:
                return null;
        }
    }

    public void Recycle(GameObject obj) {
        Destroy(obj);
    }
}
