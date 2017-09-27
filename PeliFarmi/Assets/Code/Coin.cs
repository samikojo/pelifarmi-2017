using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public int Points = 1;
	public float RotationSpeed = 10;

	void OnTriggerEnter(Collider other)
	{
		// Haetaan Score-tyyppist� komponenttia
		// t�rm�nneelt� GameObjectilta
		Score score = other.GetComponent<Score>();
		if(score != null)
		{
			// Score komponentti l�ytyi, kasvatetaan 
			// pelaajan pistem��r��
			score.AddScore(Points);
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		//Vector3 rotation = transform.eulerAngles;
		//rotation.y += RotationSpeed * Time.deltaTime;
		//transform.eulerAngles = rotation;
		transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime,
			Space.World);
	}
}
