using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    public int health { get; private set; }
	public int maxHealth { get; private set; }

    public void SetHealthAndMaxHealth(int initHealth, int max = 1){
		if (initHealth < 1) initHealth = 1;
		health = initHealth;
		if (health > max) max = health;
		maxHealth = max;
	}

	public void ReciveDamage(int amount){
		if (amount <= 0) return;
		health = (health > amount) ? health - amount : 0;
	}

	public void Heal(int amount){
		if (amount <= 0) return;
		health = (health + amount < maxHealth) ? health + amount : maxHealth;
	}
}
