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
	private int k = 0;
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
	private AudioSource music;
	[SerializeField] private AudioSource gamemusic;
	private bool firstMusicStart = true;

	//Score fields
	public Text scoreText;
	public Text HPText;
	public int notesHit {get; set;}
	public int notesMissed {get; set;}

	//Menu
	public Transform PauseCanvas;

	//Timer
	[SerializeField] private float[] notetimes;

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
		Song1NoteTimes ();
		timerReset = true;
		gamemusic = MusicManager.instance.GetComponent<AudioSource>();
		PauseCanvas.gameObject.SetActive (false);		
		MusicManager.instance.PauseMusic (false);
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(timerReset){
			StartCoroutine (SyncToAudio());
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
		HPText.text = "HP: " + instance.HP;
	}
		
	IEnumerator SyncToAudio(){
		if(firstMusicStart){
			MusicManager.instance.PlayMusic();
			firstMusicStart = false;
		}

		timerReset = true;
		for (int k = 0; k < notetimes.Length; k++){
			if (HP == 0) {
				yield return 0;
			}
			float nSample = notetimes [k] * gamemusic.clip.frequency;
			print (nSample - 5.1f);
			while (gamemusic.timeSamples < nSample) {
					yield return 0; 
				}
			nextnote = notequeue.Dequeue ();

			for (int i = 0; i < nextnote.Length; i++) {
				switch (nextnote [i]) {
				case 1:
					xPos = -3f;
					Instantiate (note, new Vector3 (xPos, 30.75f, 68.5f), note.rotation);
					break;
				case 2:
					xPos = -1f;
					Instantiate (note, new Vector3 (xPos, 30.75f, 68.5f), note.rotation);
					break;
				case 3:
					xPos = 1f;
					Instantiate (note, new Vector3 (xPos, 30.75f, 68.5f), note.rotation);
					break;
				case 4:
					xPos = 3f;
					Instantiate (note, new Vector3 (xPos, 30.75f, 68.5f), note.rotation);
					break;
				}
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

	public void Song1NoteTimes () {
		notetimes = new float[235];
		notetimes[0] = 0f ;
		notetimes[1] = 0.46f ;
		notetimes[2] = 0.70f ;
		notetimes[3] = 1.17f ;
		notetimes[4] = 1.40f ;
		notetimes[5] = 1.87f ;
		notetimes[6] = 2.34f ;
		notetimes[7] = 2.57f ;
		notetimes[8] = 3.04f ;
		notetimes[9] = 3.28f ;
		notetimes[10] = 3.75f ;
		notetimes[11] = 4.21f ;
		notetimes[12] = 4.45f ;
		notetimes[13] = 4.92f ;
		notetimes[14] = 5.15f ;
		notetimes[15] = 5.62f ;
		notetimes[16] = 6.09f ;
		notetimes[17] = 6.32f ;
		notetimes[18] = 6.79f ;
		notetimes[19] = 7.03f ;
		notetimes[20] = 7.50f ;
		notetimes[21] = 7.96f ;
		notetimes[22] = 8.20f ;
		notetimes[23] = 8.9f ;
		notetimes[24] = 9.37f ;
		notetimes[25] = 9.84f ;
		notetimes[26] = 10.07f ;
		notetimes[27] = 10.54f ;
		notetimes[28] = 10.78f ;
		notetimes[29] = 11.25f ;
		notetimes[30] = 11.71f ;
		notetimes[31] = 11.95f ;
		notetimes[32] = 12.42f ;
		notetimes[33] = 12.65f ;
		notetimes[34] = 13.12f ;
		notetimes[35] = 13.59f ;
		notetimes[36] = 13.82f ;
		notetimes[37] = 14.29f ;
		notetimes[38] = 14.53f ;
		notetimes[39] = 15.00f ;
		notetimes[40] = 15.46f ;
		notetimes[41] = 15.93f ;
		notetimes[42] = 16.40f ;
		notetimes[43] = 17.34f ;
		notetimes[44] = 17.81f ;
		notetimes[45] = 18.28f ;
		notetimes[46] = 18.75f ;
		notetimes[47] = 19.21f ;
		notetimes[48] = 19.68f ;
		notetimes[49] = 20.15f ;
		notetimes[50] = 20.62f ;
		notetimes[51] = 21.09f ;
		notetimes[52] = 21.56f ;
		notetimes[53] = 22.03f ;
		notetimes[54] = 22.50f ;
		notetimes[55] = 22.96f ;
		notetimes[56] = 23.43f ;
		notetimes[57] = 23.90f ;
		notetimes[58] = 24.37f ;
		notetimes[59] = 24.84f ;
		notetimes[60] = 25.31f ;
		notetimes[61] = 25.78f ;
		notetimes[62] = 26.25f ;
		notetimes[63] = 26.71f ;
		notetimes[64] = 27.18f ;
		notetimes[65] = 28.12f ;
		notetimes[66] = 28.59f ;
		notetimes[67] = 29.06f ;
		notetimes[68] = 29.53f ;
		notetimes[69] = 29.64f ;
		notetimes[70] = 29.76f ;
		notetimes[71] = 29.88f ;
		notetimes[72] = 30.00f ;
		notetimes[73] = 30.23f ;
		notetimes[74] = 30.46f ;
		notetimes[75] = 30.70f ;
		notetimes[76] = 31.87f ;
		notetimes[77] = 32.10f ;
		notetimes[78] = 32.34f ;
		notetimes[79] = 32.57f ;
		notetimes[80] = 33.75f ;
		notetimes[81] = 33.98f ;
		notetimes[82] = 34.21f ;
		notetimes[83] = 34.45f ;
		notetimes[84] = 35.62f ;
		notetimes[85] = 35.85f ;
		notetimes[86] = 36.09f ;
		notetimes[87] = 36.32f ;
		notetimes[88] = 37.50f ;
		notetimes[89] = 37.73f ;
		notetimes[90] = 37.96f ;
		notetimes[91] = 38.20f ;
		notetimes[92] = 39.37f ;
		notetimes[93] = 39.60f ;
		notetimes[94] = 39.84f ;
		notetimes[95] = 40.07f ;
		notetimes[96] = 41.25f ;
		notetimes[97] = 41.48f ;
		notetimes[98] = 41.71f ;
		notetimes[99] = 42.65f ;
		notetimes[100] = 43.12f ;
		notetimes[101] = 43.35f ;
		notetimes[102] = 43.59f ;
		notetimes[103] = 43.82f ;
		notetimes[104] = 45.00f ;
		notetimes[105] = 0f ;
		notetimes[106] = 0f ;
		notetimes[107] = 0f ;
		notetimes[108] = 0f ;
		notetimes[109] = 0f ;
		notetimes[110] = 0f ;
		notetimes[111] = 0f ;
		notetimes[112] = 0f ;
		notetimes[113] = 0f ;
		notetimes[114] = 0f ;
		notetimes[115] = 0f ;
		notetimes[116] = 0f ;
		notetimes[117] = 0f ;
		notetimes[118] = 0f ;
		notetimes[119] = 0f ;
		notetimes[120] = 0f ;
		notetimes[121] = 0f ;
		notetimes[122] = 0f ;
		notetimes[123] = 0f ;
		notetimes[124] = 0f ;
		notetimes[125] = 0f ;
		notetimes[126] = 0f ;
		notetimes[127] = 0f ;
		notetimes[128] = 0f ;
		notetimes[129] = 0f ;
		notetimes[130] = 0f ;
		notetimes[131] = 0f ;
		notetimes[132] = 0f ;
		notetimes[133] = 0f ;
		notetimes[134] = 0f ;
		notetimes[135] = 0f ;
		notetimes[136] = 0f ;
		notetimes[137] = 0f ;
		notetimes[138] = 0f ;
		notetimes[139] = 0f ;
		notetimes[140] = 0f ;
		notetimes[141] = 0f ;
		notetimes[142] = 0f ;
		notetimes[143] = 0f ;
		notetimes[144] = 0f ;
		notetimes[145] = 0f ;
		notetimes[146] = 0f ;
		notetimes[147] = 0f ;
		notetimes[148] = 0f ;
		notetimes[149] = 0f ;
		notetimes[150] = 0f ;
		notetimes[151] = 0f ;
		notetimes[152] = 0f ;
		notetimes[153] = 0f ;
		notetimes[154] = 0f ;
		notetimes[155] = 0f ;




	}
}


