using UnityEngine;
using System.Collections;

public class PawnGenerator : MonoBehaviour {

	public float Duration = 5.0f; // duration between next generated pawn

	public GameObject FirstPawn;
	public GameObject SecondtPawn;
	public GameObject ThirdPawn;
	public GameObject ThourthPawnWithForces;
	public GameObject FifthPawnWithForces;

	float yPosition = 0.35f;

	GameObject WestWall;
	GameObject NorthWall;
	GameObject EastWall;
	GameObject SouthWall;
	
	float WallSize = 2.0f; 
	
	float westX;
	float eastX;
	float northZ;
	float southZ;
	
	float timeToNextPawn;
	// Use this for initialization
	void Start () {
		timeToNextPawn = Duration;

		WestWall = GameObject.Find ("WestWall");
		NorthWall = GameObject.Find ("NorthWall");
		EastWall = GameObject.Find ("EastWall");
		SouthWall = GameObject.Find ("SouthWall");
		
		westX = WestWall.transform.position.x;
		eastX = EastWall.transform.position.x;
		northZ = NorthWall.transform.position.z;
		southZ = (NorthWall.transform.position.z - SouthWall.transform.position.z) / 4.0f + SouthWall.transform.position.z;
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
		result.x = Random.Range (westX + WallSize, eastX - WallSize);
		result.z = Random.Range (southZ + WallSize, northZ - WallSize);

		result.y = yPosition;

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
