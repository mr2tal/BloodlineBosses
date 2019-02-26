using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spells : MonoBehaviour
{
    public List<Spell> Spellbook = new List<Spell>();
    Spell fireball1 = new Spell("Fireball", 10, 10f, 10, 5, 3f, 3f, false);
    Spell fireball2 = new Spell("Fireball", 10, 10f, 10, 5, 3f, 3f, false);
    Spell fireball3 = new Spell("Fireball", 10, 10f, 10, 5, 3f, 3f, false);
    Spell fireball4 = new Spell("Fireball", 10, 10f, 10, 5, 3f, 3f, false);
    Spell fireball5 = new Spell("Fireball", 10, 10f, 10, 5, 3f, 3f, false);
    Spell fireball6 = new Spell("Fireball", 10, 10f, 10, 5, 3f, 3f, false);
    Spell fireball7 = new Spell("Fireball", 10, 10f, 10, 5, 3f, 3f, false);
    Spell fireball8 = new Spell("Fireball", 10, 10f, 10, 5, 3f, 3f, false);
    public PlayerStats PlayerStats;

    
    // Start is called before the first frame update
    void Start()
    {
        

        if (PlayerStats.player.Name == "Mage")
        {
            Spellbook.Add(fireball1);
            Spellbook.Add(fireball2);
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
        private string _name { get; set; }
        private int _damage { get; set; }
        private float _range { get; set; }
        private int _meter { get; set; }
        private int _aggro { get; set; }
        private float _cooldown { get; set; }
        private float _casttime { get; set; }
        private bool _isMelee { get; set; }

        public Spell(string name, int damage, float range, int meter, int aggro, float cooldown, float casttime, bool isMelee)
        {
            _name = name;
            _damage = damage;
            _range = range;
            _meter = meter;
            _aggro = aggro;
            _cooldown = cooldown;
            _casttime = casttime;
            _isMelee = isMelee;
        }
    }
}
