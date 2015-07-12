using UnityEngine;
using System.Collections;

public class PuckController : MonoBehaviour {

	static int puckCounter = 0;

	// Use this for initialization
	void Start () {
		puckCounter++;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void DecreasePuckCounter()
	{
		puckCounter--;
	}

	public static int GetCurrentePuckCounter()
	{
		return puckCounter;
	}
}
