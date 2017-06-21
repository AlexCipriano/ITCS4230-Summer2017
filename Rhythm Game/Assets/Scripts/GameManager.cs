using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//Singleton reference
	public static GameManager instance;

	//Note Fields
	private int[] nextnote;
	public Transform note;
	public Queue<int[]> notequeue = new Queue<int[]>(150);
	private int[] note1 = new int[] {1};
	private int[] note2 = new int[] {2};
	private int[] note3 = new int[] {3};
	private int[] note4 = new int[] {4};
	private int[] note12 = new int[] {1,2};
	private int[] note13 = new int[] {1,3};
	private int[] note14 = new int[] {1,4};
	private int[] note23 = new int[] {2,3};
	private int[] note24 = new int[] {2,4};
	private int[] note34 = new int[] {3,4};
	private int[] note123 = new int[] {1,2,3};
	private int[] note124 = new int[] {1,2,4};
	private int[] note134 = new int[] {1,3,4};
	private int[] note234 = new int[] {2,3,4};
	private int[] note1234 = new int[] {1,2,3,4};

	public float HP;
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
		Song1QueueStart();
		timerReset = true;
		PauseCanvas.gameObject.SetActive (false);		
		MusicManager.instance.PauseMusic (false);
		Time.timeScale = 1;
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
		if(firstMusicStart){
			MusicManager.instance.PlayMusic();
			firstMusicStart = false;
		}

		timerReset = true;
		nextnote = notequeue.Dequeue ();
		for (int i = 0; i < nextnote.Length; i++) {
			switch (nextnote [i]) {
				case 1:
					xPos = -3f;
					Instantiate (note, new Vector3(xPos ,30.75f, 68.5f), note.rotation);
					break;
				case 2:
					xPos = -1f;
					Instantiate (note, new Vector3(xPos ,30.75f, 68.5f), note.rotation);
					break;
				case 3:
					xPos = 1f;
					Instantiate (note, new Vector3(xPos ,30.75f, 68.5f), note.rotation);
					break;
				case 4:
					xPos = 3f;
					Instantiate (note, new Vector3(xPos ,30.75f, 68.5f), note.rotation);
					break;
			}
		}

	}


	public void Song1QueueStart () {
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);

		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);

		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);

		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);

		notequeue.Enqueue(note13);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);

		notequeue.Enqueue(note14);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);

		notequeue.Enqueue(note13);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);

		notequeue.Enqueue(note14);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);

		notequeue.Enqueue(note1);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note12);

		notequeue.Enqueue(note1);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note12);

		notequeue.Enqueue(note1);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note12);

		notequeue.Enqueue(note1);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note12);

		notequeue.Enqueue(note13);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note12);

		notequeue.Enqueue(note14);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note12);

		notequeue.Enqueue(note13);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note12);

		notequeue.Enqueue(note14);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note12);

		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);

		notequeue.Enqueue(note4);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note1);

		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);

		notequeue.Enqueue(note4);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note1);

		notequeue.Enqueue(note13);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);

		notequeue.Enqueue(note14);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note1);

		notequeue.Enqueue(note13);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);

		notequeue.Enqueue(note14);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note1);

		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);

		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);

		notequeue.Enqueue(note1);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note2);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note14);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note14);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note14);
		notequeue.Enqueue(note3);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note13);
		notequeue.Enqueue(note4);
		notequeue.Enqueue(note13);

		notequeue.Enqueue(note12);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note14);

		notequeue.Enqueue(note12);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note13);

		notequeue.Enqueue(note12);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note12);

		notequeue.Enqueue(note14);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note12);

		notequeue.Enqueue(note123);
		notequeue.Enqueue(note124);
		notequeue.Enqueue(note134);
		notequeue.Enqueue(note234);

		notequeue.Enqueue(note123);
		notequeue.Enqueue(note124);
		notequeue.Enqueue(note134);
		notequeue.Enqueue(note234);

		notequeue.Enqueue(note123);
		notequeue.Enqueue(note124);
		notequeue.Enqueue(note134);
		notequeue.Enqueue(note234);

		notequeue.Enqueue(note123);
		notequeue.Enqueue(note124);
		notequeue.Enqueue(note134);
		notequeue.Enqueue(note234);

		notequeue.Enqueue(note12);
		notequeue.Enqueue(note14);
		notequeue.Enqueue(note13);
		notequeue.Enqueue(note24);

		notequeue.Enqueue(note13);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note14);
		notequeue.Enqueue(note23);

		notequeue.Enqueue(note24);
		notequeue.Enqueue(note12);
		notequeue.Enqueue(note34);
		notequeue.Enqueue(note134);

		notequeue.Enqueue(note23);
		notequeue.Enqueue(note14);
		notequeue.Enqueue(note13);
		notequeue.Enqueue(note1234);
	}
}

