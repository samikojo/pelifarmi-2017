using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	// Muuttujat on määritetty julkisiksi, jotta niitä voidaan muokata
	// Unitysta.
	public float Speed = 1;
	public float RotationSpeed = 10;

	
	// Update is called once per frame
	void Update ()
	{
		// Luetaan käyttäjän syöte
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		// Luodaan syötteestä vektori
		Vector3 inputVector = new Vector3(horizontal, 0, vertical);
		Vector3 movementVector = inputVector * Speed;
		transform.Translate(movementVector * Time.deltaTime);

		// Luetaan syöte "Turn" akselilta
		float turn = Input.GetAxis("Turn");
		// Otetaan tämänhetkinen rotaatio talteen.
		Vector3 rotation = transform.eulerAngles;
		// Päivitetään rotaation y-komponenttia
		rotation.y = rotation.y + turn * Time.deltaTime * RotationSpeed;
		// Asetetaan uusi rotaatio.
		transform.eulerAngles = rotation;
	}

	private void FixedUpdate()
	{
		
	}
}
