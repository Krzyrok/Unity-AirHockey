using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

	private static Text _gameOverText;
	private static bool _isGameOver = false;

	// Use this for initialization
	void Start () {
		_gameOverText = GetComponent<Text> ();
		_gameOverText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R) && _isGameOver)
		{
			_isGameOver = false;
			Time.timeScale = 1.0f;
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public static void EndGame()
	{
		_gameOverText.text = "Game Over\nPress R to restart";
		_isGameOver = true;
		Time.timeScale = 0.0f;
	}
}
