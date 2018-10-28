using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementScript : MonoBehaviour {

	public string gameSceneName;
	public string rulesSceneName;
	public string titleSceneName;

	public void StartGame()
	{
		SceneManager.LoadScene(gameSceneName);
	}

	public void GoToRules()
	{
		SceneManager.LoadScene(rulesSceneName);
	}

	public void GoToTitle()
	{
		SceneManager.LoadScene(titleSceneName);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
