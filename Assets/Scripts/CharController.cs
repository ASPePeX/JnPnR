using UnityEngine;

public class CharController : MonoBehaviour
{
    private Rigidbody2D _rig;

    private Vector2 _forceVector;
    private bool _grounded;

    // Use this for initialization
    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _forceVector = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        if (hit.distance > 0 && hit.distance < 0.35f)
        {
            _grounded = true;
        }
        else
        {
            _grounded = false;
        }

        _forceVector.x = Input.GetAxis("Horizontal") * Config.ForceHorizontal;

        if (_grounded)
        {
            _forceVector.y = Input.GetAxis("Jump") * Config.ForceJump;
        }
        else
        {
            _forceVector.y = 0;
        }

        Debug.Log(hit.distance + " Grounded: " + _grounded);

        _rig.AddForce(_forceVector);
    }
}
