using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    string _attacker;
    float _damage;
    bool _isCleave;
    int _meter;
    float _aggro;
    float _duration = 1f;
    float timeAlive = 0f;
	float orbitSpeed = 1.0f;
	Transform swordTransform;

    Spells.Spell _buff;

    // Start is called before the first frame update
    void Start()
    {
		swordTransform = GameObject.Find("Sword(Clone)").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //duration checker, which counts the time the object has been alive, and moves/destroys the projectile
        if (timeAlive < _duration)
        {
            timeAlive = timeAlive + Time.deltaTime;
			//swordTransform.transform.localPosition = Vector3.Slerp(swordTransform.localPosition, new Vector3(1, 0, 0), orbitSpeed);
        }
        else
        {
            Destroy(this.gameObject);
        }


    }
    //the projectile recieves parameters from the attacker
    public void RecieveParameters(string attacker, float damage, bool isCleave, int meter, float aggro, Spells.Spell buff)
    {
        _attacker = attacker;
        _damage = damage;
        _isCleave = isCleave;
        _meter = meter;
        _aggro = aggro;
        _buff = buff;

    }

    // checks if the projectile collides with anyone
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
