﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

	public float HorizontalSpeed = 0.02f;
	public GameLogic Logic;	
	
	void Start () {		
	}
	
	void Update () {
		if (!Logic.GameOver)
		{
			transform.Translate(HorizontalSpeed, 0, 0);
		}
		
		if (transform.position.x < -12.25)
		{
			Destroy(gameObject);
		}
	}
}
