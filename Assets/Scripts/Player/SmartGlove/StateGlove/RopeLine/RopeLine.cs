using UnityEngine;

[CreateAssetMenu(menuName = "State/StateGlove/RopeLine", order = 3)]
public class RopeLine : StateSmartGlove
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
