using UnityEngine;

[CreateAssetMenu(menuName = "State/StateGlove/Flamethrower", order = 4)]
public class Flamethrower : StateSmartGlove
{  
    private GameObject _fireObj;

    private ParticleSystem _fire;

    public override void Start()
    {
        _fireObj = GameObject.Find("Fire");

        _fire = _fireObj.GetComponent<ParticleSystem>();
    }

    public override void ManageState(Vector2 origin, Vector2 direction)
    {        
        if (Input.GetKeyDown(KeyCode.V))        
            _fire.Play();        
        else if (Input.GetKeyUp(KeyCode.V))
            _fire.Stop();
    }
}
