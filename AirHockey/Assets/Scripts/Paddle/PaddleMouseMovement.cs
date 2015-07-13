using UnityEngine;
using System.Collections;

public class PaddleMouseMovement : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		float verticalAxis = Input.GetAxis("Mouse Y");
		float horizontalAxis = Input.GetAxis("Mouse X");
		PaddleMovement.UpdatePosition (verticalAxis, horizontalAxis, gameObject);
	}
}
