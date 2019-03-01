using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spells : MonoBehaviour
{
    
    public List<Spell> Spellbook = new List<Spell>();
    public Stats PlayerStats;
    public GameObject Prefab;

    
    void Awake()
    {
        
        //creating spells
        Spell fireball1 = new Spell(PlayerStats.player.Name, "Fireball",10, 10, 1f, 10, 5, 3f, 3f, Prefab);
        Spell frostbolt = new Spell(PlayerStats.player.Name, "Frostbolt",10, 10, 1f, 10, 5, 3f, 3f, Prefab);
        Spell fireball3 = new Spell(PlayerStats.player.Name, "Fireball",10, 10, 1f, 10, 5, 3f, 3f, Prefab);
        Spell fireball4 = new Spell(PlayerStats.player.Name, "Fireball",10, 10, 1f, 10, 5, 3f, 3f, Prefab);
        Spell fireball5 = new Spell(PlayerStats.player.Name, "Fireball",10, 10, 1f, 10, 5, 3f, 3f, Prefab);
        Spell fireball6 = new Spell(PlayerStats.player.Name, "Fireball",10, 10, 1f, 10, 5, 3f, 3f, Prefab);
        Spell fireball7 = new Spell(PlayerStats.player.Name, "Fireball",10, 10, 1f, 10, 5, 3f, 3f, Prefab);
        Spell fireball8 = new Spell(PlayerStats.player.Name, "Fireball",10, 10, 1f, 10, 5, 3f, 3f, Prefab);
        //set spellbook
        if (PlayerStats.player.Roleclass == "Mage")
        {
            Spellbook.Add(fireball1);
            Spellbook.Add(frostbolt);
            Spellbook.Add(fireball3);
            Spellbook.Add(fireball4);
            Spellbook.Add(fireball5);
            Spellbook.Add(fireball6);
            Spellbook.Add(fireball7);
            Spellbook.Add(fireball8);

            PlayerStats.player.Spells.AddRange(Spellbook);
            print(PlayerStats.player.Spells);
        }
        
        

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class Spell
    {
        //fields
        public string _owner { get; set; }
        public string _name { get; set; }
        public int _speed { get; set; }
        public int _damage { get; set; }
        public float _duration { get; set; }
        public int _meter { get; set; }
        public int _aggro { get; set; }
        public float _cooldown { get; set; }
        public float _casttime { get; set; }
        public GameObject _Prefab { get; set; }

        //constructor
        public Spell(string owner, string name, int Speed, int damage, float duration, int meter, int aggro, float cooldown, float casttime, GameObject Prefab)
        {
            _owner = owner;
            _name = name;
            _speed = Speed;
            _damage = damage;
            _duration = duration;
            _meter = meter;
            _aggro = aggro;
            _cooldown = cooldown;
            _casttime = casttime;
            _Prefab = Prefab;
        }
    }
}
