using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    Vector3 directions;
   // public static readonly Plane plane = new Plane(Vector3.up, Vector3.zero);


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        GetInput();
        Move();
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.z, 10);
		Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
		lookPos = lookPos - transform.position;
		float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.LookRotation(VectorMousePoint.MousePoint());

    }
    //moves the object in the direction determined times the movespeed times the deltatime
    private void Move()
    {
        this.transform.Translate(directions * moveSpeed * Time.deltaTime);
    }
    //gets the input for controlling the character
    private void GetInput()
    {
        directions = Vector3.zero;
        CastingSpell CastingSpell = GetComponent<CastingSpell>();
        if (CastingSpell.isCasting == false)
        {

            if (Input.GetKey(KeyCode.W))
            {
                directions = directions + Vector3.forward;
            }
            if (Input.GetKey(KeyCode.A))
            {
                directions = directions + Vector3.left;
            }
            if (Input.GetKey(KeyCode.S))
            {
                directions = directions + Vector3.back;
            }
            if (Input.GetKey(KeyCode.D))
            {
                directions = directions + Vector3.right;
            }
        }
    }

}

