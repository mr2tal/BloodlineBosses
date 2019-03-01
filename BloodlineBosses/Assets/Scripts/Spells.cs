using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spells : MonoBehaviour
{
    
    public List<Spell> Spellbook = new List<Spell>();
    public PlayerStats PlayerStats;
    public GameObject Prefab;

    
    void Awake()
    {
        
        Spell fireball1 = new Spell("Fireball",10, 10, 10f, 10, 5, 3f, 3f, false, Prefab);
        Spell frostbolt = new Spell("Frostbolt",10, 10, 10f, 10, 5, 3f, 3f, false, Prefab);
        Spell fireball3 = new Spell("Fireball",10, 10, 10f, 10, 5, 3f, 3f, false, Prefab);
        Spell fireball4 = new Spell("Fireball",10, 10, 10f, 10, 5, 3f, 3f, false, Prefab);
        Spell fireball5 = new Spell("Fireball",10, 10, 10f, 10, 5, 3f, 3f, false, Prefab);
        Spell fireball6 = new Spell("Fireball",10, 10, 10f, 10, 5, 3f, 3f, false, Prefab);
        Spell fireball7 = new Spell("Fireball",10, 10, 10f, 10, 5, 3f, 3f, false, Prefab);
        Spell fireball8 = new Spell("Fireball",10, 10, 10f, 10, 5, 3f, 3f, false, Prefab);

        if (PlayerStats.player.Name == "Mage")
        {
            Spellbook.Add(fireball1);
            Spellbook.Add(frostbolt);
            Spellbook.Add(fireball3);
            Spellbook.Add(fireball4);
            Spellbook.Add(fireball5);
            Spellbook.Add(fireball6);
            Spellbook.Add(fireball7);
            Spellbook.Add(fireball8);
        }
        
        

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class Spell
    {
        public string _name { get; set; }
        public int _speed { get; set; }
        public int _damage { get; set; }
        public float _range { get; set; }
        public int _meter { get; set; }
        public int _aggro { get; set; }
        public float _cooldown { get; set; }
        public float _casttime { get; set; }
        public bool _isMelee { get; set; }
        public GameObject _Prefab { get; set; }

        public Spell(string name, int Speed, int damage, float range, int meter, int aggro, float cooldown, float casttime, bool isMelee, GameObject Prefab)
        {
            _name = name;
            _speed = Speed;
            _damage = damage;
            _range = range;
            _meter = meter;
            _aggro = aggro;
            _cooldown = cooldown;
            _casttime = casttime;
            _isMelee = isMelee;
            _Prefab = Prefab;
        }
    }
}
