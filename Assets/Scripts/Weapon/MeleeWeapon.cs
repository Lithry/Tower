using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
	public BoxCollider2D areaOfEffect { get; private set; }
	private GameObject colliderObj;

	void Start(){}

    public void Build(Vector2 sizeAreaOfEffect, float timeToReload = 0){
		base.Build(timeToReload);
		
		if (gameObject.GetComponent<BoxCollider2D>() == null)
			areaOfEffect = gameObject.AddComponent<BoxCollider2D>();
		else
			areaOfEffect = gameObject.GetComponent<BoxCollider2D>();
		
		areaOfEffect.isTrigger = true;
		areaOfEffect.size = sizeAreaOfEffect;
		areaOfEffect.enabled = false;
	}

	public override bool Attack(){
		if (base.Attack()){
			areaOfEffect.enabled = true;
			Invoke("ChangeEnabledToFalse", reloadTime);
			return true;
		}
		return false;
	}

	private void ChangeEnabledToFalse(){
		areaOfEffect.enabled = false;
	}
}
