using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.transform.Translate (Vector3.back * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "noteDestroyer") {
			Destroy (this.gameObject);
			GameManager.instance.notesMissed++;
			GameManager.instance.HP = GameManager.instance.HP - 5;
			GameManager.instance.comboCounter = 0;
		}

		if (other.tag == "NoteHitter") {
			Destroy (this.gameObject);
			GameManager.instance.notesHit++;
			GameManager.instance.comboCounter++;

			}
		}
	}
