using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    string _attacker;
    int _speed;
    int _damage;
    float _duration;
    int _meter;
    int _aggro;
    float timeTravelled = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //duration checker, which counts the time the object has been alive, and moves/destroys the projectile
        if (timeTravelled < _duration)
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            timeTravelled = timeTravelled + Time.deltaTime;
        } else
        {
            Destroy(this.gameObject);
        }


    }
    //the projectile recieves parameters from the attacker
    public void RecieveParameters(string attacker, int speed, int damage, float duration, int meter, int aggro)
    {
        _attacker = attacker;
        _speed = speed;
        _damage = damage;
        _duration = duration;
        _meter = meter;
        _aggro = aggro;
        
    }

    // checks if the projectile collides with anyone
    private void OnTriggerEnter(Collider other)
    {
        // if the projectile aint hitting its owner then execute
        if (other.name != _attacker)
        {
            EnemyStats Stats = other.GetComponent<EnemyStats>();
            Stats.TakeDamage(_attacker ,other.name, _damage, _aggro);
            Destroy(this.gameObject);
        }
    }
}
