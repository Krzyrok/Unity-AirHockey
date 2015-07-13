using UnityEngine;
using System.Collections;

public class PuckMovement : MonoBehaviour {
	
	public static float ForceOfCollisionWithPaddle = 10.0f;
	public static float ForceOfCollisionWithEdge = 2.0f;
	public static float ForceOfCollisionWithPawn = 2.0f;

	public float SpeedOfPuckFalling = 0.1f; // speed of falling to the down of the board

	private float _velocityMultiplier = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// add force to the down - against situation when puck will stuck on top of the board
	void FixedUpdate () {
		GetComponent<Rigidbody>().AddForce (Vector3.back * SpeedOfPuckFalling, ForceMode.Force);
	}

	void OnCollisionEnter(Collision collisionObject)
	{
		if (collisionObject.gameObject.name == "PaddleBase") 
		{
			Vector3 tranformVector = transform.position - collisionObject.transform.position;
			tranformVector.y = 0.0f;
			Vector3 paddleVelocity = _velocityMultiplier * collisionObject.relativeVelocity;
			paddleVelocity.y = 0.0f;
			GetComponent<Rigidbody>().AddForce ((tranformVector + paddleVelocity) * ForceOfCollisionWithPaddle, ForceMode.Force);
		}
		else if (CheckIfCollisionObjectIsSideWall(collisionObject)) 
		{
			Vector3 tranformVector = GetComponent<Rigidbody>().velocity;
			tranformVector.x = -tranformVector.x;
			tranformVector.y = 0.0f;
			GetComponent<Rigidbody>().AddForce (tranformVector * ForceOfCollisionWithEdge, ForceMode.VelocityChange);
		}
		else if (CheckIfCollisionObjectIsTopBottomWall(collisionObject)) 
		{
			Vector3 tranformVector = GetComponent<Rigidbody>().velocity;
			tranformVector.z = -tranformVector.z;
			tranformVector.y = 0.0f;
			GetComponent<Rigidbody>().AddForce (tranformVector * ForceOfCollisionWithEdge, ForceMode.VelocityChange);
		}
		else if(CheckIfCollisionObjectIsPawn(collisionObject))
		{
			Vector3 tranformVector = transform.position - collisionObject.transform.position;
			tranformVector.y = 0.0f;
			GetComponent<Rigidbody>().AddForce (tranformVector * ForceOfCollisionWithPawn, ForceMode.Force);
		}
	}

		void OnCollisionStay(Collision collisionObject)
		{
			if (collisionObject.gameObject.name == "PaddleBase") 
			{
				Vector3 tranformVector = transform.position - collisionObject.transform.position;
				tranformVector.y = 0.0f;
				GetComponent<Rigidbody>().AddForce (tranformVector * ForceOfCollisionWithPaddle, ForceMode.Force);
			}
		}

	private bool CheckIfCollisionObjectIsSideWall(Collision collisionObject)
	{
		if (collisionObject.gameObject.name == "EastWall"
		    || collisionObject.gameObject.name == "WestWall") 
		{
			return true;
		}

		return false;
	}

	private bool CheckIfCollisionObjectIsTopBottomWall(Collision collisionObject)
	{
		if (collisionObject.gameObject.name == "SouthWall"
		    || collisionObject.gameObject.name == "NorthWall") 
		{
			return true;
		}
		
		return false;
	}

	private bool CheckIfCollisionObjectIsPawn(Collision collisionObject)
	{
		if (collisionObject.gameObject.name == "FasterPuckPunishment"
		    || collisionObject.gameObject.name == "BiggerGatePunishment"
		    || collisionObject.gameObject.name == "SmallerGateBonus"
		    || collisionObject.gameObject.name == "SlowerPuckBonus"
		    || collisionObject.gameObject.name == "DoublePackBonus") 
		{
			return true;
		}
		
		return false;
	}
}
