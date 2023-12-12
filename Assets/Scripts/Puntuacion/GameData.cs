using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
	public int puntuacionArriba;
	public int puntuacionAbajo;

	public int puntuacionMaximaArriba;
	public int puntuacionMaximaAbajo;

	public GameData()
	{
		puntuacionArriba = 0;
		puntuacionAbajo = 0;
		puntuacionMaximaArriba = 0;
	    puntuacionMaximaAbajo = 0;

		if (puntuacionArriba > puntuacionMaximaArriba)
        {
			puntuacionMaximaArriba = puntuacionArriba;
		}
		if (puntuacionAbajo > puntuacionMaximaAbajo)
		{
			puntuacionMaximaAbajo = puntuacionAbajo;
		}
	}
}
