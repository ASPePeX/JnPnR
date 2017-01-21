using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float currentPitch;
    public float currentPitchHeight;

	void Update ()
	{
	    for (int i = 0; i < Config.NumberOfBands; i++)
	    {
	        currentPitch += AudioAnalyzer.GetScaledOutput(i, 0f, 1f);
	    }

	    currentPitch = currentPitch / Config.NumberOfBands;

	    if (Math.Abs(currentPitch) < float.Epsilon)
	    {
	        currentPitch = -1;
	    }

	    currentPitchHeight = Config.PitchSpan * currentPitch;
	}
}
