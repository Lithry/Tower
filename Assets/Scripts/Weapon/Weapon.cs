using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public float reloadTime { get; private set; }
	public float timeOfShot { get; private set; }

	public void Build(float timeToReload = 0.0f){
		reloadTime = timeToReload;
		timeOfShot = 0;
	}

	public virtual bool Attack(){
		if (Time.time - timeOfShot > reloadTime){
			timeOfShot = Time.time;
			return true;
		}
		return false;
	}
}
