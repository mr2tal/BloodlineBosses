using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    float hMov;
    float vMov;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hMov = Input.GetAxis("Horizontal");
        vMov = Input.GetAxis("Vertical");
        float dt = Time.deltaTime;
        Vector3 changeVector = new Vector3(hMov, 0f, vMov);
        changeVector = changeVector * dt * moveSpeed;
        gameObject.transform.Translate(changeVector);
    }
}
