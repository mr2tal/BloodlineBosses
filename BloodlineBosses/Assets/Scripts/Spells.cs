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
        SpellType fireballM1 = new SpellType("Projectile", new Spell(PlayerStats.player.Name, "Fireball",10, 10f, 1f, 10, 5f, 5f, 1f,true, 2f, ProjectilePrefab, AoePrefab, null));
        SpellType frostboltM2 = new SpellType("Projectile", new Spell(PlayerStats.player.Name, "Frostbolt",10, 10f, 1f, 10, 5f, 3f, 3f,false,0f, ProjectilePrefab, null, null));
        SpellType meleeattackQ = new SpellType("Melee", new Spell(PlayerStats.player.Name, "meleeattack", 20f, 0, 10f, 1f, 1f, false, MeleePrefab,null));
        SpellType aoeattackE = new SpellType("Aoe", new Spell(PlayerStats.player.Name, "Aoeattack", 5f, 5, 5f, 2f, 2f, 4f, AoePrefab, null));
        SpellType buffR = new SpellType("Buff", new Spell(PlayerStats.player.Name, "Buff",0,0.25f,3f,0f,true,3f,1f));
        SpellType buffProjectileF = new SpellType("Projectile", new Spell(PlayerStats.player.Name, "BuffProjectile", 10, 0f, 2f, 5, 0f, 3f, 1f, false, 0f, ProjectilePrefab, null, new Spell(PlayerStats.player.Name, "Buff", 0, 0.25f, 3f, 0f, false, 0f, 0f))) ;
        SpellType fireball1 = new SpellType("Projectile", new Spell(PlayerStats.player.Name, "Fireball",10, 10f, 1f, 10, 5f, 3f, 3f, false, 0f, ProjectilePrefab, null, null));
        SpellType fireballSpace = new SpellType("Projectile", new Spell(PlayerStats.player.Name, "Fireball",10, 10f, 1f, 10, 5f, 3f, 3f, false, 0f, ProjectilePrefab, null,null));
        //set spellbook
        if (PlayerStats.player.Roleclass == "Mage")
        {
            Spellbook.Add(fireballM1);
            Spellbook.Add(frostboltM2);
            Spellbook.Add(meleeattackQ);
            Spellbook.Add(aoeattackE);
            Spellbook.Add(buffR);
            Spellbook.Add(buffProjectileF);
            Spellbook.Add(fireball1);
            Spellbook.Add(fireballSpace);

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
        public float _damage { get; set; }
        public int _meter { get; set; }
        public float _aggro { get; set; }
        public float _cooldown { get; set; }
        public float _casttime { get; set; }
        public GameObject _prefab { get; set; }
        public Spell _buff { get; set; }

        //projectile specific fields
        public float _duration { get; set; }
        public int _speed { get; set; }
        public bool _explodes { get; set; }
        public GameObject _aoePrefab { get; set; }

        //melee specific fields
        public bool _isCleave { get; set; }

        //aoe / projectile specific fields
        public float _size { get; set; }

        //buff specific fields
        public float _amplify { get; set; }
        public float _timeAlive { get; set; }
        public bool _isFriendly { get; set; }
       


        //constructor for projectile type
        /// <summary>
        /// Projectile constructor
        /// </summary>
        public Spell(string owner, string name, int Speed, float damage, float duration, int meter, float aggro, float cooldown, float casttime, bool explodes, float size, GameObject prefab, GameObject aoePrefab, Spell buff)
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
            _explodes = explodes;
            _size = size;
            _prefab = prefab;
            _aoePrefab = aoePrefab;
            _buff = buff;
        }

        //constructor for melee type
        /// <summary>
        /// Melee constructor
        /// </summary>
        public Spell(string owner, string name, float damage, int meter, float aggro, float cooldown, float casttime,bool isCleave, GameObject prefab, Spell buff)
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
            _buff = buff;
        }
        //constructor for aoe type
        /// <summary>
        /// Aoe constructor
        /// </summary>
        public Spell(string owner, string name, float damage, int meter, float aggro, float cooldown, float casttime, float size, GameObject prefab, Spell buff)
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
            _buff = buff;
        }
        /// <summary>
        /// buff constructor
        /// </summary>
        public Spell(string owner, string name, int meter, float amplify, float duration,float timeAlive, bool isFriendly,float cooldown, float casttime)
        {
            _owner = owner;
            _name = name;
            _meter = meter;
            _amplify = amplify;
            _duration = duration;
            _timeAlive = timeAlive;
            _isFriendly = isFriendly;
            _cooldown = cooldown;
            _casttime = casttime;
           
        }

    }

}
