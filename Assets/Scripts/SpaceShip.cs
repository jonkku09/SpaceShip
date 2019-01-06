using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpaceShip : MonoBehaviour
{
	
	public float VerticalSpeed = 0.02f;

	public GameLogic Logic;
		
	void Start () {		
	}
	
	void Update()
	{
		if (!Logic.GameOver)
		{			
			if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 5.200) 
			{
				transform.Translate(0, VerticalSpeed, 0);
			}

			if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -4.000) 
			{
				transform.Translate(0, -VerticalSpeed, 0);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Logic.GameOver = true;
	}
}
