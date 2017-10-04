using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
	private static UI _current;

	// Palauttaa viittauksen skenessä olevaan UI-olioon.
	public static UI Current
	{
		get { return _current; }
	}

	private UIGameOver _gameOver;

	private void Awake()
	{
		_current = this;
		_gameOver = GetComponentInChildren<UIGameOver>(true);
	}

	// Käyttää UIGameOver-oliota, joka on tallennettu muuttujaan _gameOver GameOver 
	// ikkunan näyttämiseksi.
	public void ShowGameOver( Player winner )
	{
		_gameOver.Show(winner);
	}
}
