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

	private float _timeToEndOfBonus;

	enum BonusType { None, DoublePack, SlowerPuck, SmallerGate, BiggerGate, FasterPuck }
	BonusType _currentBonusType;

	// Use this for initialization
	void Start () {
		_timeToEndOfBonus = BonusDurationInitialTime;
	}
	
	// Update is called once per frame
	void Update () {
		_timeToEndOfBonus -= Time.deltaTime;

		if(_timeToEndOfBonus <= 0.0f)
		{
			switch (_currentBonusType)
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
		_currentBonusType = BonusType.DoublePack;
	}

	public void StartSlowerPuck()
	{
		if (PuckMovement.ForceOfCollisionWithPaddle - AdditionForceForPuckBonus >= MaximumForce)
		{
			Destroy(gameObject);
			return;
		}
		
		PuckMovement.ForceOfCollisionWithPaddle -= AdditionForceForPuckBonus;

		_currentBonusType = BonusType.SlowerPuck;
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
		_currentBonusType = BonusType.SmallerGate;
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
		_currentBonusType = BonusType.BiggerGate;
	}

	public void StartFasterPuck()
	{
		if (PuckMovement.ForceOfCollisionWithPaddle + AdditionForceForPuckBonus >= MaximumForce)
		{
			Destroy(gameObject);
			return;
		}

		PuckMovement.ForceOfCollisionWithPaddle += AdditionForceForPuckBonus;
		
		_currentBonusType = BonusType.FasterPuck;
	}



	private void StopDoublePack()
	{
		Destroy (gameObject);
	}

	private void StopSlowerPuck()
	{
		PuckMovement.ForceOfCollisionWithPaddle += AdditionForceForPuckBonus;
		Destroy (gameObject);
	}

	private void StopSmallerGate()
	{
		GameObject gateObject = GameObject.Find ("Gate");
		Vector3 scale = gateObject.transform.localScale;	
		scale.x += AdditionXScaleForGate;
		gateObject.transform.localScale = scale;

		Destroy (gameObject);
	}

	private void StopBiggerGate()
	{
		GameObject gateObject = GameObject.Find ("Gate");
		Vector3 scale = gateObject.transform.localScale;	
		scale.x -= AdditionXScaleForGate;
		gateObject.transform.localScale = scale;

		Destroy (gameObject);
	}

	private void StopFasterPuck()
	{
		PuckMovement.ForceOfCollisionWithPaddle -= AdditionForceForPuckBonus;
		Destroy (gameObject);
	}
}
