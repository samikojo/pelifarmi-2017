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
		string text = "Game Over!";
		if(winner != null)
		{
			// Jos voittaja löytyi, lisätään tämän nimi näytölle tulostettavaan
			// viestiin.
			text += "\n" + winner.name + " wins!";
		}

		// Sijoitetaan merkkijono Text-komponentille, jotta Unity osaa piirtää sen UI:lle.
		_text.text = text;

		// Lopuksi aktivoidaan GameOver-näkymä.
		gameObject.SetActive(true);
	}
}
