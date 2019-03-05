using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float _modifiercounter;
    public float _amplify;
    public EStats enemy = new EStats("evil boss", 30f, 0, true, new List<Spells.Spell>());
    List<Aggro> aggroTable = new List<Aggro>();
    // Start is called before the first frame update
    void Start()
    {
        enemy.Owner = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        BuffCalculation();
    }

    public void BuffCalculation()
    {
        for (int i = 0; i < enemy.Buffs.Count; i++)
        {
            _modifiercounter = _modifiercounter + enemy.Buffs[i]._amplify;
            if (enemy.Buffs[i]._timeAlive < enemy.Buffs[i]._duration)
            {
                enemy.Buffs[i]._timeAlive = enemy.Buffs[i]._timeAlive + Time.deltaTime;
            }
            else
            {
                enemy.Buffs[i]._timeAlive = 0f;
                enemy.Buffs.Remove(enemy.Buffs[i]);
            }
        }
        _amplify = _modifiercounter;
        _modifiercounter = 0f;
    }
    public void TakeDamage(string attacker, string hitTarget, float damage, float aggro)
    {
        if (hitTarget == enemy.Owner)
        {
            Stats stats = GameObject.Find(attacker).GetComponent<Stats>();
            enemy.Hp = enemy.Hp - (damage * (stats._amplify + _amplify + 1));

            // for testing purposes
            print("Attacker:" + attacker + ", damage:" + damage + ", amplify:" + (stats._amplify + _amplify) + ", victim:" + hitTarget + "victim hp:" + enemy.Hp);
            AggroTable(attacker, aggro);
            if (enemy.Hp <= 0)
            {
                Destroy(GameObject.Find(hitTarget));
            }
        }
    }

    public void AggroTable(string attacker, float aggro)
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
        public float _aggro { get; set; }

        public Aggro(string attacker, float aggro)
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
        private float _hp;
        private int _meter;
        private bool _isEnemy;
        private List<Spells.Spell> _buffs;

        //constructor
        public EStats(string name, float hp, int meter, bool isEnemy, List<Spells.Spell> buffs)
        {
            _name = name;
            _hp = hp;
            _meter = meter;
            _isEnemy = isEnemy;
            _buffs = buffs;
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
        public float Hp
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
        public List<Spells.Spell> Buffs
        {
            get { return _buffs; }
            set { _buffs = value; }
        }
    }

}