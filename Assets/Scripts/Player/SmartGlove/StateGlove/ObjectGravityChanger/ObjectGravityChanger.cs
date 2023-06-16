using UnityEngine;

[CreateAssetMenu(menuName = "State/StateGlove/ObjectGravityChanger", order = 15)]
public class ObjectGravityChanger : StateSmartGlove
{
    public override void Start()
    {
        
    }

    public override void ManageState(Vector2 origin, Vector2 direction)
    {
        RaycastHit2D hit = Line(origin, direction);
    }    
}
