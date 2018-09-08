using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpaceShip : MonoBehaviour
{
	public float HorizontalSpeed = 0.02f;
	public float VerticalSpeed = 0.02f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(HorizontalSpeed, 0, 0);
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(0, VerticalSpeed, 0);
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(0, -VerticalSpeed, 0);
		}
	}
}
