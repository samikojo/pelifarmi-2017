using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
	private Text _text;

	private void Awake()
	{
		_text = GetComponentInChildren<Text>(true);
		// Asetetaan GameOver ikkuna inaktiiviseksi, kun peli alkaa.
		gameObject.SetActive(false);
	}

	// Näyttää GameOver ikkunan ja tulostaa voittavan pelaajan nimen tähän ikkunaan.
	public void Show( Player winner )
	{
		_text.text = "Game Over!\n" + winner.name + " wins!";
		gameObject.SetActive(true);
	}
}
