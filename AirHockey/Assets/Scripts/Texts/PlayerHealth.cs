using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public static int InitialHealth = 3;

	static int currentHealth;
	static Text healthText;
	// Use this for initialization
	void Start () {
		currentHealth = InitialHealth;
		healthText = GetComponent<Text>();
		UpdateHealth();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void DecreaseHealth()
	{
		currentHealth--;
		UpdateHealth ();
	}

	public static void UpdateHealth()
	{
		healthText.text = "Your health: " + currentHealth;
	}

	public static int GetCurrentHealth()
	{
		return currentHealth;
	}
}
