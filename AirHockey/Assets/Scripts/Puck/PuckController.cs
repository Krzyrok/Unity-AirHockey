using UnityEngine;
using System.Collections;

public class PuckController : MonoBehaviour {

	private static int _puckCounter = 0;

	// Use this for initialization
	void Start () {
		_puckCounter++;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void DecreasePuckCounter()
	{
		_puckCounter--;
	}

	public static int GetCurrentePuckCounter()
	{
		return _puckCounter;
	}
}
