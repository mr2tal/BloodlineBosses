using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    int _speed;
    int _damage;
    float _range;
    int _meter;
    int _aggro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }

    public void RecieveParameters(int speed, int damage, float range, int meter, int aggro)
    {
        _speed = speed;
        _damage = damage;
        _range = range;
        _meter = meter;
        _aggro = aggro;
        
    }
}
