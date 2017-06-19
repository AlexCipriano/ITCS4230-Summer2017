using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

	public Transform PauseCanvas;


	public void StartGameBtn(string newGameLevel)
	{
		SceneManager.LoadScene (newGameLevel);
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
