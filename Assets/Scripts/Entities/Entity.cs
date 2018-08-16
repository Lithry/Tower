using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    public int health { get; private set; }
	public int maxHealth { get; private set; }

    public void SetHealthAndMaxHealth(int initHealth, int max = 1){
		if (initHealth < 1) throw new System.ArgumentOutOfRangeException("Entity | SetHealthAndMaxHealth() -> initHealth >= 1");
		health = initHealth;
		if (health > max) max = health;
		maxHealth = max;
	}

	public void ReciveDamage(int amount){
		if (amount <= 0) throw new System.ArgumentOutOfRangeException("Entity | ReciveDamage() -> amount > 0");
		health = (health > amount) ? health - amount : 0;
	}

	public void Heal(int amount){
		if (amount <= 0) throw new System.ArgumentOutOfRangeException("Entity | Heal() -> amount > 0");
		health = (health + amount < maxHealth) ? health + amount : maxHealth;
	}
}