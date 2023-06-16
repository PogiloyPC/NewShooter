using UnityEngine;

[CreateAssetMenu(menuName = "State/StateGlove/DefaultState", order = 1)]
public class DefaultState : StateSmartGlove
{
    public override void Start()
    {
        
    }

    public override void ManageState(Vector2 origin, Vector2 direction)
    {
        RaycastHit2D hit = Line(origin, direction);
    }
}
