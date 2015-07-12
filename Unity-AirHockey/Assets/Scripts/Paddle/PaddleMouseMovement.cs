using UnityEngine;
using System.Collections;

public class PaddleMouseMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	public float Speed = 10.0F;
	// Update is called once per frame
	void Update () {
		float oneThourthPositionZ = -5.0f;

		float oldPaddlePositionZ = transform.position.z;

		float translationVertical = Input.GetAxis("Mouse Y") * Speed;
		translationVertical *= Time.deltaTime;
		
		float translationHorizontal = Input.GetAxis("Mouse X") * Speed;
		translationHorizontal *= Time.deltaTime;
	
		transform.Translate(translationHorizontal, 0, translationVertical);

		float newPaddlePositionZ = transform.position.z;

		// change the position only if paddle is above 1/4 part of the board
		if (oldPaddlePositionZ > oneThourthPositionZ && newPaddlePositionZ > oldPaddlePositionZ) 
		{
			float newPaddlePositionX = transform.position.x;
			float newPaddlePositionY = transform.position.y;
			transform.position = new Vector3(newPaddlePositionX, newPaddlePositionY, oldPaddlePositionZ);
		}
	}
}
