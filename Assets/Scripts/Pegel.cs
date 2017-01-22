using UnityEngine;

public class Pegel : MonoBehaviour
{
    private GameController _gc;
    private Transform _camPos;
    private Vector2 _pos;
    private float _centerOffset;

	// Use this for initialization
	void Start ()
	{
        _camPos = Camera.main.transform;
	    _centerOffset = Camera.main.orthographicSize * Camera.main.aspect -0.5f;
	    _gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    _pos.x = _camPos.position.x + _centerOffset;
	    _pos.y = _gc.currentPitchHeight;
	    this.transform.position = _pos;
	}
}
