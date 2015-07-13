using UnityEngine;
using System.Collections;

public class PositionChecker : MonoBehaviour {
	private float _wallSize = 2.0f; 

	private float _westX;
	private float _eastX;
	private float _northZ;
	private float _southZ;
	// Use this for initialization
	void Start () {
		var westWall = GameObject.Find ("WestWall");
		var northWall = GameObject.Find ("NorthWall");
		var eastWall = GameObject.Find ("EastWall");
		var southWall = GameObject.Find ("SouthWall");

		_westX = westWall.transform.position.x;
		_eastX = eastWall.transform.position.x;
		_northZ = northWall.transform.position.z;
		_southZ = southWall.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		float currentX = transform.position.x;
		float currentZ = transform.position.z;

		Vector3 newPosition = transform.position;
		if (currentX <= _westX)
		{
			newPosition.x = _westX + _wallSize;
		}
		else if(currentX >= _eastX)
		{
			newPosition.x = _eastX - _wallSize;
		}

		if (currentZ <= _southZ)
		{
			newPosition.z = _southZ + _wallSize;
		}
		else if (currentZ >= _northZ)
		{
			newPosition.z = _northZ - _wallSize;
		}

		transform.position = newPosition;

	}
}
