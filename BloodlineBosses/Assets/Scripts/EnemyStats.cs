using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    EStats enemy = new EStats("evil boss", 30, 0, true);
    List<Aggro> aggroTable = new List<Aggro>();
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
            AggroTable(attacker, aggro);
            if (enemy.Hp <= 0)
            {
                Destroy(GameObject.Find(hitTarget));
            }
        }
    }

    public void AggroTable(string attacker, int aggro)
    {
        foreach (Aggro a in aggroTable)
        {
            if (a._attacker == attacker)
            {
                a._aggro = a._aggro + aggro;

                //for testing purpose
                print("aggro name:" + a._attacker + ", aggro:" + a._aggro);
                return;
            }
        }
        aggroTable.Add(new Aggro(attacker, aggro));
    }

    public class Aggro
    {
        public string _attacker { get; set; }
        public int _aggro { get; set; }

        public Aggro(string attacker, int aggro)
        {
            _attacker = attacker;
            _aggro = aggro;
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