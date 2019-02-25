using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public static readonly Plane plane = new Plane(Vector3.up, Vector3.zero);
    private Vector3 offset = new Vector3(0, 10f, 0);
    public float maxDistance;
    // Start is called before the first frame update
    void Start()
    {
        //set start position
        Camera.main.transform.position = player.transform.position + offset;

        //direction between target and start point
        Vector3 dir = player.transform.position - Camera.main.transform.position;

        Vector3 newdir = Vector3.RotateTowards(transform.forward, dir, 360f, 0.0f);


        //change camera angle
        Camera.main.transform.rotation = Quaternion.LookRotation(newdir);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance;

        if (plane.Raycast(ray, out distance))
        {

            // making a vector 3 of the position i have hit
            Vector3 hit = ray.GetPoint(distance);

            //print(hit);  

            //x axis limitation
            if (player == null)
            {
                //   print("player dead");
            }
            else if (hit.x > player.transform.position.x + maxDistance)
            {
                hit.x = player.transform.position.x + maxDistance;
            }
            else if (hit.x < player.transform.position.x - maxDistance)
            {
                hit.x = player.transform.position.x - maxDistance;
            }

            //z axis limitation
            if (player == null)
            {
                //   print("player dead");
            }
            else if (hit.z > player.transform.position.z + maxDistance)
            {
                hit.z = player.transform.position.z + maxDistance;
            }
            else if (hit.z < player.transform.position.z - maxDistance)
            {
                hit.z = player.transform.position.z - maxDistance;
            }

            //transform camera position
            if (player != null)
            {
                transform.position = ((player.transform.position + hit) / 2) + offset;
            }


        }
    }
}
