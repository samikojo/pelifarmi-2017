using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
	private Text _text;

	private void Awake()
	{
		// Parametri true tarkoittaa tässä sitä, että komponenttia haetaan myös 
		// inactiivisista lapsiolioista.
		_text = GetComponentInChildren<Text>(true);
	}

	// Update is called once per frame
	void Update ()
	{
		// Haetaan aika scenessä olevalta GameManagerilta staattista Current
		// propertyä käyttäen.
		float time = GameManager.Current.GetCurrentTime();
		int minutes = (int)time / 60;
		int seconds = (int)time % 60;
		_text.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
	}
}
