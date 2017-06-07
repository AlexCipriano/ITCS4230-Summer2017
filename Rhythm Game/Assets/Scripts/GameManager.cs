using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//Singleton reference
	public static GameManager instance;

	//Note Fields
	private float[] noteList = new float[] {1,2,3,4,4,3,2,1};
	private int noteMark = 0;
	public Transform noteObj;
	[SerializeField] float noteSpawnRate;
	private bool timerReset = true;
	private float xPos;

	//Music fields
	private bool firstMusicStart = true;

	//Score fields
	public int notesHit {get; set;}
	public int notesMissed {get; set;}

	void Awake(){
		if (instance == null) {
			instance = this;
		}else if(instance != null){
			Destroy (gameObject);
		}
		//DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(timerReset){
			StartCoroutine (spawnNote ());
			timerReset = false;
		}
		//Debug.Log (notesMissed);
		Debug.Log (notesHit);
	}

	IEnumerator spawnNote(){
		yield return new WaitForSeconds(noteSpawnRate);

		if (noteList [noteMark] == 1) {
			xPos = -3f;
		}else if(noteList [noteMark] == 2){
			xPos = -1f;
		}else if(noteList [noteMark] == 3){
			xPos = 1f;
		}else if(noteList [noteMark] == 4){
			xPos = 3f;
		}
		noteMark++;

		if(firstMusicStart){
			MusicManager.instance.PlayMusic();
			firstMusicStart = false;
		}
		if (noteMark > 7) {
			noteMark = 0;
		}
			timerReset = true;
		Instantiate (noteObj, new Vector3 (xPos, 30.75f, 68.5f), noteObj.rotation);
	}
}

