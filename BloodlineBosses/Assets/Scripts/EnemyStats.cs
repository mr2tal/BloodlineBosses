using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    EStats enemy = new EStats("evil boss", 30, 0, true);
    // Start is called before the first frame update
    void Start()
    {
        enemy.Owner = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(string attacker, string hitTarget, int damage, int aggro)
    {
        if (hitTarget == enemy.Owner)
        {
            print("Attacker:" + attacker + ", damage:" + damage + ", victim:" + hitTarget);
            enemy.Hp = enemy.Hp - damage;
            if (enemy.Hp <= 0)
            {
                Destroy(GameObject.Find(hitTarget));
            }
        }
    }

    public class EStats
    {
        //field
        private string _owner;
        private string _name;
        private int _hp;
        private int _meter;
        private bool _isEnemy;

        //constructor
        public EStats(string name, int hp, int meter, bool isEnemy)
        {
            _name = name;
            _hp = hp;
            _meter = meter;
            _isEnemy = isEnemy;
        }

        //getset
        public string Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }
        public int Meter
        {
            get { return _meter; }
            set { _meter = value; }
        }
        public bool IsEnemy
        {
            get { return _isEnemy; }
            set { _isEnemy = value; }
        }
    }

}