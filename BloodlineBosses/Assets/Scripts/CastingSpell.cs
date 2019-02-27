using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingSpell : Spells
{
    private float timeCasting = 0f;
    public bool isCasting = false;
    private float castTime;
    private float globalCooldown = 1f;
    List<float> fullCooldowns = new List<float>();
    List<float> currentCooldowns = new List<float>();
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {

        fullCooldowns.Add(Spellbook[0]._cooldown);
        fullCooldowns.Add(Spellbook[1]._cooldown);
        fullCooldowns.Add(Spellbook[2]._cooldown);
        fullCooldowns.Add(Spellbook[3]._cooldown);
        fullCooldowns.Add(Spellbook[4]._cooldown);
        fullCooldowns.Add(Spellbook[5]._cooldown);
        fullCooldowns.Add(Spellbook[6]._cooldown);
        fullCooldowns.Add(Spellbook[7]._cooldown);
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
        ReduceCooldowns();
    }


    void CastInput()
    {

        if (!isCasting)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (currentCooldowns[0] <= 0)
                {
                    CastRequest(Spellbook[0]._casttime, 0);
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (currentCooldowns[1] <= 0)
                {
                    CastRequest(Spellbook[1]._casttime, 1);
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (currentCooldowns[2] <= 0)
                {
                    CastRequest(Spellbook[2]._casttime, 2);
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentCooldowns[3] <= 0)
                {
                    CastRequest(Spellbook[3]._casttime, 3);
                }
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (currentCooldowns[4] <= 0)
                {
                    CastRequest(Spellbook[4]._casttime, 4);
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (currentCooldowns[5] <= 0)
                {
                    CastRequest(Spellbook[5]._casttime, 5);
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (currentCooldowns[6] <= 0)
                {
                    CastRequest(Spellbook[6]._casttime, 6);
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (currentCooldowns[7] <= 0)
                {
                    CastRequest(Spellbook[7]._casttime, 7);
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
        currentCooldowns[index] = currentCooldowns[index] + GetFullCooldown(index);
    }

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
            //shoot projectice
            print("pew");
        }
    }
    void Shoot(int index)
    {
        print(Spellbook[index]._name);
    }
}
