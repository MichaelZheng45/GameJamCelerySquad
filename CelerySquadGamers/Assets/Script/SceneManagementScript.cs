using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementScript : MonoBehaviour {

    public bool spaceToStart = false;

	public string gameSceneName;
	public string rulesSceneName;
	public string titleSceneName;
	public string loseSceneName;

    private void Update()
    {
        if (spaceToStart)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGame();
            }
    }

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

	public void LoseGame()
	{
		SceneManager.LoadScene(loseSceneName);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
