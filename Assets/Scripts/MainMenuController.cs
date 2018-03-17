using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
	public Text hS;
	public Text lS;

	void Start()
	{
		hS.text = PlayerPrefs.GetInt ("HighScore").ToString();
		lS.text = PlayerPrefs.GetInt ("LastScore").ToString ();
	}

	public void PlayButton()
	{
		SceneManager.LoadScene (1);
	}

}
