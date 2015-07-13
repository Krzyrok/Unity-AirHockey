using UnityEngine;
using System.Collections;

public class SquareMovement : MonoBehaviour {

	public float Speed = 5.0f;

	private float _yRotation = 90f;
	private float _sideLength = 6.0f;
	
	// corners for square position
	private float _leftBottomX; 
	private float _leftBottomZ;
	private float _ritghtTopX; // right up X
	private float _ritghtTopZ; // right up Z


	// Use this for initialization
	void Start () {
		_leftBottomX = transform.position.x;
		_leftBottomZ = transform.position.z;
		_ritghtTopX = _leftBottomX + _sideLength;
		_ritghtTopZ = _leftBottomZ + _sideLength;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * Speed * Time.deltaTime);
		float xPosition = transform.position.x;
		float zPosition = transform.position.z;

		if (xPosition < _leftBottomX || xPosition > _ritghtTopX || zPosition < _leftBottomZ || zPosition > _ritghtTopZ)
		{
			transform.Translate (Vector3.back * Speed * Time.deltaTime);
			transform.Rotate(0, _yRotation, 0);
		}
	}
}
