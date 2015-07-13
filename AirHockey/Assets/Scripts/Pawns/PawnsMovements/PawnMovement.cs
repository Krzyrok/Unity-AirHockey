using UnityEngine;
using System.Collections;

public class PawnMovement : MonoBehaviour {

	public float ForceOfCollision = 25.0f;
	public float ForceOfRegularMovement = 0.001f;
	public float RotationAngleForStuckSituation = 90.0f;
	public float ForceOfCollisionWithEdge = 2.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		GetComponent<Rigidbody>().AddForce(transform.forward * ForceOfRegularMovement, ForceMode.Force);
	}

	void OnCollisionEnter(Collision collisionObject)
	{
		if (CheckIfCollisionObjectIsSideWall(collisionObject)) 
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
		}// if happened collision with another pawn or puck
		else if (collisionObject.gameObject.name != "BoardGround") 
		{
			Vector3 tranformVector = transform.position - collisionObject.transform.position;
			tranformVector.y = 0.0f;
			GetComponent<Rigidbody>().AddForce(tranformVector * ForceOfCollision, ForceMode.Force);
		}
	}

	// for situation if pawn will stuck in corner
	int _counter = 0;
	int _maxValueOfCounter = 50;
	void OnCollisionStay(Collision collisionObject)
	{
		if (collisionObject.gameObject.name == "BoardGround")
						return;
		if(_counter < _maxValueOfCounter)
		{
			_counter++;
			return;
		}
		_counter = 0;
		// if happened collision with another pawn, puck or board edge
		transform.Rotate(0, RotationAngleForStuckSituation, 0);
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
				|| collisionObject.gameObject.name == "NorthWall") {
				return true;
		}

		return false;
	}
}
