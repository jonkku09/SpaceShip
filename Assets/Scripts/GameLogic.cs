using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
	public bool GameOver;

	public Text GameOverText;

	public GameObject AsteroidPrefab;

	public float AsteroidSpawnX;

	public float AsteroidSpawnMinY;
	
	public float AsteroidSpawnMaxY;

	public float AsteroidSpawnFrequency;

	private float _asteroidSpawnTimer;
	
	// Use this for initialization
	void Start ()
	{
	//Instantiate(AsteroidPrefab, new Vector3(0, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		GameOverText.gameObject.SetActive(GameOver);

		_asteroidSpawnTimer = _asteroidSpawnTimer + Time.deltaTime;
		
		
		if (_asteroidSpawnTimer > AsteroidSpawnFrequency)
		{
			var asteroidSpawnY = Random.Range(AsteroidSpawnMinY, AsteroidSpawnMaxY);
			var asteroidObject = Instantiate(AsteroidPrefab, new Vector3(AsteroidSpawnX, asteroidSpawnY), Quaternion.identity);
			var asteroid = asteroidObject.GetComponent<Asteroid>();
			asteroid.Logic = this;
			_asteroidSpawnTimer = 0;
		}
		
	}
}
