using UnityEngine;

public class PlatformVisibility : MonoBehaviour
{
    private GameController _gc;
    private Renderer _renderer;
    private Collider2D _collider;

	// Use this for initialization
	void Start ()
	{
	    _gc = this.transform.parent.gameObject.GetComponent<GameController>();
	    _renderer = this.gameObject.GetComponent<Renderer>();
	    _collider = this.gameObject.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Mathf.Abs(_gc.currentPitchHeight - this.transform.position.y) < Config.VisibilitySpan)
	    {
	        _renderer.enabled = true;
	        _collider.enabled = true;
	    }
	    else
	    {
	        _renderer.enabled = false;
	        _collider.enabled = false;
	    }
	}
}
