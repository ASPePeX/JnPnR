using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float currentPitchHeight;
    public float amplitude;

	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.Alpha1))
	    {
	        SceneManager.LoadScene(0);
	    }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
	    {
	        SceneManager.LoadScene(1);
	    }
        else if (Input.GetKeyDown(KeyCode.Escape))
	    {
	        Application.Quit();
	    }

	    amplitude = AudioAnalyzer.GetScaledOutput(0, Config.limits.x, Config.limits.y);

            //currentPitch = float.MinValue;

            //if (amplitudeAverage > Config.AmplitudeMin)
            //{
            //       float out0 = AudioAnalyzer.GetScaledOutput(0, 0f, 1f);
            //       float out1 = AudioAnalyzer.GetScaledOutput(1, 0f, 1f);
            //       float out2 = AudioAnalyzer.GetScaledOutput(2, 0f, 1f);
            //       float out3 = AudioAnalyzer.GetScaledOutput(3, 0f, 1f);
            //       float out4 = AudioAnalyzer.GetScaledOutput(4, 0f, 1f);
            //       float out5 = AudioAnalyzer.GetScaledOutput(5, 0f, 1f);
            //       float out6 = AudioAnalyzer.GetScaledOutput(6, 0f, 1f);
            //       float out7 = AudioAnalyzer.GetScaledOutput(7, 0f, 1f);
            //       float out8 = AudioAnalyzer.GetScaledOutput(8, 0f, 1f);
            //       float out9 = AudioAnalyzer.GetScaledOutput(9, 0f, 1f);

            //       currentPitch =                out0 * 4.5f; //  12.5f Max
            //    currentPitch = currentPitch + out1 * 3.5f;
            //    currentPitch = currentPitch + out2 * 2.5f;
            //    currentPitch = currentPitch + out3 * 1.5f;
            //    currentPitch = currentPitch + out4 * 0.5f;
            //    currentPitch = currentPitch - out5 * 0.5f;
            //    currentPitch = currentPitch - out6 * 1.5f;
            //    currentPitch = currentPitch - out7 * 2.5f;
            //    currentPitch = currentPitch - out8 * 3.5f;
            //    currentPitch = currentPitch - out9 * 4.5f; // -12.5f Min

            //    currentPitch = (currentPitch + 12.5f) / 25f;
            //   }

            //currentPitchHeight = Config.PitchSpan * currentPitch;
	    if (amplitude > Config.AmplitudeMin)
	    {
	        currentPitchHeight = Config.PitchSpan * amplitude;
	    }
	    else
	    {
	        currentPitchHeight = float.MinValue;
	    }

        Debug.Log("AmplitudeAvg: " + amplitude + " currentPitchHeight: " + currentPitchHeight);
	}
}
