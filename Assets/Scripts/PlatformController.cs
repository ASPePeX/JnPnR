using System.Security.Policy;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private GameController _gc;
    private Renderer[] _renderer;
    private Collider2D _collider;

	// Use this for initialization
	void Start ()
	{
        _gc = this.transform.parent.gameObject.GetComponent<GameController>();

        _renderer = GetComponentsInChildren<Renderer>();
	    _collider = GetComponentInChildren<Collider2D>();
	}
	
	// Update is called once per frame
    void Update()
    {
        if (_gc.currentPitch < 0)
        {
            DisablePlatform();
        }
        else
        {
            if (Mathf.Abs(_gc.currentPitchHeight - this.transform.position.y) < Config.VisibilitySpan)
            {
                EnablePlatform();
            }
            else
            {
                DisablePlatform();
            }
        }
    }

    private void DisablePlatform()
    {
        for (int i = 0; i < _renderer.Length; i++)
        {
            _renderer[i].enabled = false;
        }
        _collider.enabled = false;
    }

    private void EnablePlatform()
    {
        for (int i = 0; i < _renderer.Length; i++)
        {
            _renderer[i].enabled = true;
        }
        _collider.enabled = true;
    }
}
