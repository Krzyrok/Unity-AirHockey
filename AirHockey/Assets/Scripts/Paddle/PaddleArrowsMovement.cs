using UnityEngine;
using System.Collections;

public class PaddleArrowsMovement : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		float verticalAxis = Input.GetAxis("Vertical");
		float horizontalAxis = Input.GetAxis("Horizontal");
		PaddleMovement.UpdatePosition (verticalAxis, horizontalAxis, gameObject);
	}
}
