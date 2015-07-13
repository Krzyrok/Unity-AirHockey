using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	private static int _score = 0;

	private static Text _scoreText;


	// Use this for initialization
	void Start () {
		_score = 0;
		_scoreText = GetComponent<Text>();
		_scoreText.text = "Your score: " + _score;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public static void AddToTheScore(int points)
	{
		_score += points;
		UpdateScoreText ();
	}

	private static void UpdateScoreText()
	{
		_scoreText.text = "Your score: " + _score;
	}
}
