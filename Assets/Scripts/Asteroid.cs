using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

	public float HorizontalSpeed = 0.02f;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(HorizontalSpeed, 0, 0);
		if (transform.position.x < -12.25)
		{
			Destroy(gameObject);
		}
	}
}
