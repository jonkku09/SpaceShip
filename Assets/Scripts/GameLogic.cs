using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
	public bool GameOver { get; private set; }

	public Text GameOverText;

	public Button PlayAgainButton;

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

	private int _highScore;
	
	public Text ScoreText;

	public Text HighScoreText;
	
	public void ShipDestroyed()
	{
		GameOver = true;
		
		if (_score > _highScore)
		{	
			_highScore = _score;
			HighScoreText.text = "High Score: "  + _highScore;
			PlayerPrefs.SetInt("highScore", _highScore);
		}
	}
	
	public void Restart()
	{
		_score = 0;
		_asteroidSpawnTimer = 0;
		var spaceShip = GameObject.FindObjectOfType<SpaceShip>();
		spaceShip.transform.position = new Vector3(-9,0);
		GameOver = false;
		var asteroids = GameObject.FindObjectsOfType<Asteroid>();
		foreach (var asteroid in asteroids)
		{
			Destroy(asteroid.gameObject);	
		}
	}
	
	void Start ()
	{		
		_highScore = PlayerPrefs.GetInt("highScore");
		HighScoreText.text = "High Score: "  + _highScore; 
	}
	
	void Update () {
		GameOverText.gameObject.SetActive(GameOver);
		PlayAgainButton.gameObject.SetActive(GameOver);

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
