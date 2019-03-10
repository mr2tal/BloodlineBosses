using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Spells : MonoBehaviour
{
    
    public List<Spell> Spellbook = new List<Spell>();
    public Stats PlayerStats;
    public GameObject ProjectilePrefab;
    public GameObject MeleePrefab;
    public GameObject AoePrefab;


    void Awake()
    {

        //creating spells

        Spell fireballM1 = new Spell(PlayerStats.player.Name, "Fireball", "Projectile", 10, 10f, 2f, 5, 5f, 3f, 1f, true, 1f, ProjectilePrefab, AoePrefab, null);
        Spell frostboltM2 = new Spell(PlayerStats.player.Name, "Frostbolt", "Projectile", 10, 10f, 1f, 10, 5f, 3f, 3f, false, 0f, ProjectilePrefab, null, null);
        Spell meleeattackQ = new Spell(PlayerStats.player.Name, "meleeattack", "Melee", 20f, 0, 10f, 1f, 1f, false, MeleePrefab, null);
        Spell aoeattackE = new Spell(PlayerStats.player.Name, "Aoeattack", "Aoe", 5f, 5, 5f, 2f, 2f, 4f, AoePrefab, null);
        Spell buffR = new Spell(PlayerStats.player.Name, "SelfBuff", "Buff", 0, 0.25f, 3f, 0f, true, 3f, 1f);
        Spell buffProjectileF = new Spell(PlayerStats.player.Name, "BuffProjectile", "Projectile", 10, 0f, 2f, 5, 0f, 3f, 1f, false, 0f, ProjectilePrefab, null, new Spell(PlayerStats.player.Name, "Buff", "Buff", 0, 0.25f, 3f, 0f, false, 0f, 0f));
        Spell fireball1 = new Spell(PlayerStats.player.Name, "Fireball", "Projectile", 10, 10f, 1f, 10, 5f, 3f, 3f, false, 0f, ProjectilePrefab, null, null);
        Spell fireballSpace = new Spell(PlayerStats.player.Name, "Fireball", "Projectile", 10, 10f, 1f, 10, 5f, 3f, 3f, false, 0f, ProjectilePrefab, null, null);
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



    public class Spell
    {
        //fields
        
        public string _owner { get; set; }
        public string _name { get; set; }
        public string _archetype { get; set; }
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
        public Spell(string owner, string name, string archetype, int Speed, float damage, float duration, int meter, float aggro, float cooldown, float casttime, bool explodes, float size, GameObject prefab, GameObject aoePrefab, Spell buff)
        {
            _owner = owner;
            _name = name;
            _archetype = archetype;
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
        public Spell(string owner, string name, string archetype, float damage, int meter, float aggro, float cooldown, float casttime, bool isCleave, GameObject prefab, Spell buff)
        {
            _owner = owner;
            _name = name;
            _archetype = archetype;
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
        public Spell(string owner, string name, string archetype, float damage, int meter, float aggro, float cooldown, float casttime, float size, GameObject prefab, Spell buff)
        {
            _owner = owner;
            _name = name;
            _archetype = archetype;
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
        public Spell(string owner, string name, string archetype, int meter, float amplify, float duration, float timeAlive, bool isFriendly, float cooldown, float casttime)
        {
            _owner = owner;
            _name = name;
            _archetype = archetype;
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
