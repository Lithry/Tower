using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
	private WeaponManager weapon;
	private Rigidbody2D rb;
	private Animator anim;
	[SerializeField] private int speed = 10;
	private GameObject sword;
	private GameObject shield;

	void Awake(){
		Transform[] childs = gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform child in childs){
			if (child.tag == "Sword")
				sword = child.gameObject;
			else if (child.tag == "Shield")
				shield = child.gameObject;
		}
	}
	
	void Start(){
		rb = GetComponent<Rigidbody2D>();
		if (rb == null)
			rb = gameObject.AddComponent<Rigidbody2D>();

		anim = GetComponent<Animator>();
	}

	public void SetWeaponManager(WeaponManager wep){
		weapon = wep;

		switch (weapon.GetTypeOfWeapon()){
			case TypeOfWeapon.Fist:
				sword.SetActive(false);
				shield.SetActive(false);
				break;			
			default:
				sword.SetActive(true);
				shield.SetActive(true);
				break;
		}
	}

	private void CheckSpriteEquip(){

	}

	public bool Attack(){
		if (weapon.Attack()){
			anim.SetTrigger("Attack");
			return true;
		}
		return false;
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Mouse0))
			Attack();
		
		if (Input.GetAxis("Horizontal") != 0f)
			Move();
		else
			anim.SetBool("Walking", false);
	}

	private void Move(){
		rb.velocity = (Vector2.right * Input.GetAxis("Horizontal") * speed);
		anim.SetFloat("WalkVelocity", Mathf.Abs(rb.velocity.x));
		anim.SetBool("Walking", true);
		Flip();
	}

	private void Flip(){
		if (rb.velocity.x > 0 && transform.localScale.x < 0)
			transform.localScale = new Vector3(1, 1, 1);
		else if (rb.velocity.x < 0 && transform.localScale.x > 0)
			transform.localScale = new Vector3(-1, 1, 1);
	}
}
