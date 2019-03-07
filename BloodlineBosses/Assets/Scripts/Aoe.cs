using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aoe : MonoBehaviour
{
    string _attacker;
    float _damage;
    float _size;
    int _meter;
    float _aggro;
    float _duration = 0.1f;
    float timeAlive = 0f;
    Spells.Spell _buff;
    // Start is called before the first frame update
    void Start()
    {
    }


    /// <summary>
    /// Update is called once per frame. Contains a duration checker, which counts the time the object has been alive, and moves/destroys the projectile
    /// </summary>
    void Update()
    {

        if (timeAlive < _duration)
        {
            timeAlive = timeAlive + Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }


    }
    
    /// <summary>
    /// The projectile recieves parameters from the attacker
    /// </summary>
    /// <param name="attacker"></param>
    /// <param name="damage"></param>
    /// <param name="meter"></param>
    /// <param name="aggro"></param>
    /// <param name="size"></param>
    /// <param name="buff"></param>
    public void RecieveParameters(string attacker, float damage, int meter, float aggro, float size, Spells.Spell buff)
    {
        _attacker = attacker;
        _damage = damage;
        _meter = meter;
        _aggro = aggro;
        _size = size;
        _buff = buff;
        SetSize();

    }
    public void SetSize()
    {
        gameObject.transform.localScale.Scale(new Vector3(_size, 0, _size));
    }

    
    /// <summary>
    /// Checks if the projectile collides with anything
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // if the projectile aint hitting its owner then execute
        if (other.name != _attacker)
        {
                
            EnemyStats EStats = other.GetComponent<EnemyStats>();
           
            if (EStats == null)
            {
                return;
            }else
            {
                if (_buff != null)
                {
                    EStats.enemy.Buffs.Add(_buff);
                }
                EStats.TakeDamage(_attacker, other.name, _damage, _aggro);
            }
        }
    }
}
