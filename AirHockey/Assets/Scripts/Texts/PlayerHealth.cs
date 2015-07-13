using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public static int InitialHealth = 3;

	private static int _currentHealth;
	private static Text _healthText;
	// Use this for initialization
	void Start () {
		_currentHealth = InitialHealth;
		_healthText = GetComponent<Text>();
		UpdateHealth();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void DecreaseHealth()
	{
		_currentHealth--;
		UpdateHealth ();
	}

	public static void UpdateHealth()
	{
		_healthText.text = "Your health: " + _currentHealth;
	}

	public static int GetCurrentHealth()
	{
		return _currentHealth;
	}
}
