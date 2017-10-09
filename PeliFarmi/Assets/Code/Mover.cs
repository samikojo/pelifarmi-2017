using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Luokka, joka huolehtii pelaajan hahmon liikuttamisesta.
/// </summary>
public class Mover : MonoBehaviour
{
	// Muuttujat on määritetty julkisiksi, jotta niitä voidaan muokata
	// Unitysta.

	// Kuvaa hahmon nopeutta (metriä / sekunti)
	public float Speed = 1;
	// Hahmon kääntymisnopeus (astetta / sekunti)
	public float RotationSpeed = 10;

	public void Move(Vector3 input)
	{
		Vector3 movementVector = input * Speed;
		transform.Translate(movementVector * Time.deltaTime);
	}

	public void Turn(float input)
	{
		// Otetaan tämänhetkinen rotaatio talteen.
		Vector3 rotation = transform.eulerAngles;
		// Päivitetään rotaation y-komponenttia
		rotation.y = rotation.y + input * Time.deltaTime * RotationSpeed;
		// Asetetaan uusi rotaatio.
		transform.eulerAngles = rotation;
	}

	public void MoveForward()
	{
		transform.Translate(transform.forward * Speed * Time.deltaTime, Space.World);
	}

	public void RotateTowards(Vector3 targetPosition)
	{
		// Määritetään suunta, johon käännetään vastustajakuutio.
		Vector3 direction = (targetPosition - transform.position).normalized;
		// Luodaan rotaatio, jonka asettamalla kuutiolle saadaan kuutio käännettyä
		// haluamaamme suuntaan.
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		// Käännetään kuutio asettamalla rotaatio Slerp-metodin avulla.
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,
			Time.deltaTime * RotationSpeed);
	}
}
