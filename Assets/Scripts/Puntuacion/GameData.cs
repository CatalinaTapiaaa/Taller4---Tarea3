using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
	public int puntuacion;
	public int puntuacionMaxima;

	public GameData()
	{
		puntuacion = 0;
		puntuacionMaxima = 0;

		if (puntuacion > puntuacionMaxima)
        {
			puntuacionMaxima = puntuacion;
		}
	}
}
