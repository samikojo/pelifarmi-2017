using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	// Seurattava kohde
	public GameObject Target;
	// Seurattavan kohteen etäisyys kamerasta
	public float Distance = 1;
	
	void Update ()
	{
		// Viittaus targetin transform-komponenttiin.
		Transform targetTransform = Target.transform;

		// Selvitetään kameran haluttu sijainti.

		// Suuntavektori
		Vector3 targetBack = targetTransform.forward * -1;

		Vector3 direction = targetTransform.up + targetBack;
		direction = direction * Distance;

		// Kameran haluttu sijainti pelimaailmassa
		Vector3 position = targetTransform.position + direction;

		transform.position = position;

		// Päivitetään kameran rotaatio.

		// Kameran tämänhetkinen rotaatio.
		Vector3 rotation = transform.eulerAngles;
		// Kopioidaan targetin rotaation y-komponentti kameran
		// rotaation y-komponenttiin.
		rotation.y = targetTransform.eulerAngles.y;
		// Asetetaan uusi rotaatio kameran transformille.
		transform.eulerAngles = rotation;
	}
}
