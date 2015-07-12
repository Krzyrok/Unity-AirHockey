using UnityEngine;
using System.Collections;

public class TriangleMovementWithSinSpeed : MonoBehaviour {

	public float InitSpeed = 5.0f;
	float multiplierForAdditionalSinSpeed = 2.0f;

	float yRotation = 120f;
	float sideLength = 6.0f; // for equilateral triangle
	
	// position corners for striangle
	float TX; // top X
	float TZ; // top Z

	// right and left corners should be on the same "height" - they should have the same Z value
	float RX; // right X
	float LX; // left X

	float DZ; // down/bottom Z

	float timeCounter = 0.0f;

	// Use this for initialization
	void Start () {
		TX = transform.position.x;
		TZ = transform.position.z;

		float triangleHeight = Mathf.Sqrt (sideLength * sideLength - 0.5f * 0.5f * sideLength * sideLength);
		RX = TX + 0.5f * sideLength;
		LX = TX - 0.5f * sideLength;
		DZ = TZ - triangleHeight;
	}
	
	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime;
		float currentSpeed = InitSpeed + multiplierForAdditionalSinSpeed * Mathf.Sin (timeCounter);

		transform.Translate (Vector3.forward * currentSpeed * Time.deltaTime);
		float xPosition = transform.position.x;
		float zPosition = transform.position.z;

		if (zPosition > TZ || zPosition < DZ
		    || xPosition > RX || xPosition < LX)
		{
			transform.Translate (Vector3.back * currentSpeed * Time.deltaTime);
			transform.Rotate(0, yRotation, 0);
		}
	}
}
