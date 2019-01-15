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

	public float SpawnFrequencyChangeByDifficulty;

	private float _asteroidSpawnTimer;

	public float ScoreUpdateFrequency;

	private float _scoreUpdateTimer;

	private int _score;

	public Text ScoreText;
	
	void Start ()
	{
	}
	
	void Update () {
		GameOverText.gameObject.SetActive(GameOver);

		_asteroidSpawnTimer = _asteroidSpawnTimer + Time.deltaTime;
		_scoreUpdateTimer = _scoreUpdateTimer + Time.deltaTime; 		
		
		if (!GameOver && _asteroidSpawnTimer > AsteroidSpawnFrequency + GetDifficulty() * SpawnFrequencyChangeByDifficulty)
		{
			var asteroidSpawnY = Random.Range(AsteroidSpawnMinY, AsteroidSpawnMaxY);
			var asteroidObject = Instantiate(AsteroidPrefab, new Vector3(AsteroidSpawnX, asteroidSpawnY), Quaternion.identity);
			var asteroid = asteroidObject.GetComponent<Asteroid>();
			asteroid.Logic = this;
			_asteroidSpawnTimer = 0;
		}

		if (!GameOver && _scoreUpdateTimer > ScoreUpdateFrequency)
		{
			_score = _score + 1;
			ScoreText.text = _score.ToString();
			_scoreUpdateTimer = 0;
		}	
		
	}

	 public float GetDifficulty()
	{
		return _score / 100f;
	}
}
