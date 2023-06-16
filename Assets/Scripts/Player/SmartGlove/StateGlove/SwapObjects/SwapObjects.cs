using UnityEngine;

[CreateAssetMenu(menuName = "State/StateGlove/SwapObjects", order = 7)]
public class SwapObjects : StateSmartGlove
{
    private Transform _player;

    [SerializeField] private float _maxDistanceSwap;

    public override void Start()
    {
        _player = GameObject.Find("Player").transform;
    }

    public override void ManageState(Vector2 origin, Vector2 direction)
    {
        RaycastHit2D hit = Line(origin, direction);

        if (Input.GetKeyDown(KeyCode.V))
        {
            GameObject obj = hit.collider.gameObject;

            if (obj.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic && 
                Vector2.Distance(origin, obj.transform.position) < _maxDistanceSwap)
            {
                Vector2 posObj = obj.transform.position;
                Vector2 posPlayer = _player.position;

                obj.transform.position = posPlayer;
                _player.position = posObj;
            }
        }
    }
}
