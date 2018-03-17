using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public GameObject pipePrefab;
	public Transform pipeSpawn;

	public float minTime;
	public float maxTime;
	public float timer;

	public PlayerController PC;

	public Text scoreText;

	// Update is called once per frame
	void Update ()
	{
		if (timer <= 0 && PC.isStart)
		{
			PipeSpawner ();
		}
		timer -= Time.deltaTime;
		ScoreFunction ();
	}

	void PipeSpawner()
	{
		Instantiate (pipePrefab, pipeSpawn.position, pipeSpawn.rotation);
		timer = Random.Range (minTime, maxTime);
	}

	void ScoreFunction()
	{
		scoreText.text = PC.playerScore.ToString ();
	}

	public void ReplayFunction()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (1);
	}

	public void MainMenuFunction()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (0);
	}

}
