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
}
