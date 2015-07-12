using UnityEngine;
using System.Collections;

public class CollisionWithGate : MonoBehaviour {

	Vector3 initialPosition;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collisionObject)
	{
		if (collisionObject.gameObject.name == "Gate")
		{
			if (PuckController.GetCurrentePuckCounter() > 1)
			{
				PuckController.DecreasePuckCounter();
				Destroy(gameObject);
			}
			else
			{
				PlayerHealth.DecreaseHealth();
				transform.position = initialPosition;

				if (PlayerHealth.GetCurrentHealth() == 0)
				{
					PuckController.DecreasePuckCounter();
					Destroy(gameObject);
					GameOver.EndGame();
				}
			}
		}
	}
}
