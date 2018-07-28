using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfEntity{
		Empty = 0,
		Player
	}

public class EntityBuilder : MonoBehaviour {
	public static EntityBuilder instance;
	private GameObject entity;
	
	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}
	

	public GameObject Build(TypeOfEntity type)
	{
        entity = EntityFactory.instance.Create(type);

		switch (type)
		{
			default:
			case TypeOfEntity.Empty:
			return entity;

			case TypeOfEntity.Player:
			
			entity.name = "Player";
			entity.layer = Layers.Player;
			Player player = entity.AddComponent<Player>();
			GameObject weapon = WeaponBuilder.instance.Build(TypeOfWeapon.Fist);
			weapon.transform.parent = entity.transform;
			player.SetWeaponManager(weapon.GetComponent<WeaponManager>());
			
			return entity;
		}
	}
}
