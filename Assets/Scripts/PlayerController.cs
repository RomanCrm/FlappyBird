using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float flapForce;
	private Rigidbody2D rB; // RigidBody of the Player

	public bool isGO; // GO - Game Over
	public bool isStart;

	public int playerScore;

	public GameObject gameOverPanel;
	private GameController GC;

	// Use this for initialization
	void Start ()
	{
		rB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Fire1") && !isGO)
		{
			if (!isStart)
			{
				isStart = true;
				rB.gravityScale = 1;
			}
			Flap ();
		}
	}

	void FixedUpdate()
	{
		if (isStart && !isGO)
		{
			HeavyEnd ();
		}
	}

	void Flap()
	{
		rB.velocity = Vector2.zero;
		rB.AddForce (new Vector2 (0, flapForce));
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "DeathZone")
		{
			isGO = true;
			StartCoroutine (WaitForGO());
		}
		if (other.tag == "ScoreZone")
		{
			playerScore++;
			int tmp = PlayerPrefs.GetInt ("HighScore");
			if (playerScore > tmp)
			{
				PlayerPrefs.SetInt ("HighScore", playerScore);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "DeathZone")
		{
			isGO = true;
			StartCoroutine (WaitForGO());
		}	
	}

	IEnumerator WaitForGO()
	{
		yield return new WaitForSeconds (0.5f);
		gameOverPanel.SetActive (true);
		Time.timeScale = 0;
	}

	void HeavyEnd()
	{
		float angle = 35;
		if (rB.velocity.y < 0)
		{
			angle = Mathf.Lerp (35, -90, -(rB.velocity.y) / 10);
		}
		transform.rotation = Quaternion.Euler (0, 0, angle);
		PlayerPrefs.SetInt ("LastScore", playerScore);
	}

}
