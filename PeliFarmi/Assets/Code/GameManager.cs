using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// Aika, jonka jälkeen peli päättyy (sekunteina).
	public float MaxTime = 60;

	// Pisteraja, jonka jälkeen peli päättyy.
	public int TargetScore = 100;

	// Kauanko peli on ollut käynnissä.
	private float _currentTime = 0;

	// Kertoo, onko peli käynnissä vai ei.
	private bool _isRunning = false;

	// Pelin käynnistuessä alustetaan ajastin ja asetetaan _isRunning muuttujan arvoksi
	// true, jotta ajastin käynnistyisi.
	void Start ()
	{
		_currentTime = MaxTime;
		_isRunning = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(_isRunning == false)
		{
			return;
		}

		_isRunning = UpdateTimer();
	}

	// Päivittää ajastimen arvoa. Palauttaa true, kun peli on käynnissä ja kun pelin
	// pitää loppua, palauttaa false.
	private bool UpdateTimer()
	{
		// Ajastin käy lopusta alkuun. Vähennetään aikaa joka framella Time.deltaTime:lla
		// (ajalla, joka on kulunut edellisen framen suorittamisesta).
		_currentTime -= Time.deltaTime;

		if(_currentTime <= 0)
		{
			return false;
		}

		return true;
	}

	// Palauttaa viittauksen siihen pelaajaan, joka on saavuttanut maksimipistemäärän.
	// Jos kukaan ei ole vielä saanut maksimipisteitä, palauttaa null.
	private Player GetWinner()
	{
		List<Player> allPlayers = Player.GetAllPlayers();
		foreach(Player player in allPlayers)
		{
			// Onko pelaaja saavuttanut maksimipistemäärän?
			if(player.Score.GetCurrentScore() >= TargetScore)
			{
				// On, palauta viittaus pelaajaan, jonka pistemäärä on suurempi tai yhtä suuri
				// kuin 'TargetScore'.
				return player;
			}
		}

		return null;
	}
}
