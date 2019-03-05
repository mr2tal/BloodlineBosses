using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    string _attacker;
    int _speed;
    float _damage;
    float _duration;
    int _meter;
    float _aggro;
    bool _explodes;
    float _size;
    GameObject _prefab;
    float timeTravelled = 0f;
    Spells.Spell _buff;
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
    public void RecieveParameters(string attacker, int speed, float damage, float duration, int meter, float aggro, bool explodes, float size, GameObject prefab, Spells.Spell buff)
    {
        _attacker = attacker;
        _speed = speed;
        _damage = damage;
        _duration = duration;
        _meter = meter;
        _aggro = aggro;
        _explodes = explodes;
        _size = size;
        _prefab = prefab;
        _buff = buff;

    }

    // checks if the projectile collides with anyone
    private void OnTriggerEnter(Collider other)
    {
        // if the projectile aint hitting its owner then execute
        if (other.name != _attacker)
        {
            if (_buff != null)
            {
                EnemyStats EStats = other.GetComponent<EnemyStats>();
                EStats.enemy.Buffs.Add(_buff);
            }
            if (_explodes == true)
            {
               
               GameObject obj = Instantiate(_prefab, gameObject.transform.position, Quaternion.identity);
                obj.GetComponent<Aoe>().RecieveParameters(_attacker, _damage, _meter, _aggro, _size, _buff);
                Destroy(this.gameObject);
           
            }else
            {
                EnemyStats EStats = other.GetComponent<EnemyStats>();
                if (EStats == null)
                {
                    return;
                }
                else
                {
                    EStats.TakeDamage(_attacker, other.name, _damage, _aggro);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
