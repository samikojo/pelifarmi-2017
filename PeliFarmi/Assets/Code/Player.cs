using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
	Human,
	Computer
}

// Avainsana abstract estää olioiden luomisen tästä luokasta.
// Tämän vuoksi tästä luokasta pitää periä toinen, ei abstrakti luokka,
// joka perii tämän luokan.
//
// RequireComponent attribuutti kertoo Unitylle, minkä tyyppisistä 
// komponenteista tämä luokka on riippuvainen.
[RequireComponent(typeof(Score)), RequireComponent(typeof(Mover))]
public abstract class Player : MonoBehaviour
{
	// Staattinen muuttuja on yhteinen kaikille saman tyypin (tai perityn tyypin)
	// olioille.
	private static List<Player> _allPlayers = new List<Player>();

	public static Player GetPlayer( PlayerType type )
	{
		foreach (Player player in _allPlayers)
		{
			if(player.Type == type)
			{
				return player;
			}
		}

		return null;
	}

	public static List<Player> GetAllPlayers()
	{
		return _allPlayers;
	}

	private Mover _mover;
	private Score _score;

	public PlayerType Type
	{
		get;
		protected set;
	}

	/// <summary>
	/// Tämä property mahdollistaa _score muuttujan arvon lukemisen luokan
	/// ulkopuolelta, mutta ei mahdollista arvon muuttamista, koska setteriä
	/// ei ole määritelty.
	/// </summary>
	public Score Score
	{
		get { return _score; }
	}

	/// <summary>
	/// Protected propertyn arvon voi lukea vain tämän luokan perivistä luokista.
	/// Arvoa ei voi asettaa tämän luokan ulkopuolelta, koska propertyssä ei ole
	/// määritelty setteriä.
	/// </summary>
	protected Mover Mover
	{
		get { return _mover; }
	}

	// Virtual tarkoittaa sitä, että tämän metodin toteutus voidaan määrittää
	// uudelleen luokissa, jotka perivät tämän luokan.
	protected virtual void Awake()
	{
		_allPlayers.Add(this);

		_score = GetComponent<Score>();
		_mover = GetComponent<Mover>();
	}
}
