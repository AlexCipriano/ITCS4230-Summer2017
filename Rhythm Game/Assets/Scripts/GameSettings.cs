using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {
	public string songSelected;

	public static GameSettings instance;

	void Awake(){
		if (instance == null) {
			instance = this;
		}else if(instance != null){
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);

	}

	// Use this for initialization
	void Start () {
		songSelected = "test";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
