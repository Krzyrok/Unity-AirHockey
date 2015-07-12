using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	static int score = 0;

	static Text scoreText;


	// Use this for initialization
	void Start () {
		score = 0;
		scoreText = GetComponent<Text>();
		scoreText.text = "Your score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public static void AddToTheScore(int points)
	{
		score += points;
		UpdateScoreText ();
	}

	private static void UpdateScoreText()
	{
		scoreText.text = "Your score: " + score;
	}
}
