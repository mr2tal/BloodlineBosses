﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float _modifiercounter;
    public float _amplify;
    

    //construct our playerstats player

    public PStats player = new PStats("mr2", "Mage", 100f, 0, new List<Spells.Spell>(), new List<Spells.Spell>());

    
    // Start is called before the first frame update
    void Start()
    {
        
        this.gameObject.name = player.Name;
    }

    // Update is called once per frame
    void Update()
    {
        BuffCalculation();
    }

        public void BuffCalculation()
    {
        for (int i = 0; i < player.Buffs.Count; i++)
        {
            _modifiercounter = _modifiercounter + player.Buffs[i]._amplify;
            if (player.Buffs[i]._timeAlive < player.Buffs[i]._duration)
            {
                player.Buffs[i]._timeAlive = player.Buffs[i]._timeAlive + Time.deltaTime;
            }
            else
            {
                player.Buffs[i]._timeAlive = 0f;
                player.Buffs.Remove(player.Buffs[i]);
            }
        }
        _amplify = _modifiercounter;
        _modifiercounter = 0f;
    }
    // called when colliding with player object
    // TODO add a way the boss attacks back so this gets executed
    public void TakeDamage(string attacker, string hitTarget, float damage, int aggro)
    {
        if (hitTarget == player.Name)
        {

            player.Hp = player.Hp - damage;
            if (player.Hp <= 0)
            {
                Destroy(GameObject.Find(hitTarget));
            }
        }
    }


    public class PStats{
        //field
        private string _name;
        private string _roleclass;
        private float _hp;
        private int _meter;
        private List<Spells.Spell> _spells;
        private List<Spells.Spell> _buffs;

        //constructor
        public PStats(string name, string roleclass, float hp, int meter, List<Spells.Spell> spells, List<Spells.Spell> buffs)
        {
            _name = name;
            _roleclass = roleclass;
            _hp = hp;
            _meter = meter;
            _spells = spells;
            _buffs = buffs;
           
            
        }

        //getset
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Roleclass
        {
            get { return _roleclass; }
            set { _roleclass = value; }
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
        public List<Spells.Spell> Spells
        {
            get { return _spells; }
            set { _spells = Spells; }
        }
        public List<Spells.Spell> Buffs
        {
            get { return _buffs; }
            set { _buffs = value; }
        }
    }
    
}
