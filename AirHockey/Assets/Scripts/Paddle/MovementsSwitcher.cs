using UnityEngine;
using System.Collections;

public class MovementsSwitcher : MonoBehaviour {
	// Use this for initialization
	public GameObject MovingObject;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.C))
		{
			bool isMouseEnabled = MovingObject.GetComponent<PaddleMouseMovement>().enabled;
			MovingObject.GetComponent<PaddleMouseMovement>().enabled = !isMouseEnabled;

			bool isArrowsEnabled = MovingObject.GetComponent<PaddleArrowsMovement>().enabled;
			MovingObject.GetComponent<PaddleArrowsMovement>().enabled = !isArrowsEnabled;
		}
	}
}
