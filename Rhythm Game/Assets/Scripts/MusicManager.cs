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

	void Start(){
		AudioSource source = GetComponent<AudioSource>();
		if(GameSettings.instance.songSelected == "Song1BeatMap"){
			source.clip = (AudioClip)Resources.Load ("song1-1-final-delay", typeof(AudioClip));
		}else if(GameSettings.instance.songSelected == "Song2BeatMap"){
			source.clip = (AudioClip)Resources.Load ("song2-final-delay", typeof(AudioClip));
		}
	}

	public void PlayMusic(){
		music.Play ();

	}

	public void PauseMusic(bool pause){
		if (pause) {
			music.Pause ();
		} else {
			music.UnPause ();
		}
	}

}