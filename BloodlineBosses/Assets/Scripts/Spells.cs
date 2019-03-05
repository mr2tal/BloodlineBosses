using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spells : MonoBehaviour
{
    
    public List<SpellType> Spellbook = new List<SpellType>();
    public Stats PlayerStats;
    public GameObject ProjectilePrefab;
    public GameObject MeleePrefab;
    public GameObject AoePrefab;

    
    void Awake()
    {
        
        //creating spells
        SpellType fireball1 = new SpellType("Projectile", new Spell(PlayerStats.player.Name, "Fireball",10, 10, 1f, 10, 5, 5f, 1f, ProjectilePrefab));
        SpellType frostbolt = new SpellType("Projectile", new Spell(PlayerStats.player.Name, "Frostbolt",10, 10, 1f, 10, 5, 3f, 3f, ProjectilePrefab));
        SpellType meleeattack = new SpellType("Melee", new Spell(PlayerStats.player.Name, "meleeattack", 20, 0, 10, 1f, 1f, false, MeleePrefab));
        SpellType aoeattack = new SpellType("Aoe", new Spell(PlayerStats.player.Name, "Aoeattack", 5, 5, 5, 2f, 2f, 4f, AoePrefab));
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
            Spellbook.Add(aoeattack);
            Spellbook.Add(fireball5);
            Spellbook.Add(fireball6);
            Spellbook.Add(fireball7);
            Spellbook.Add(fireball8);

            PlayerStats.player.Spells.AddRange(Spellbook);
        }
        
        

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class SpellType
    {
        //fields
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
        public GameObject _prefab { get; set; }

        //projectile specific fields
        public float _duration { get; set; }
        public int _speed { get; set; }

        //melee specific fields
        public bool _isCleave { get; set; }

        //aoe specific fields
        public float _size { get; set; }


        //constructor for projectile type
        /// <summary>
        /// Projectile constructor
        /// </summary>
        public Spell(string owner, string name, int Speed, int damage, float duration, int meter, int aggro, float cooldown, float casttime, GameObject prefab)
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
            _prefab = prefab;
        }

        //constructor for melee type
        /// <summary>
        /// Melee constructor
        /// </summary>
        public Spell(string owner, string name, int damage, int meter, int aggro, float cooldown, float casttime,bool isCleave, GameObject prefab)
        {
            _owner = owner;
            _name = name;
            _damage = damage;
            _meter = meter;
            _aggro = aggro;
            _cooldown = cooldown;
            _casttime = casttime;
            _prefab = prefab;
            _isCleave = isCleave;
        }
        //constructor for aoe type
        /// <summary>
        /// Aoe constructor
        /// </summary>
        public Spell(string owner, string name, int damage, int meter, int aggro, float cooldown, float casttime, float size, GameObject prefab)
        {
            _owner = owner;
            _name = name;
            _damage = damage;
            _meter = meter;
            _aggro = aggro;
            _cooldown = cooldown;
            _casttime = casttime;
            _size = size;
            _prefab = prefab;
        }

    }

}
