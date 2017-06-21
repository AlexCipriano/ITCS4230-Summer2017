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

}