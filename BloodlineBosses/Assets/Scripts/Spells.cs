using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spells : MonoBehaviour
{
    List<Spell> mageSpellbook = new List<Spell>();
    Spell fireball1 = new Spell("Fireball", 10, 10f, 10);
    Spell fireball2 = new Spell("Fireball", 10, 10f, 10);
    Spell fireball3 = new Spell("Fireball", 10, 10f, 10);
    Spell fireball4 = new Spell("Fireball", 10, 10f, 10);
    Spell fireball5 = new Spell("Fireball", 10, 10f, 10);
    Spell fireball6 = new Spell("Fireball", 10, 10f, 10);
    Spell fireball7 = new Spell("Fireball", 10, 10f, 10);
    Spell fireball8 = new Spell("Fireball", 10, 10f, 10);
    public PlayerStats PlayerStats;

    
    // Start is called before the first frame update
    void Start()
    {
        
        mageSpellbook.Add(fireball1);
        mageSpellbook.Add(fireball2);
        mageSpellbook.Add(fireball3);
        mageSpellbook.Add(fireball4);
        mageSpellbook.Add(fireball5);
        mageSpellbook.Add(fireball6);
        mageSpellbook.Add(fireball7);
        mageSpellbook.Add(fireball8);

        print(PlayerStats.player.Name);

        if (PlayerStats.player.Name == "Mage")
        {
            PlayerStats.player.Spells = mageSpellbook;
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
        public Spell(string name, int damage, float range, int meter)
        {
            _name = name;
            _damage = damage;
            _range = range;
            _meter = meter;
        }
    }
}
