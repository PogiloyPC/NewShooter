using UnityEngine;

[CreateAssetMenu(menuName = "State/StateGlove/GrapplingHook", order = 2)]
public class GrapplingHook : StateSmartGlove
{
    private GameObject _player;

    private Rigidbody2D _rb;

    private LineRenderer _ropeLine;
    
    private Transform _targetGrapplingHook;

    [SerializeField] private float _speedGrapplingHook;
    [SerializeField] private float _distanceGrapplingHook;
    [SerializeField] private float _minDistanceGrapplingHook;

    private bool _isHooked;

    private Vector2 _directionFly;

    public override void Start()
    {
        _player = GameObject.Find("Player");

        _ropeLine = GameObject.Find("Hande").GetComponent<LineRenderer>();

        _targetGrapplingHook = GameObject.Find("TragetGlove").transform;

        _rb = _player.GetComponent<Rigidbody2D>();
    }

    public override void ManageState(Vector2 origin, Vector2 direction)
    {
        RaycastHit2D hit = Line(origin, direction);

        if (Input.GetKeyDown(KeyCode.V))
        {
            if (hit.collider.gameObject.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Kinematic &&
                  Vector2.Distance(origin, hit.point) <= _distanceGrapplingHook)
            {
                FindDirection(origin, hit.point);

                _isHooked = true;
                
                _ropeLine.enabled = true;
            }
        }
        else if (Input.GetKey(KeyCode.V) && _directionFly != Vector2.zero && _isHooked)
        {
            _rb.velocity = _directionFly.normalized * _speedGrapplingHook;

            _ropeLine.SetPosition(0, origin);
            _ropeLine.SetPosition(1, _targetGrapplingHook.position);
        }

        if (Input.GetKeyUp(KeyCode.V))
        {
            _directionFly = Vector2.zero;
            
            _rb.velocity = Vector2.zero;
        
            _isHooked = false;

            _ropeLine.enabled = false;
        }

        if (_isHooked && Vector2.Distance(origin, _targetGrapplingHook.position) < _minDistanceGrapplingHook)
            _isHooked = false;
    }

    private void FindDirection(Vector2 origin, Vector2 hit)
    {
        _targetGrapplingHook.position = hit;

        _directionFly = new Vector2(_targetGrapplingHook.position.x, _targetGrapplingHook.position.y) - origin;
    }    
}
