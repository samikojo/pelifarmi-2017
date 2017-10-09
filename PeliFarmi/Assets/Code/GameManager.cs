using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager _current;

	public static GameManager Current
	{
		get { return _current; }
	}

	// Aika, jonka jälkeen peli päättyy (sekunteina).
	public float MaxTime = 60;

	// Pisteraja, jonka jälkeen peli päättyy.
	public int TargetScore = 100;

	// Kauanko peli on ollut käynnissä.
	private float _currentTime = 0;

	// Kertoo, onko peli käynnissä vai ei.
	private bool _isRunning = false;

	// Viittaus scenessä olevaan CoinSpawneriin.
	private CoinSpawner _coinSpawner;

	private void Awake()
	{
		_current = this;
	}

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

		// Peli pysyy käynnissä niin kauan, kun ajastin ei ole saavuttanut arvoa 0 ja
		// yksikään pelaaja ei ole saavuttanut tavoitepistemäärää.
		_isRunning = UpdateTimer() == true && GetWinner() == null;

		// Jos peli päättyy, kutsutaan GameOver metodia.
		if(_isRunning == false)
		{
			GameOver();
		}
	}

	private void GameOver()
	{
		// Yritetään löytää pelaaja, joka on saavuttanut maksimipistemäärän.
		Player winner = GetWinner();
		if(winner == null)
		{
			// Jos kukaan pelaajista ei ole saavuttanut maksimipistemäärää, etsitään pelaaja,
			// jolla on eniten pisteitä.
			winner = GetLeadingPlayer();
		}

		// Välitetään voittanut pelaaja UI:lle GameOver-ikkunan näyttämistä varten.
		UI.Current.ShowGameOver(winner);
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

	private Player GetLeadingPlayer()
	{
		Player leadingPlayer = null;
		int maxScore = 0;
		List<Player> allPlayers = Player.GetAllPlayers();

		foreach(Player player in allPlayers)
		{
			if(player.Score.GetCurrentScore() > maxScore)
			{
				leadingPlayer = player;
				maxScore = player.Score.GetCurrentScore();
			}
		}

		return leadingPlayer;
	}

	// Palauttaa jäljellä olevan ajan.
	public float GetCurrentTime()
	{
		return _currentTime;
	}

	public CoinSpawner GetCoinSpawner()
	{
		if(_coinSpawner == null)
		{
			_coinSpawner = FindObjectOfType<CoinSpawner>();
		}
		return _coinSpawner;
	}
}
