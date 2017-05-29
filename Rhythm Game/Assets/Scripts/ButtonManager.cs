using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

	public void StartGameBtn(string newGameLevel)
	{
		SceneManager.LoadScene (newGameLevel);
	}

	public void StartTutorialBtn(string newGameLevel)
	{
		
	}

	public void ExitGameBtn(string newGameLevel)
	{
		Application.Quit ();
	}
}
