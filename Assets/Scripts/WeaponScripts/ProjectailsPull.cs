using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectailsPull<T>
{
    private UnityAction<T> _returnProjectails;
    private List<T> _projectailsDeactivated;
    private List<T> _projectailsActivated;    

    public ProjectailsPull(List<T> pull)
    {
        _projectailsDeactivated = pull;
    }

    public T GetProjectails()
    {
        T projectail = _projectailsDeactivated[0];
        //_projectailsActivated.Add(projectail);
        _projectailsDeactivated.RemoveAt(0);

        return projectail;
    }

    public void ReturnProjectails(T projectail)
    {
        _projectailsDeactivated.Add(projectail);
        _projectailsActivated.Remove(projectail);
    }
}
