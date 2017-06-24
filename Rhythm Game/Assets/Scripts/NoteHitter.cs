using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHitter : MonoBehaviour {
	private GameObject hitter;
	private Collider hitterCollider;
	private Color activeColor = Color.red;
	private Color inactiveColor = Color.blue;
	[SerializeField] private KeyCode hitKey;
	[SerializeField] private ParticleSystem hitnote;

	// Use this for initialization
	void Start () {
		hitter = this.gameObject;
		hitterCollider = hitter.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(hitKey)) {
			hitterCollider.isTrigger = true;
			hitter.GetComponent<Renderer> ().material.color = activeColor;
			StartCoroutine ("HitterWait");
		}
	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "Note") {
			hitnote.Play();
			GameManager.instance.notesHit++;
			GameManager.instance.comboCounter++;

		}
	}

	IEnumerator HitterWait()
	{
		yield return new WaitForSeconds(.1f);
		hitterCollider.isTrigger = false;
		hitter.GetComponent<Renderer> ().material.color = inactiveColor;
	}
}
