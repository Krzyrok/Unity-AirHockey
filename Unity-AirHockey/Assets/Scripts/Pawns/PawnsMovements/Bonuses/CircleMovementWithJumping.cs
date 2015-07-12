using UnityEngine;
using System.Collections;

public class CircleMovementWithJumping : MonoBehaviour {

	public float Speed = 4.0f;
	float rotationSpeed = 1.5f;

	float percentageOfJumpChance = 1.0f;
	float jumpSpeed = 3.0f;

	float heightOfJump = 1.5f;
	float lowerBorderOfJump;
	float upperBorderOfJump;


	// Use this for initialization
	void Start () {
		lowerBorderOfJump = transform.position.y;
		upperBorderOfJump = lowerBorderOfJump + heightOfJump;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	bool isDuringJump = false;
	bool goingUpDuringJump = true;

	void FixedUpdate () {
		transform.Translate(Vector3.forward * Time.deltaTime * Speed); // move forward
		transform.Rotate(0, rotationSpeed,0);

		if (!isDuringJump)
		{
			int randomNumber = Random.Range(1, 100);
			if (percentageOfJumpChance >= randomNumber)
			{
				isDuringJump = true;
				goingUpDuringJump = true;
			}
		}

		if (isDuringJump) 
		{
			if (goingUpDuringJump)
			{
				transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed);
				if (transform.position.y >= upperBorderOfJump)
				{
					goingUpDuringJump = false;
				}
			}
			else
			{
				transform.Translate(Vector3.down * Time.deltaTime * jumpSpeed);
				if (transform.position.y <= lowerBorderOfJump)
				{
					goingUpDuringJump = true;
					isDuringJump = false;
				}
			}
		}

	}
}
