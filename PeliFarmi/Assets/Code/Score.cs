using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Luokka, joka pit�� kirjaa pelaajalle kertyneist� pisteist�.
/// </summary>
public class Score : MonoBehaviour
{
	// Muuttuja, johon t�m�nhetkinen pistem��r� on tallennettu.
	private int _score = 0;

	/// <summary>
	/// Lis�� pisteit� pelaajalle.
	/// </summary>
	/// <param name="amount">Lis�tt�vien pisteiden m��r�</param>
	public void AddScore(int amount)
	{
		// Sama kuin
		// _score = _score + amount;
		_score += amount;
	}

	/// <summary>
	/// Palauttaa pelaajan t�m�nhetkisen pistem��r�n.
	/// </summary>
	/// <returns>Pelaajan t�m�nhetkinen pistem��r�</returns>
	public int GetCurrentScore()
	{
		// Palauttaa muuttujan _score arvon
		return _score;
	}
}
