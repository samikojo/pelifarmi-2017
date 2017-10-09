using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayer : Player
{
	// Kolikko, jota kohti tietokonepelaaja pyrkii.
	private Coin _target;

	protected override void Awake()
	{
		base.Awake();
		Type = PlayerType.Computer;
	}

	void Update ()
	{
		if(_target == null)
		{
			// Haetaan viittaus scenessä olevaan CoinSpawneriin.
			CoinSpawner spawner = GameManager.Current.GetCoinSpawner();
			// Haetaan CoinSpawnerilta lähimpänä oleva kolikko.
			_target = spawner.GetClosestCoin(transform.position);
		}

		if(_target != null)
		{
			// Liikutaan kohti kohdekolikkkoa, jos se löytyy (eli scenessä on ainakin 
			// yksi kolikko).
			Mover.MoveForward();
			Mover.RotateTowards(_target.transform.position);
		}
	}
}
