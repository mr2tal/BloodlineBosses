using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    
    //construct our playerstats player

    public PStats player = new PStats("mr2", "Mage", 100, 0, new List<Spells.SpellType>());

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // called when colliding with player object
    // TODO add a way the boss attacks back so this gets executed
    public void TakeDamage(string attacker, string hitTarget, int damage, int aggro)
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
        private int _hp;
        private int _meter;
        private List<Spells.SpellType> _spells;

        //constructor
        public PStats(string name, string roleclass, int hp, int meter, List<Spells.SpellType> spells)
        {
            _name = name;
            _roleclass = roleclass;
            _hp = hp;
            _meter = meter;
            _spells = spells;
           
            
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
        public List<Spells.SpellType> Spells
        {
            get { return _spells; }
            set { _spells = Spells; }
        }
    }
    
}
