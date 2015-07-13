using UnityEngine;
using System.Collections;

public class CircleMovementWithJumping : MonoBehaviour {

	public float Speed = 4.0f;

	private float _rotationSpeed = 1.5f;

	private float _percentageOfJumpChance = 1.0f;
	private float _jumpSpeed = 3.0f;

	private float _heightOfJump = 1.5f;

	private float _lowerBorderOfJump;
	private float _upperBorderOfJump;


	// Use this for initialization
	void Start () {
		_lowerBorderOfJump = transform.position.y;
		_upperBorderOfJump = _lowerBorderOfJump + _heightOfJump;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	bool isDuringJump = false;
	bool goingUpDuringJump = true;

	void FixedUpdate () {
		transform.Translate(Vector3.forward * Time.deltaTime * Speed); // move forward
		transform.Rotate(0, _rotationSpeed,0);

		if (!isDuringJump)
		{
			int randomNumber = Random.Range(1, 100);
			if (_percentageOfJumpChance >= randomNumber)
			{
				isDuringJump = true;
				goingUpDuringJump = true;
			}
		}

		if (isDuringJump) 
		{
			if (goingUpDuringJump)
			{
				transform.Translate(Vector3.up * Time.deltaTime * _jumpSpeed);
				if (transform.position.y >= _upperBorderOfJump)
				{
					goingUpDuringJump = false;
				}
			}
			else
			{
				transform.Translate(Vector3.down * Time.deltaTime * _jumpSpeed);
				if (transform.position.y <= _lowerBorderOfJump)
				{
					goingUpDuringJump = true;
					isDuringJump = false;
				}
			}
		}

	}
}
