using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

	[SerializeField] public Transform PauseCanvas;
	[SerializeField] public Transform MainStartButton;
	[SerializeField] public Transform TutorialButton;
	[SerializeField] public Transform SongOneButton;
	[SerializeField] public Transform SongTwoButton;


	public string songSelected;

	public void StartGameBtn(string newGameLevel)
	{
		MainStartButton.gameObject.SetActive (false);
		//TutorialButton.gameObject.SetActive(false);

		SongOneButton.gameObject.SetActive(true);
		SongTwoButton.gameObject.SetActive(true);
	}

	public void SelectSongBtn(string songName)
	{
		GameSettings.instance.songSelected = songName;
		SceneManager.LoadScene ("MainGame");
	}

	public void StartTutorialBtn(string newGameLevel)
	{

	}

	public void RestartLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void ReturnToMenu(string menuName){
		SceneManager.LoadScene (menuName);
	}

	public void ResumeGame()
	{
		PauseCanvas.gameObject.SetActive (false);		
		MusicManager.instance.PauseMusic (false);
		Time.timeScale = 1;
	}

	public void QuitLevel(string titleScreenName)
	{
		SceneManager.LoadScene (titleScreenName);
	}

	public void ExitGameBtn(string newGameLevel)
	{
		Application.Quit ();
	}
}
