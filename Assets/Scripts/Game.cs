using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
	public static Game instance;
	public GameObject entityFactory;
	public GameObject entityBuilder;
	public GameObject weaponFactory;
	public GameObject weaponBuilder;
	private List<GameObject> actors;
	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);

		actors = new List<GameObject>();
		actors.Add(entityFactory);
		actors.Add(entityBuilder);
		actors.Add(weaponFactory);
		actors.Add(weaponBuilder);

		CreateActors();
	}

	private void CreateActors(){
		for (int i = 0; i < actors.Count; i++){
			actors[i] = Instantiate(actors[i], Vector3.zero, new Quaternion(0, 0, 0, 1));
		}
		BuildLevel();
	}

	public void BuildLevel(){
		EntityBuilder.instance.Build(TypeOfEntity.Player);
	}
}
