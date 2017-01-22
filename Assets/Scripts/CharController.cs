using UnityEngine;

public class CharController : MonoBehaviour
{
    private Rigidbody2D _rig;
    private Transform _cameraPos;

    private Vector2 _forceVector;
    private Vector2 _velocityVector;
    private bool _grounded;
    private float _reJumpTime;
    private float _reJumpTimer;
    private Vector3 spawnPos;


    // Use this for initialization
    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _cameraPos = Camera.main.transform;
        _forceVector = new Vector2();
        _velocityVector = new Vector2();
        _reJumpTime = 1f;
        _reJumpTimer = -1;
        spawnPos = this.transform.position;
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        if (hit.distance > 0 && hit.distance < 0.42f)
        {
            _grounded = true;
        }
        else
        {
            _grounded = false;
        }

        _forceVector.x = Input.GetAxis("Horizontal") * Config.ForceHorizontal;

        if (_grounded && _reJumpTimer < 0)
        {
            _forceVector.y = Input.GetAxis("Jump") * Config.ForceJump;
            if (_forceVector.y > 0)
                _reJumpTimer = _reJumpTime;
        }
        else
        {
            _forceVector.y = 0;
            _reJumpTimer = _reJumpTimer - Time.deltaTime;
        }

        if (transform.position.y < -2)
            Spawn();

        //Debug.Log(hit.distance + " Grounded: " + _grounded + " ReJump: " + _reJumpTimer + " Velo: " + _rig.velocity.ToString("G3"));

        _rig.AddForce(_forceVector.x * Vector2.right, Config.ForceModeMove);
        _rig.AddForce(_forceVector.y * Vector2.up, Config.ForceModeJump);

        _velocityVector.x = Mathf.Clamp(_rig.velocity.x, -Config.MaxVelocity.x, Config.MaxVelocity.x);
        _velocityVector.y = Mathf.Clamp(_rig.velocity.y, -Config.MaxVelocity.y, Config.MaxVelocity.y);
        _rig.velocity = _velocityVector;

        _cameraPos.position = Vector3.right * this.transform.position.x + Config.CameraOffset;
    }

    void Spawn()
    {
        this.transform.position = spawnPos;
        _rig.velocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "EndGame")
            Spawn();

    }

}
