using UnityEngine;
using System.Collections;

public class PawnCollisionTrigger : MonoBehaviour {

	public float ForceOfCollision = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OntriggerEnter(Collider colliderObject)
	{
		string colliderObjectName = colliderObject.gameObject.name;
		if (colliderObjectName != "BoardGround")
		{
			Vector3 tranformVector = transform.position - colliderObject.transform.position;
			tranformVector.y = 0.0f;
			transform.Translate (tranformVector * ForceOfCollision);
		}
	}
}
