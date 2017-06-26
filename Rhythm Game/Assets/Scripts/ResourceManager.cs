using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
	public string textFile;
	private string [] noteTimePairs;
	private string [] uniqueNoteAndTime;
	public static ResourceManager instance;

	public Queue<int[]> noteQueue;
	public float[] notetimes;

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

	void Awake(){
		if (instance == null) {
			instance = this;
		}else if(instance != null){
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	public void GetSong(string fileName){
		TextAsset textAssets = (TextAsset)Resources.Load (fileName);
		noteTimePairs = textAssets.text.Split('#');
		notetimes = new float[noteTimePairs.Length];
		noteQueue = new Queue<int[]> (noteTimePairs.Length);

		for(int i = 0; i < noteTimePairs.Length - 1; i++){
			uniqueNoteAndTime = noteTimePairs[i].Split ('*');
						
			uniqueNoteAndTime [0] = uniqueNoteAndTime [0].Trim();
			uniqueNoteAndTime [1] = uniqueNoteAndTime [1].Trim();

			switch (uniqueNoteAndTime [0]) {
				case "note1":
					//Debug.Log ("note1");
					noteQueue.Enqueue (note1);
					break;
				case "note2":
					//Debug.Log ("note2");
					noteQueue.Enqueue (note2);
					break;
				case "note3":
					//Debug.Log ("note3");
					noteQueue.Enqueue (note3);
					break;
				case "note4":
					//Debug.Log ("note4");
					noteQueue.Enqueue (note4);
					break;
				case "note12":
					//Debug.Log ("note12");
					noteQueue.Enqueue (note12);
					break;
				case "note13":
					//Debug.Log ("note13");
					noteQueue.Enqueue (note13);
					break;
				case "note14":
					//Debug.Log ("note14");
					noteQueue.Enqueue (note14);
					break;
				case "note23":
					//Debug.Log ("note23");
					noteQueue.Enqueue (note23);
					break;
				case "note24":
					//Debug.Log ("note24");
					noteQueue.Enqueue (note24);
					break;
				case "note34":
					//Debug.Log ("note34");
					noteQueue.Enqueue (note34);
					break;
				case "note123":
					//Debug.Log ("note123");
					noteQueue.Enqueue (note123);
					break;
				case "note124":
					//Debug.Log ("note124");
					noteQueue.Enqueue (note124);
					break;
				case "note134":
					//Debug.Log ("note1");
					noteQueue.Enqueue (note134);
					break;
				case "note234":
					//Debug.Log ("note234");
					noteQueue.Enqueue (note234);
					break;
				case "note1234":
					//Debug.Log ("note1234");
					noteQueue.Enqueue (note1234);
					break;
			}

			if (uniqueNoteAndTime [1] != "noplay") {
				notetimes [i] = float.Parse (uniqueNoteAndTime [1]);
				//Debug.Log (notetimes[i]);
			}
		}

		GameManager.instance.notetimes = this.notetimes;
		GameManager.instance.notequeue = this.noteQueue;
	}

}
