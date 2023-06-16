using UnityEngine;

[CreateAssetMenu(menuName = "State/StateGlove/Coupler", order = 5)]
public class Coupler : StateSmartGlove   
{
    public override void Start()
    {
        throw new System.NotImplementedException();
    }

    public override void ManageState(Vector2 origin, Vector2 direction)
    {
        RaycastHit2D hit = Line(origin, direction);
    }
}
