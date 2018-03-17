using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSetup : MonoBehaviour
{
	public float minSpace;
	public float maxSpace;

	public GameObject top;
	public GameObject bottom;

	private SpriteRenderer rendTop;
	private SpriteRenderer rendBottom;

	// Use this for initialization
	void Start ()
	{
		Setup ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		PipeRemover ();
	}

	void Setup()
	{
		rendTop = top.GetComponent<SpriteRenderer> ();
		rendBottom = bottom.GetComponent<SpriteRenderer> ();

		float topPos = Random.Range (-3.55f + minSpace, 4.69f);
		top.transform.position = new Vector3 (transform.position.x, topPos, -1);
		float spaceBetween = Random.Range (minSpace, maxSpace);
		bottom.transform.position = new Vector3 (transform.position.x, topPos - spaceBetween, -1);
	}

	void PipeRemover()
	{
		if (transform.position.x < 0)
		{
			if (!rendTop.isVisible && !rendBottom.isVisible)
			{
				Destroy (this.gameObject);
			}
		}
	}

}
