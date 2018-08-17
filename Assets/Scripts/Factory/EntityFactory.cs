using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFactory : MonoBehaviour {
	static public EntityFactory instance;

    void Awake() {
        if (instance == null)
			instance = this;
		else
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
    }

    public GameObject Create(TypeOfEntity type) {
        switch (type) {
            case TypeOfEntity.Empty:
            case TypeOfEntity.Player:
                return Instantiate((GameObject)Resources.Load("Entity/Player"), Vector3.zero, new Quaternion(0, 0, 0, 1));
            default:
                return null;
        }
    }

    public void Recycle(GameObject obj) {
        Destroy(obj);
    }
}
