using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private float[] noteList = new float[] {1,2,3,4,4,3,2,1};
	private int noteMark = 0;
	public Transform noteObj;
	private bool timerReset = true;
	private float xPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(timerReset){
			StartCoroutine (spawnNote ());
			timerReset = false;
		}

	}

	IEnumerator spawnNote(){
		yield return new WaitForSeconds(1);

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
		if (noteMark > 7) {
			noteMark = 0;
		}
			timerReset = true;
		Instantiate (noteObj, new Vector3 (xPos, 30.75f, 68.5f), noteObj.rotation);
	}
}

