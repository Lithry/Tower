using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory : MonoBehaviour {
	static public WeaponFactory instance;

    void Awake() {
        if (instance == null)
			instance = this;
		else
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
    }

    public GameObject Create(TypeOfWeapon type) {
        switch (type) {
            case TypeOfWeapon.Empty:
            case TypeOfWeapon._1000sReloadToTest:
            case TypeOfWeapon.Fist:
                return Instantiate((GameObject)Resources.Load("Weapon/Weapon"));
            default:
                return null;
        }
    }

    public void Recycle(GameObject obj) {
        Destroy(obj);
    }
}
