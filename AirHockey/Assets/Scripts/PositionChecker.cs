using UnityEngine;
using System.Collections;

public class PositionChecker : MonoBehaviour {
	GameObject WestWall;
	GameObject NorthWall;
	GameObject EastWall;
	GameObject SouthWall;

	float WallSize = 2.0f; 

	float westX;
	float eastX;
	float northZ;
	float southZ;
	// Use this for initialization
	void Start () {
		WestWall = GameObject.Find ("WestWall");
		NorthWall = GameObject.Find ("NorthWall");
		EastWall = GameObject.Find ("EastWall");
		SouthWall = GameObject.Find ("SouthWall");

		westX = WestWall.transform.position.x;
		eastX = EastWall.transform.position.x;
		northZ = NorthWall.transform.position.z;
		southZ = SouthWall.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		float currentX = transform.position.x;
		float currentZ = transform.position.z;

		Vector3 newPosition = transform.position;
		if (currentX <= westX)
		{
			newPosition.x = westX + WallSize;
		}
		else if(currentX >= eastX)
		{
			newPosition.x = eastX - WallSize;
		}

		if (currentZ <= southZ)
		{
			newPosition.z = southZ + WallSize;
		}
		else if (currentZ >= northZ)
		{
			newPosition.z = northZ - WallSize;
		}

		transform.position = newPosition;

	}
}
