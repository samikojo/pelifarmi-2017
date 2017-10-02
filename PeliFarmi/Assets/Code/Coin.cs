using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Luokka Coin kuvaa pelimaailman kerättäviä objekteja, joista pelaaja saa
/// pisteitä.
/// </summary>
public class Coin : MonoBehaviour
{
	// Paljonko pisteitä kolikon keräämisestä saa
	public int Points = 1;
	// Kolikon pyörimisnopeus (astetta / sekunti)
	public float RotationSpeed = 10;

	// Unity kutsuu tätä automaattisesti, kun törmäys tapahtuu ja Collider on
	// määritetty triggeriksi.
	void OnTriggerEnter(Collider other)
	{
		// Haetaan Score-tyyppistä komponenttia
		// törmänneeltä GameObjectilta
		Score score = other.GetComponent<Score>();
		if(score != null)
		{
			// Score komponentti löytyi, kasvatetaan 
			// pelaajan pistemäärää

			score.AddScore(Points);
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		// Kolikon pyöritys y-akselin ympäri. Kommenteissa vaihtoehtoinen tapa
		// toteuttaa sama toiminnallisuus.

		//Vector3 rotation = transform.eulerAngles;
		//rotation.y += RotationSpeed * Time.deltaTime;
		//transform.eulerAngles = rotation;

		transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime,
			Space.World);
	}
}
