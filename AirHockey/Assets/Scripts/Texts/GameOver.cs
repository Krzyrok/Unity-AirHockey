using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

	static Text gameOverText;
	static bool isGameOver = false;

	// Use this for initialization
	void Start () {
		gameOverText = GetComponent<Text> ();
		gameOverText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R) && isGameOver)
		{
			isGameOver = false;
			Time.timeScale = 1.0f;
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public static void EndGame()
	{
		gameOverText.text = "Game Over\nPress R to restart";
		isGameOver = true;
		Time.timeScale = 0.0f;
	}
}
