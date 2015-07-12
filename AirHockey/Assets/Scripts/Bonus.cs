using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {

	public float BonusDurationInitialTime = 10.0f;
	public GameObject PuckObject;
	public float AdditionForceForPuckBonus = 10.0f;
	public float AdditionXScaleForGate = 2.0f;

	public float MaximumForce = 50.0f;
	public float MaximumGateXScale = 10.0f;
	public float MinimumGateXScale = 0.5f;

	float timeToEndOfBonus;

	enum BonusType { None, DoublePack, SlowerPuck, SmallerGate, BiggerGate, FasterPuck }
	BonusType currentBonusType;

	// Use this for initialization
	void Start () {
		timeToEndOfBonus = BonusDurationInitialTime;
	}
	
	// Update is called once per frame
	void Update () {
		timeToEndOfBonus -= Time.deltaTime;

		if(timeToEndOfBonus <= 0.0f)
		{
			switch (currentBonusType)
			{
			case BonusType.DoublePack:
				StopDoublePack();
				break;
			case BonusType.SlowerPuck:
				StopSlowerPuck();
				break;
			case BonusType.SmallerGate:
				StopSmallerGate();
				break;
			case BonusType.BiggerGate:
				StopBiggerGate();
				break;
			case BonusType.FasterPuck:
				StopFasterPuck();
				break;
			}
		}
	}

	public void StartDoublePack()
	{
		Instantiate (PuckObject);
		currentBonusType = BonusType.DoublePack;
	}

	public void StartSlowerPuck()
	{
		if (PuckMovement.ForceOfCollisionWithPaddle - AdditionForceForPuckBonus >= MaximumForce)
		{
			Destroy(gameObject);
			return;
		}
		
		PuckMovement.ForceOfCollisionWithPaddle -= AdditionForceForPuckBonus;

		currentBonusType = BonusType.SlowerPuck;
	}

	public void StartSmallerGate()
	{
		GameObject gateObject = GameObject.Find ("Gate");
		if (gateObject.transform.localScale.x - AdditionXScaleForGate <= MinimumGateXScale) 
		{
			Destroy(gameObject);
			return;
		}
		Vector3 scale = gateObject.transform.localScale;

		scale.x -= AdditionXScaleForGate;

		gateObject.transform.localScale = scale;
		currentBonusType = BonusType.SmallerGate;
	}

	public void StartBiggerGate()
	{
		GameObject gateObject = GameObject.Find ("Gate");
		if (gateObject.transform.localScale.x + AdditionXScaleForGate >= MaximumGateXScale) 
		{
			Destroy(gameObject);
			return;
		}
		Vector3 scale = gateObject.transform.localScale;

		scale.x += AdditionXScaleForGate;

		gateObject.transform.localScale = scale;
		currentBonusType = BonusType.BiggerGate;
	}

	public void StartFasterPuck()
	{
		if (PuckMovement.ForceOfCollisionWithPaddle + AdditionForceForPuckBonus >= MaximumForce)
		{
			Destroy(gameObject);
			return;
		}

		PuckMovement.ForceOfCollisionWithPaddle += AdditionForceForPuckBonus;
		
		currentBonusType = BonusType.FasterPuck;
	}



	void StopDoublePack()
	{
		Destroy (gameObject);
	}

	void StopSlowerPuck()
	{
		PuckMovement.ForceOfCollisionWithPaddle += AdditionForceForPuckBonus;
		Destroy (gameObject);
	}

	void StopSmallerGate()
	{
		GameObject gateObject = GameObject.Find ("Gate");
		Vector3 scale = gateObject.transform.localScale;	
		scale.x += AdditionXScaleForGate;
		gateObject.transform.localScale = scale;

		Destroy (gameObject);
	}

	void StopBiggerGate()
	{
		GameObject gateObject = GameObject.Find ("Gate");
		Vector3 scale = gateObject.transform.localScale;	
		scale.x -= AdditionXScaleForGate;
		gateObject.transform.localScale = scale;

		Destroy (gameObject);
	}

	void StopFasterPuck()
	{
		PuckMovement.ForceOfCollisionWithPaddle -= AdditionForceForPuckBonus;
		Destroy (gameObject);
	}
}
