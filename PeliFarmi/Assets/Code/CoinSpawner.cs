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
	// Jotta emme loisi kolikoita päällekkäin, korvasimme listan dictionarylla,
	// joka pitää kirjaa luoduista kolikoista.
	//private List<Transform> _children = new List<Transform>();

	// Avain-arvo tietorakenne. Avaimen on oltava yksilöllinen (jokainen 
	// transform on).
	private Dictionary<Transform, Coin> _coinPoints = 
		new Dictionary<Transform, Coin>();


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
				// Dictionaryyn lisättäessä meidän on lisättävä sekä avain että arvo,
				// tässä tapauksessa transform ja coin. Koska kolikoita ei vielä
				// ole luotu, käytetään arvona arvoa 'null', joka kertoo meille,
				// ettei kolikkoa vielä ole.
				_coinPoints.Add( child, null );
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

		// Etsitään ne transformit, joille ei ole vielä luotu kolikkoa.
		List<Transform> emptyPoints = new List< Transform >();

		// Dictionaryn elementit ovat tyypiltään avain-arvo -pareja 
		// (KeyValuePair).
		foreach ( KeyValuePair< Transform, Coin > keyValuePair in _coinPoints )
		{
			if ( keyValuePair.Value == null )
			{
				// Tälle transformille ei ole luotu kolikkoa vielä.
				emptyPoints.Add( keyValuePair.Key );
			}
		}
		
		if( _timer >= _spawnTime && emptyPoints.Count > 0 )
		{
			// Ajastin kului "loppuun", luodaan kolikko.

			// Haetaan satunnainen indeksi 'emptyPoints' taulukosta, joka sisältää
			// sen sijainnin, johon kolikko luodaan.
			int randomIndex = Random.Range(0, emptyPoints.Count);

			// Tallennetaan viittaus siihen transformiin, jonka kohdalle kolikko luodaan.
			Transform pointTransform = emptyPoints[ randomIndex ];

			// Tallennetaan kolikon tuleva sijainti omaan muuttujaansa.
			Vector3 position = pointTransform.position;

			// Luodaan kopio CoinPrefab prefabista.
			Coin coin = Instantiate(CoinPrefab);
			// Asetetaan kolikko oikeaan sijaintiin.
			coin.transform.position = position;

			// Lisätään Dictionaryyn viittaus luomaamme kolikkoon avaimen pointTransform
			// kohdalle.
			_coinPoints[ pointTransform ] = coin;

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

	public Coin GetClosestCoin(Vector3 position)
	{
		List<Coin> coins = GetCoins();
		Coin closest = null;
		float minDistance = float.PositiveInfinity;

		// Käydään kaikki pelimaailmassa olevat kolokot läpi ja etsitään niistä se,
		// joka on lähinnä pistettä 'position'.
		foreach(Coin coin in coins)
		{
			float distance = Vector3.Distance(position, coin.transform.position);
			if(distance < minDistance)
			{
				// Mikäli löydettiin lähempänä oleva kolikko, tallennetaan muuttujaan 'closest'
				// viittaus siihen. Päivitetään myös 'minDistance' muuttujan arvo.
				closest = coin;
				minDistance = distance;
			}
		}

		return closest;
	}

	private List<Coin> GetCoins()
	{
		List<Coin> coins = new List<Coin>();
		// Kolikot on tallennettu Dictionary-tietorakenteeseen. Dictionary sisältää
		// avain-arvo -pareja. _coinPoints dictionaryn tapauksessa avain on tyyppiä
		// Transform ja arvo Coin. Tässä metodissa haemme viittaukset kaikkiin 
		// dictionaryssa oleviin Coin-tyyppisiin olioihin.
		foreach(KeyValuePair<Transform, Coin> coinPoint in _coinPoints)
		{
			if(coinPoint.Value != null)
			{
				coins.Add(coinPoint.Value);
			}
		}

		return coins;
	}
}
