using UnityEngine;
using System.Collections;

public class TriangleMovementWithSinSpeed : MonoBehaviour {

	public float InitSpeed = 5.0f;

	private float _multiplierForAdditionalSinSpeed = 2.0f;

	private float _yRotation = 120f;
	private float _sideLength = 6.0f; // for equilateral triangle
	
	// position corners for triangle
	private float _topX; 
	private float _topZ; 

	// right and left corners should be on the same "height" - they should have the same Z value
	private float _rightX; 
	private float _leftX;

	private float _bottomZ; // down/bottom Z

	private float _timeCounter = 0.0f;

	// Use this for initialization
	void Start () {
		_topX = transform.position.x;
		_topZ = transform.position.z;

		float triangleHeight = Mathf.Sqrt (_sideLength * _sideLength - 0.5f * 0.5f * _sideLength * _sideLength);
		_rightX = _topX + 0.5f * _sideLength;
		_leftX = _topX - 0.5f * _sideLength;
		_bottomZ = _topZ - triangleHeight;
	}
	
	// Update is called once per frame
	void Update () {
		_timeCounter += Time.deltaTime;
		float currentSpeed = InitSpeed + _multiplierForAdditionalSinSpeed * Mathf.Sin (_timeCounter);

		transform.Translate (Vector3.forward * currentSpeed * Time.deltaTime);
		float xPosition = transform.position.x;
		float zPosition = transform.position.z;

		if (zPosition > _topZ || zPosition < _bottomZ
		    || xPosition > _rightX || xPosition < _leftX)
		{
			transform.Translate (Vector3.back * currentSpeed * Time.deltaTime);
			transform.Rotate(0, _yRotation, 0);
		}
	}
}
