using UnityEngine;
using System.Collections;

public class PawnHealth : MonoBehaviour {
	
	public int MaximumHealthForPawn = 3;
	public Bonus BonusObject;

	private int _initialHealth;
	private int _currentHealth;
	
	// Use this for initialization
	void Start () {
		MaximumHealthForPawn++; // because if we want max = 2 (one or two health points), we need set range from 1 to the 3; 
		
		_initialHealth = Random.Range (1, MaximumHealthForPawn);
		_currentHealth = _initialHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision collisionObject)
	{
		string collisionObjectName = collisionObject.gameObject.name;
		if (collisionObjectName == "Puck") 
		{
			_currentHealth--;
			if (_currentHealth <= 0)
			{
				CreateBonus();
				PlayerScore.AddToTheScore(_initialHealth);
				Destroy (gameObject);
			}
		}
	}

	void CreateBonus()
	{
		string bonusName = gameObject.name;

		if (bonusName == "DoublePackBonus(Clone)")
		{
			Bonus newBonus = Instantiate(BonusObject) as Bonus;
			newBonus.StartDoublePack();
		}
		else if (bonusName == "SlowerPuckBonus(Clone)")
		{
			Bonus newBonus = Instantiate(BonusObject) as Bonus;
			newBonus.StartSlowerPuck();
		}
		else if (bonusName == "SmallerGateBonus(Clone)")
		{
			Bonus newBonus = Instantiate(BonusObject) as Bonus;
			newBonus.StartSmallerGate();
		}
		else if (bonusName == "BiggerGatePunishment(Clone)")
		{
			Bonus newBonus = Instantiate(BonusObject) as Bonus;
			newBonus.StartBiggerGate();
		}
		else if (bonusName == "FasterPuckPunishment(Clone)")
		{
			Bonus newBonus = Instantiate(BonusObject) as Bonus;
			newBonus.StartFasterPuck();
		}
	}
}
