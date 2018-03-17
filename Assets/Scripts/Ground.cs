using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Ground : MonoBehaviour

{
	
	public Transform groundSpawn;


	
// Use this for initialization
	
	void Start ()

	{

	}
	
	

	// Update is called once per frame
	
	void Update ()

	{
		
		Reposition ();

	}

	

	void Reposition()

	{
	
		if (transform.position.x <= -groundSpawn.position.x)
	
		{
		
			transform.position = groundSpawn.position;
	
		}

	}


}
