using UnityEngine;
using System.Collections;

public class SphereGazeEvents : MonoBehaviour
{

    // This event is going to be fired when we look at the sphere
    public void OnGazeEnter()
    {
        Debug.Log("Gaze entered");
    }

    // This event is going to be fired when we stop looking at the sphere
    public void OnGazeLeave()
    {
        Debug.Log("Gaze left");
    }
}