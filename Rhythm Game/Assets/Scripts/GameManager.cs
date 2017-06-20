using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//Singleton reference
	public static GameManager instance;

	//Note Fields
	private Transform nextnote;
	public Transform note1;
	public Transform note2;
	public Transform note3;
	public Transform note4;
	public Transform note12;
	public Transform note13;
	public Transform note14;
	public Transform note23;
	public Transform note24;
	public Transform note34;
	public Transform note123;
	public Transform note124;
	public Transform note234;
	public Transform note1234;
	public Queue<Transform> notequeue = new Queue<Transform>(150);
	public float HP;
	private float[] noteList = new float[] {1,2,3,4,4,3,2,1};
	private int noteMark = 0;
	public Transform noteObj;
	[SerializeField] float noteSpawnRate;
	private bool timerReset = true;
	private float xPos;

	//Music fields
	private bool firstMusicStart = true;

	//Score fields
	public Text scoreText;
	public int notesHit {get; set;}
	public int notesMissed {get; set;}

	//Menu
	public Transform PauseCanvas;

	//Timer
	private Time timer;
	[SerializeField] private Time[] notetimes;

	public void QueueStart () {
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note13);
		notequeue.Enqueue(note14);
		notequeue.Enqueue(note23);
		notequeue.Enqueue(note24);
		notequeue.Enqueue(note34);
		notequeue.Enqueue(note123);
		notequeue.Enqueue(note124);
		notequeue.Enqueue(note234);
		notequeue.Enqueue(note1234);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note13);
		notequeue.Enqueue(note14);
		notequeue.Enqueue(note23);
		notequeue.Enqueue(note24);
		notequeue.Enqueue(note34);
		notequeue.Enqueue(note123);
		notequeue.Enqueue(note124);
		notequeue.Enqueue(note234);
		notequeue.Enqueue(note1234);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note13);
		notequeue.Enqueue(note14);
		notequeue.Enqueue(note23);
		notequeue.Enqueue(note24);
		notequeue.Enqueue(note34);
		notequeue.Enqueue(note123);
		notequeue.Enqueue(note124);
		notequeue.Enqueue(note234);
		notequeue.Enqueue(note1234);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note13);
		notequeue.Enqueue(note14);
		notequeue.Enqueue(note23);
		notequeue.Enqueue(note24);
		notequeue.Enqueue(note34);
		notequeue.Enqueue(note123);
		notequeue.Enqueue(note124);
		notequeue.Enqueue(note234);
		notequeue.Enqueue(note1234);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note13);
		notequeue.Enqueue(note14);
		notequeue.Enqueue(note23);
		notequeue.Enqueue(note24);
		notequeue.Enqueue(note34);
		notequeue.Enqueue(note123);
		notequeue.Enqueue(note124);
		notequeue.Enqueue(note234);
		notequeue.Enqueue(note1234);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note13);
		notequeue.Enqueue(note14);
		notequeue.Enqueue(note23);
		notequeue.Enqueue(note24);
		notequeue.Enqueue(note34);
		notequeue.Enqueue(note123);
		notequeue.Enqueue(note124);
		notequeue.Enqueue(note234);
		notequeue.Enqueue(note1234);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note13);
		notequeue.Enqueue(note14);
		notequeue.Enqueue(note23);
		notequeue.Enqueue(note24);
		notequeue.Enqueue(note34);
		notequeue.Enqueue(note123);
		notequeue.Enqueue(note124);
		notequeue.Enqueue(note234);
		notequeue.Enqueue(note1234);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note13);
		notequeue.Enqueue(note14);
		notequeue.Enqueue(note23);
		notequeue.Enqueue(note24);
		notequeue.Enqueue(note34);
		notequeue.Enqueue(note123);
		notequeue.Enqueue(note124);
		notequeue.Enqueue(note234);
		notequeue.Enqueue(note1234);

	}

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
		QueueStart ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(timerReset){
			StartCoroutine (spawnNote ());
			timerReset = false;
		}
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (PauseCanvas.gameObject.activeInHierarchy == false) 
			{
				Time.timeScale = 0;
				MusicManager.instance.PauseMusic (true);
				PauseCanvas.gameObject.SetActive (true);

			} else {
				PauseCanvas.gameObject.SetActive (false);		
				MusicManager.instance.PauseMusic (false);
				Time.timeScale = 1;
			}
		}

		scoreText.text = "Score: " + notesHit;
	}

	IEnumerator spawnNote(){
		yield return new WaitForSeconds(noteSpawnRate);

//		if (noteList [noteMark] == 1) {
//			xPos = -3f;
//		}else if(noteList [noteMark] == 2){
//			xPos = -1f;
//		}else if(noteList [noteMark] == 3){
//			xPos = 1f;
//		}else if(noteList [noteMark] == 4){
//			xPos = 3f;
//		}
//		noteMark++;

		if(firstMusicStart){
			MusicManager.instance.PlayMusic();
			firstMusicStart = false;
		}
		if (noteMark > 7) {
			noteMark = 0;
		}
			timerReset = true;
		nextnote = notequeue.Dequeue ();
		Instantiate (nextnote, nextnote.position, noteObj.rotation);
	}
}

