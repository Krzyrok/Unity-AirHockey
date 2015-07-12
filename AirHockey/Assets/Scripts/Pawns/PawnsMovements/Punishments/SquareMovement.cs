using UnityEngine;
using System.Collections;

public class SquareMovement : MonoBehaviour {

	public float Speed = 5.0f;

	float yRotation = 90f;
	float sideLength = 6.0f;
	
	// corners for square position
	float LDX; // left down X
	float LDZ; // left down Z

	float RUX; // right up X
	float RUZ; // right up Z


	// Use this for initialization
	void Start () {
		LDX = transform.position.x;
		LDZ = transform.position.z;
		RUX = LDX + sideLength;
		RUZ = LDZ + sideLength;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * Speed * Time.deltaTime);
		float xPosition = transform.position.x;
		float zPosition = transform.position.z;

		if (xPosition < LDX || xPosition > RUX || zPosition < LDZ || zPosition > RUZ)
		{
			transform.Translate (Vector3.back * Speed * Time.deltaTime);
			transform.Rotate(0, yRotation, 0);
		}
	}
}
