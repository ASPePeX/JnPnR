using UnityEngine;

public class GameController : MonoBehaviour
{
    public float currentPitch;
    public float currentPitchHeight;
	
	// Update is called once per frame
	void Update ()
	{
	    currentPitch = Mathf.Clamp01(currentPitch);
	    currentPitchHeight = Config.PitchSpan * currentPitch;
	}
}
