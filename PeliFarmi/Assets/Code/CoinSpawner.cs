using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
	// Viittaus kolikko-prefabiin, josta luodaan kopioita pelimaailmaan.
	public Coin CoinPrefab;

	public float MinSpawnTime;
	public float MaxSpawnTime;

	// Luodaan uusi lista, jonka tyyppi on Transform. Tähän listaan lisätään
	// viittaukset kaikkiin tämän GameObjectin lapsiobjektien Transform-
	// komponenttiin.
	private List<Transform> _children = new List<Transform>();
	// Kuvaa kauanko aikaa on kulunut siitä, kun kolikko luotiin edellisen 
	// kerran.
	private float _timer = 0;
	// Satunnaisesti arvottu aika, jonka kuluttua luodaan uusi kolikko.
	private float _spawnTime = 0;

	// Unity suorittaa Awake-metodin automaattisesti välittömästi, kun olio
	// luodaan tai scene ladataan. Awake suoritetaan ennen mitään muita
	// metodeja.
	private void Awake()
	{
		// Haetaan kaikkien lapsiolioiden Transform-komponentit.
		// Huom. GetComponentsInChildren palauttaa viittauksen myös tämän
		// GameObjectin Transform-komponenttiin.
		Transform[] children = GetComponentsInChildren<Transform>();
		foreach(Transform child in children)
		{
			// Lisätään _children-listaan viittaus kaikkiin muihin Transform-
			// komponentteihin, paitsi siihen, joka kuuluu tälle spawnerille.
			if(child != transform)
			{
				_children.Add(child);
			}
		}

		// Haetaan ensimmäinen satunnainen aika, jonka kuluttua kolikko luodaan.
		_spawnTime = GetRandomSpawnTime();
	}

	private void Update()
	{
		// Kasvatetaan timerin arvoa sillä ajalla, joka on kulunut edellisestä 
		// Update-kutsusta.
		_timer += Time.deltaTime;
		if(_timer >= _spawnTime)
		{
			// Ajastin kului "loppuun", luodaan kolikko.

			// Haetaan satunnainen indeksi '_children' taulukosta, joka sisältää
			// sen sijainnin, johon kolikko luodaan.
			int randomIndex = Random.Range(0, _children.Count);
			// Tallennetaan kolikon tuleva sijainti omaan muuttujaansa.
			Vector3 position = _children[randomIndex].position;

			// Luodaan kopio CoinPrefab prefabista.
			Coin coin = Instantiate(CoinPrefab);
			// Asetetaan kolikko oikeaan sijaintiin.
			coin.transform.position = position;

			// Alustetaan ajastin.
			_timer = 0;
			// Haetaan uusi satunnainen aika, jonka päästä seuraava kolikko luodaan.
			_spawnTime = GetRandomSpawnTime();
		}
	}

	/// <summary>
	/// Palauttaa satunnaisen ajan väliltä MinSpawnTime ja MaxSpawnTime.
	/// </summary>
	public float GetRandomSpawnTime()
	{
		float spawnTime = Random.Range(MinSpawnTime, MaxSpawnTime);
		return spawnTime;
	}
}
