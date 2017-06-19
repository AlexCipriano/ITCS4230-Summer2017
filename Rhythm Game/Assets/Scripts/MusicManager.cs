using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour 
{
	public static MusicManager instance = null;
	bool PlaySound;
	[SerializeField] AudioSource music;

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
		//PlaySound = false;
	}

	public void PlayMusic(){
		music.Play();
	}

	public void PauseMusic(bool pause){
		if (pause) {
			music.Pause ();
		} else {
			music.UnPause ();
		}
	}

	/* 
	// Update is called once per frame
	void Update () {
		if (PlaySound == true) 
		{
			music.Play();
			PlaySound = false;
		}
		if(music.isPlaying == false)
		{
			StartCoroutine(Wait());
		}
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2.16f);
		PlaySound = true;
	}*/
}