using UnityEngine;
using System.Collections;

public class PawnGenerator : MonoBehaviour {

	public float Duration = 5.0f; // duration between next generated pawn

	public GameObject FirstPawn;
	public GameObject SecondtPawn;
	public GameObject ThirdPawn;
	public GameObject ThourthPawnWithForces;
	public GameObject FifthPawnWithForces;

	private float _yPosition = 0.35f;
	private float _wallSize = 2.0f; 
	
	private float _westX;
	private float _eastX;
	private float _northZ;
	private float _southZ;
	
	float timeToNextPawn;
	// Use this for initialization
	void Start () {
		timeToNextPawn = Duration;

		var westWall = GameObject.Find ("WestWall");
		var northWall = GameObject.Find ("NorthWall");
		var eastWall = GameObject.Find ("EastWall");
		var southWall = GameObject.Find ("SouthWall");
		
		_westX = westWall.transform.position.x;
		_eastX = eastWall.transform.position.x;
		_northZ = northWall.transform.position.z;
		_southZ = (northWall.transform.position.z - southWall.transform.position.z) / 4.0f + southWall.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		timeToNextPawn -= Time.deltaTime;

		if (timeToNextPawn <= 0.0f)
		{
			timeToNextPawn = Duration;
			int randomNumber = Random.Range(1, 6);
			switch (randomNumber)
			{
			case 1:
				Instantiate(FirstPawn);
				break;
			case 2:
				Instantiate(SecondtPawn);
				break;
			case 3:
				Instantiate(ThirdPawn);
				break;
			case 4:
				Instantiate(ThourthPawnWithForces, GetRandomPosition(), GetRandomQuaternion());
				break;
			case 5:
				Instantiate(FifthPawnWithForces, GetRandomPosition(), GetRandomQuaternion());
				break;
			}
		}
	}

	private Vector3 GetRandomPosition()
	{
		Vector3 result = new Vector3();
		result.x = Random.Range (_westX + _wallSize, _eastX - _wallSize);
		result.z = Random.Range (_southZ + _wallSize, _northZ - _wallSize);

		result.y = _yPosition;

		return result;
	}

	private Quaternion GetRandomQuaternion()
	{
		int randomX = Random.Range (-100, 100);
		int randomZ = Random.Range (-100, 100);
		Quaternion result = new Quaternion (randomX, 0, randomZ, 0);
		return result;
	}
}
