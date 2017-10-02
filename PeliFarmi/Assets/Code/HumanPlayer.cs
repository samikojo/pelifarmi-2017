using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : Player
{
	// Override ylikirjoittaa metodin kantaluokan toteutuksen.
	protected override void Awake()
	{
		// base.Awake suorittaa kantaluokan (Player) Awake-metodin toteutuksen.
		// Ilman tätä riviä kantaluokan Awake ei tulisi koskaan kutsutuksi, koska
		// Awaken toteutus on ylikirjoitettu tässä luokassa.
		base.Awake();

		Type = PlayerType.Human;
	}

	private void Update()
	{
		float vertical = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");
		float turn = Input.GetAxis("Turn");

		Mover.Move( new Vector3( horizontal, 0, vertical ) );
		Mover.Turn( turn );
	}
}
