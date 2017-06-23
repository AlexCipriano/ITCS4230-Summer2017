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
	public ParticleSystem notehit1;
	public ParticleSystem notehit2;
	public ParticleSystem notehit3;
	public ParticleSystem notehit4;
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
	private bool healed;
	public Text scoreText;
	public Text HPText;
	public Text ComboText;
	public int comboCounter;
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
		healed = false;
		comboCounter = 0;
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
		if (comboCounter >= 30 && comboCounter % 30 == 0 && healed == false) {
			instance.HP = instance.HP + 5;
			healed = true;
		} 
		if (comboCounter % 30 == 1 && healed == true) {
			healed = false;
		}

		if (instance.HP >= 100) {
			instance.HP = 100;
		}
		if (instance.HP <= 0) {
			instance.HP = 0;
		}
		ComboText.text = "Combo: " + instance.comboCounter;
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
		notequeue.Enqueue(note1);
		notequeue.Enqueue(note1);

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
		notetimes = new float[225];
		notetimes[0] = 0.01f ;
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
		notetimes[105] = 45.46f ;
		notetimes[106] = 45.72f ;
		notetimes[107] = 45.95f ;
		notetimes[108] = 46.42f ;
		notetimes[109] = 46.66f ;
		notetimes[110] = 46.89f ;
		notetimes[111] = 47.36f ;
		notetimes[112] = 47.59f ;
		notetimes[113] = 47.83f ;
		notetimes[114] = 48.30f ;
		notetimes[115] = 48.53f ;
		notetimes[116] = 48.77f ;
		notetimes[117] = 49.32f ;
		notetimes[118] = 49.47f ;
		notetimes[119] = 50.17f ;
		notetimes[120] = 50.41f ;
		notetimes[121] = 50.64f ;
		notetimes[122] = 51.11f ;
		notetimes[123] = 51.34f ;
		notetimes[124] = 51.48f ;
		notetimes[125] = 52.05f ;
		notetimes[126] = 52.28f ;
		notetimes[127] = 52.50f ;
		notetimes[128] = 52.96f ;
		notetimes[129] = 53.20f ;
		notetimes[130] = 53.43f ;
		notetimes[131] = 53.90f ;
		notetimes[132] = 54.14f ;
		notetimes[133] = 54.37f ;
		notetimes[134] = 54.84f ;
		notetimes[135] = 55.07f ;
		notetimes[136] = 56.01f ;
		notetimes[137] = 56.25f ;
		notetimes[138] = 56.71f ;
		notetimes[139] = 56.95f ;
		notetimes[140] = 57.18f ;
		notetimes[141] = 57.42f ;
		notetimes[142] = 57.65f ;
		notetimes[143] = 57.89f ;
		notetimes[144] = 58.12f ;
		notetimes[145] = 58.59f ;
		notetimes[146] = 58.82f ;
		notetimes[147] = 59.06f ;
		notetimes[148] = 59.53f ;
		notetimes[149] = 59.76f ;
		notetimes[150] = 60.00f ;
		notetimes[151] = 60.46f ;
		notetimes[152] = 60.70f ;
		notetimes[153] = 60.93f ;
		notetimes[154] = 61.40f ;
		notetimes[155] = 61.64f ;
		notetimes[156] = 61.87f ;
		notetimes[157] = 62.34f ;
		notetimes[158] = 62.57f ;
		notetimes[159] = 62.81f ;
		notetimes[160] = 63.28f ;
		notetimes[161] = 63.51f ;
		notetimes[162] = 63.75f ;
		notetimes[163] = 64.21f ;
		notetimes[164] = 64.45f ;
		notetimes[165] = 64.68f ;
		notetimes[166] = 65.15f ;
		notetimes[167] = 65.39f ;
		notetimes[168] = 65.62f ;
		notetimes[169] = 66.09f ;
		notetimes[170] = 66.32f ;
		notetimes[171] = 66.56f ;
		notetimes[172] = 67.03f ;
		notetimes[173] = 67.26f ;
		notetimes[174] = 67.50f ;
		notetimes[175] = 67.96f ;
		notetimes[176] = 68.43f ;
		notetimes[177] = 68.90f ;
		notetimes[178] = 69.37f ;
		notetimes[179] = 69.84f ;
		notetimes[180] = 70.31f ;
		notetimes[181] = 70.78f ;
		notetimes[182] = 71.25f ;
		notetimes[183] = 71.71f ;
		notetimes[184] = 72.18f ;
		notetimes[185] = 72.65f ;
		notetimes[186] = 73.12f ;
		notetimes[187] = 73.59f ;
		notetimes[188] = 74.06f ;
		notetimes[189] = 74.29f ;
		notetimes[190] = 74.53f ;
		notetimes[191] = 74.64f ;
		notetimes[192] = 74.76f ;
		notetimes[193] = 75.00f ;
		notetimes[194] = 75.46f ;
		notetimes[195] = 75.93f ;
		notetimes[196] = 76.40f ;
		notetimes[197] = 76.87f ;
		notetimes[198] = 77.34f ;
		notetimes[199] = 77.81f ;
		notetimes[200] = 78.28f ;
		notetimes[201] = 78.75f ;
		notetimes[202] = 79.21f ;
		notetimes[203] = 79.68f ;
		notetimes[204] = 80.15f ;
		notetimes[205] = 80.62f ;
		notetimes[206] = 81.09f ;
		notetimes[207] = 81.56f ;
		notetimes[208] = 82.03f ;
		notetimes[209] = 82.50f ;
		notetimes[210] = 82.96f ;
		notetimes[211] = 83.43f ;
		notetimes[212] = 83.90f ;
		notetimes[213] = 84.37f ;
		notetimes[214] = 84.84f ;
		notetimes[215] = 85.31f ;
		notetimes[216] = 85.78f ;
		notetimes[217] = 86.25f ;
		notetimes[218] = 86.71f ;
		notetimes[219] = 87.18f ;
		notetimes[220] = 87.65f ;
		notetimes[221] = 88.12f ;
		notetimes[222] = 88.59f ;
		notetimes[223] = 89.06f ;
		notetimes[224] = 89.53f ;









	}
}


