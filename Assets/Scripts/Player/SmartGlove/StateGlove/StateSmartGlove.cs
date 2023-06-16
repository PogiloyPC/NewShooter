using UnityEngine;
using StateGlove;

public abstract class StateSmartGlove : ScriptableObject
{
    [SerializeField] private Sprite _image;

    [SerializeField] private string _name;
    
    [SerializeField, Multiline] private string _description;

    [SerializeField] private StateGloveType _stateGlove;

    public Sprite Image { get { return _image; } private set { } }

    public string Name { get { return _name; } private set { } }

    public string Description { get { return _description; } private set { } }

    public StateGloveType StateGlove { get{ return _stateGlove; } private set { } }

    public abstract void Start();

    public abstract void ManageState(Vector2 origin, Vector2 direction);            

    protected RaycastHit2D Line(Vector2 origin, Vector2 mousePos)
    {
        return Physics2D.Raycast(origin, mousePos);
    }
}
