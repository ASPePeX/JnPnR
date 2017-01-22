using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private GameController _gc;
    private Renderer[] _renderer;
    private Collider2D _collider;
    private Color _color;

	// Use this for initialization
	void Start ()
	{
        _gc = this.transform.parent.gameObject.GetComponent<GameController>();

        _renderer = GetComponentsInChildren<Renderer>();
	    _collider = GetComponentInChildren<Collider2D>();

	    _color = new Color(1, 1, 1, 1);
	}

    // Update is called once per frame
    void Update()
    {
        float distance = Mathf.Abs(_gc.currentPitchHeight - this.transform.position.y);

        if (distance < Config.VisibilitySpan)
        {
            EnablePlatform();
        }
        else
        {
            DisablePlatform();
        }
    }

    private void DimPlatform(float dim)
    {
        _color.a = dim;

        for (int i = 0; i < _renderer.Length; i++)
        {
            _renderer[i].material.SetColor("_Color", _color);
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
