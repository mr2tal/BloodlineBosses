using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spells : MonoBehaviour
{
    
    public List<SpellType> Spellbook = new List<SpellType>();
    public Stats PlayerStats;
    public GameObject ProjectilePrefab;
    public GameObject MeleePrefab;

    
    void Awake()
    {
        
        //creating spells
        SpellType fireball1 = new SpellType("Projectile", new Spell(PlayerStats.player.Name, "Fireball",10, 10, 1f, 10, 5, 3f, 3f, ProjectilePrefab));
        SpellType frostbolt = new SpellType("Projectile", new Spell(PlayerStats.player.Name, "Frostbolt",10, 10, 1f, 10, 5, 3f, 3f, ProjectilePrefab));
        SpellType meleeattack = new SpellType("Melee", new Spell(PlayerStats.player.Name, "meleeattack", 20, 0, 10, 1f, 1f, false, MeleePrefab));
        SpellType fireball4 = new SpellType("Projectile", new Spell(PlayerStats.player.Name, "Fireball",10, 10, 1f, 10, 5, 3f, 3f, ProjectilePrefab));
        SpellType fireball5 = new SpellType("Projectile", new Spell(PlayerStats.player.Name, "Fireball",10, 10, 1f, 10, 5, 3f, 3f, ProjectilePrefab));
        SpellType fireball6 = new SpellType("Projectile", new Spell(PlayerStats.player.Name, "Fireball",10, 10, 1f, 10, 5, 3f, 3f, ProjectilePrefab));
        SpellType fireball7 = new SpellType("Projectile", new Spell(PlayerStats.player.Name, "Fireball",10, 10, 1f, 10, 5, 3f, 3f, ProjectilePrefab));
        SpellType fireball8 = new SpellType("Projectile", new Spell(PlayerStats.player.Name, "Fireball",10, 10, 1f, 10, 5, 3f, 3f, ProjectilePrefab));
        //set spellbook
        if (PlayerStats.player.Roleclass == "Mage")
        {
            Spellbook.Add(fireball1);
            Spellbook.Add(frostbolt);
            Spellbook.Add(meleeattack);
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

    public class SpellType
    {
       
        public string _archtype { get; set; }
        public Spell _spell { get; set; }
        //constructor
        public SpellType(string archtype, Spell spell)
        {
            _archtype = archtype;
            _spell = spell;
        }

    }


    public class Spell
    {
        //fields
        public string _owner { get; set; }
        public string _name { get; set; }
        public int _damage { get; set; }
        public int _meter { get; set; }
        public int _aggro { get; set; }
        public float _cooldown { get; set; }
        public float _casttime { get; set; }
        public GameObject _Prefab { get; set; }

        //projectile specific fields
        public float _duration { get; set; }
        public int _speed { get; set; }

        //melee specific fields
        public bool _isCleave { get; set; }

        //constructor for projectile type
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

        //constructor for melee type
        public Spell(string owner, string name, int damage, int meter, int aggro, float cooldown, float casttime,bool isCleave, GameObject Prefab)
        {
            _owner = owner;
            _name = name;
            _damage = damage;
            _meter = meter;
            _aggro = aggro;
            _cooldown = cooldown;
            _casttime = casttime;
            _Prefab = Prefab;
            _isCleave = isCleave;
        }

    }

}
