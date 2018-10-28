using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class GameManagement : MonoBehaviour {

	private static GameManagement gameManager;

	public GameObject bird, spawner, inputManager;

	private birdMovement birdMoveScr;
	private SpawnerScript spawnerScr;
	private inputHandler inputHandleScr;

	public static GameManagement instance
	{
		get
		{
			if (!gameManager)
			{
				gameManager = FindObjectOfType (typeof(GameManagement)) as GameManagement;

				if (!gameManager)
				{
					Debug.Log("Yo, I ain't got no gameManager script in this scene");
				}
				else
				{
					gameManager.Init();
				}
			}

			return gameManager;
		}
	}

	void Init()
	{
		birdMoveScr = bird.GetComponent<birdMovement>();
		spawnerScr = spawner.GetComponent<SpawnerScript>();
		inputHandleScr = inputManager.GetComponent<inputHandler>();
	}

	public static void StartGracePeriod()
	{
		Time.timeScale = 0;

		instance.inputHandleScr.setMoveBird(false);
	}

	public static void EndGracePeriod()
	{
		Time.timeScale = 1;

		instance.inputHandleScr.setMoveBird(true);
	}
}
