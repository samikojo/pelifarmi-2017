using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
	// Tekstikomponentti, johon asetetaan pelaajan pistemäärä.
	private Text _text;
	private Player _player;

	private void Awake()
	{
		// Haetaan viittaus tässä GameObjectissa olevaan Text-tyyppiseen
		// komponenttiin.
		_text = GetComponent<Text>();
	}

	// Use this for initialization
	void Start () {
		// TODO: Korjaa tämä! Nyt ei toimi kuin ihmis-tyyppisille pelaajille.
		_player = Player.GetPlayer(PlayerType.Human);
	}
	
	// Update is called once per frame
	void Update () {
		int score = _player.Score.GetCurrentScore();
		_text.text = "Score: " + score;
	}
}
