using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public PStats player = new PStats("Mage", 100, 0);

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    public class PStats{

        private string _name;
        private int _hp;
        private int _meter;
        private List<Spells.Spell> _spells;

        public PStats(string name, int hp, int meter)
        {
            _name = name;
            _hp = hp;
            _meter = meter;
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
        public List<Spells.Spell> Spells
        {
            get { return _spells; }
            set { _spells = Spells; }
        }
        
    }
}
