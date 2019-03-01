using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingSpell : MonoBehaviour
{
    private float timeCasting = 0f;
    public bool isCasting = false;
    private float castTime;
    private float globalCooldown = 1f;
    List<float> fullCooldowns = new List<float>();
    List<float> currentCooldowns = new List<float>();
    private int index = 0;
    private Stats stats;
    // Start is called before the first frame update
    void Start()
    {
        
        stats = GetComponent<Stats>();
        //fullCooldowns.Add(stats.player.Spells[0]._cooldown);
        //fullCooldowns.Add(stats.player.Spells[1]._cooldown);
        //fullCooldowns.Add(stats.player.Spells[2]._cooldown);
        //fullCooldowns.Add(stats.player.Spells[3]._cooldown);
        //fullCooldowns.Add(stats.player.Spells[4]._cooldown);
        //fullCooldowns.Add(stats.player.Spells[5]._cooldown);
        //fullCooldowns.Add(stats.player.Spells[6]._cooldown);
        //fullCooldowns.Add(stats.player.Spells[7]._cooldown);
        currentCooldowns.Add(0);
        currentCooldowns.Add(0);
        currentCooldowns.Add(0);
        currentCooldowns.Add(0);
        currentCooldowns.Add(0);
        currentCooldowns.Add(0);
        currentCooldowns.Add(0);
        currentCooldowns.Add(0);


    }

    // Update is called once per frame
    void Update()
    {
        
        CastInput();

        
        if (isCasting)
        {
            Casting();
        }
        //reducing cooldowns over Time.DeltaTime
        ReduceCooldowns();
    }

    //checks if aint casting, and if a button is pressed, then does a cast request if allowed from the index on spells[x] from the players spellbook
    void CastInput()
    {

        if (!isCasting)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (currentCooldowns[0] <= 0)
                {
                    CastRequest(stats.player.Spells[0]._casttime, 0);
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (currentCooldowns[1] <= 0)
                {
                    CastRequest(stats.player.Spells[1]._casttime, 1);
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (currentCooldowns[2] <= 0)
                {
                    CastRequest(stats.player.Spells[2]._casttime, 2);
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentCooldowns[3] <= 0)
                {
                    CastRequest(stats.player.Spells[3]._casttime, 3);
                }
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (currentCooldowns[4] <= 0)
                {
                    CastRequest(stats.player.Spells[4]._casttime, 4);
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (currentCooldowns[5] <= 0)
                {
                    CastRequest(stats.player.Spells[5]._casttime, 5);
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (currentCooldowns[6] <= 0)
                {
                    CastRequest(stats.player.Spells[6]._casttime, 6);
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (currentCooldowns[7] <= 0)
                {
                    CastRequest(stats.player.Spells[7]._casttime, 7);
                }
            }


        }
    }

    void ReduceCooldowns()
    {
        for (int i = 0; i < 8; i++)
        {
            if (currentCooldowns[i] >= 0)
            {
                currentCooldowns[i] = currentCooldowns[i] - Time.deltaTime;
            }
        }
    }
    float GetcurrentCooldown(int index)
    {
       return currentCooldowns[index];
    }

    float GetFullCooldown(int index)
    {
        return fullCooldowns[index];
    }

    void SetCurrentCooldown(int index)
    {
        currentCooldowns[index] = currentCooldowns[index] + stats.player.Spells[index]._cooldown;
    }

    //gets a casttime and index, sets the casting to true to avoid more castrequests
    //sets the index to the field index and adds global cooldown to every spell below 0, and if below or equal to 1 AND above 0 sets it to global cooldown
    void CastRequest(float casttime, int index)
    {
        isCasting = true;
        castTime = casttime;
        this.index = index;
        for (int i = 0; i < 8; i++)
        {
            if (currentCooldowns[i] < 0)
            {
                currentCooldowns[i] = currentCooldowns[i] + globalCooldown;
            }
            else if (currentCooldowns[i] <= 1 && currentCooldowns[i] > 0)
            {
                currentCooldowns[i] = globalCooldown;
            }
        }

    }
    //automatic runs when a castrequest has been done , 
    void Casting()
    {
        if (timeCasting < castTime)
        {
            timeCasting = timeCasting + Time.deltaTime;
        }
        else
        {
            SetCurrentCooldown(index);
            timeCasting = 0f;
            isCasting = false;

            Shoot(index);
            //shoot projectile
            
        }
    }
    // instantiates our projectile and sends parameters to the projectile
    void Shoot(int index)
    {
        GameObject obj = Instantiate(stats.player.Spells[index]._Prefab, transform.position , Quaternion.LookRotation( VectorMousePoint.MousePoint() - this.transform.position));
        print(stats.player.Spells[index]._name);
        obj.GetComponent<Projectile>().RecieveParameters(stats.player.Spells[index]._owner, stats.player.Spells[index]._speed, stats.player.Spells[index]._damage, stats.player.Spells[index]._duration, stats.player.Spells[index]._meter, stats.player.Spells[index]._aggro);
    }
}
