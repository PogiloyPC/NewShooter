using UnityEngine;
using UnityEngine.Events;

public class SceneManager : MonoBehaviour
{
    private UnityEvent<bool> displayHealth;    

    public void AddEvent(Health health)
    {
        displayHealth.AddListener(health.DisplayHealth);
        displayHealth.Invoke(true);
    }

    public void DeleteEvent(Health health)
    {
        displayHealth.Invoke(false);
        displayHealth.RemoveListener(health.DisplayHealth);
    }
}
