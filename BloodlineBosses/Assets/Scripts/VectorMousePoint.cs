using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorMousePoint
{
    //creates a vector3 where the mouse is on the screen
    public static Vector3 MousePoint()
    {

        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(plane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance);
        } else
        {
            return Vector3.zero;
        }
        
    }

}
