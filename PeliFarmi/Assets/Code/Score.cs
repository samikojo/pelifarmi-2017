using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
	private int _score = 0;

	public void AddScore(int amount)
	{
		// Sama kuin
		// _score = _score + amount;
		_score += amount;
	}

	public int GetCurrentScore()
	{
		// Palauttaa muuttujan _score arvon
		return _score;
	}
}
