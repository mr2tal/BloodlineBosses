﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CastingSpell : MonoBehaviour
{
    private float timeCasting = 0f;
    public bool isCasting = false;
    private float castTime;
    private float globalCooldown = 1f;
	public float currentCooldownMax = 0f;
	public static float[] currentBuffTimes = new float[5];
    List<float> fullCooldowns = new List<float>();
    private List<float> currentCooldowns = new List<float>();
    private int index = 0;
    private Stats stats;

    // Start is called before the first frame update
    void Start()
    {
		stats = GetComponent<Stats>();
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
		if (currentCooldowns[0] > 0) 
		{
			var colors = GameObject.Find("m1ButtonCD").GetComponent<Button> ().colors;
			colors.normalColor = Color.red;
			GameObject.Find("m1ButtonCD").GetComponent<Button> ().colors = colors;
			string cdTXT;
			cdTXT = currentCooldowns[0].ToString("0.00");
			GameObject.Find("m1ButtonCD").GetComponentInChildren<Text> ().text = cdTXT;
			GameObject.Find("TESTBUTTON").GetComponentInChildren<Image> ().fillAmount = (currentCooldowns[0] / currentCooldownMax);
		}
		else
		{
			var colors = GameObject.Find("m1ButtonCD").GetComponent<Button> ().colors;
			colors.normalColor = Color.white;
			GameObject.Find("m1ButtonCD").GetComponent<Button> ().colors = colors;
			string cdTXT;
			cdTXT = " ";
			GameObject.Find("m1ButtonCD").GetComponentInChildren<Text> ().text = cdTXT;
		}
        
    }
    //Cancel cast, removed for now
    //void CancelCast()
    //{
    //    if (isCasting && ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) || Input.GetKeyDown(KeyCode.T)))
    //    {
    //        isCasting = false;
    //        castTime = 0f;
    //        timeCasting = 0f;
    //    }
    //}

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
            if (Input.GetKeyDown(KeyCode.Space))
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
		currentCooldownMax = 0f;
        currentCooldowns[index] = currentCooldowns[index] + stats.player.Spells[index]._cooldown;
		currentCooldownMax = currentCooldowns[index];
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
				currentCooldownMax = 0f;
                currentCooldowns[i] = currentCooldowns[i] + globalCooldown;
				currentCooldownMax = currentCooldowns[i];
            }
            else if (currentCooldowns[i] <= 1 && currentCooldowns[i] > 0)
            {
				currentCooldownMax = 0f;
                currentCooldowns[i] = globalCooldown;
				currentCooldownMax = currentCooldowns[i];
            }
        }

    }
    //automatic runs when a castrequest has been done , 
    void Casting()
    {
        if (timeCasting < castTime)
        {
            timeCasting = timeCasting + Time.deltaTime;
			Slider castBar;
			GameObject temp = GameObject.Find("castBar");
			castBar = temp.GetComponent<Slider>();
			castBar.value = timeCasting / castTime;
			if (castBar.value == 1) 
			{
				castBar.value = 0;
			}


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
	public void parentSetter(Transform newParent)
	{
		//Sets "newParent" as the new parent of the object
		this.transform.SetParent(newParent);
	}
    void Shoot(int index)
    {
        
        if(stats.player.Spells[index]._archetype == "Projectile")
        {
            GameObject obj = Instantiate(stats.player.Spells[index]._prefab, transform.position, Quaternion.LookRotation(VectorMousePoint.MousePoint() - this.transform.position));
            print(stats.player.Spells[index]._name);
            obj.GetComponent<Projectile>().RecieveParameters(stats.player.Name, stats.player.Spells[index]._speed, stats.player.Spells[index]._damage, stats.player.Spells[index]._duration, stats.player.Spells[index]._meter, stats.player.Spells[index]._aggro, stats.player.Spells[index]._explodes, stats.player.Spells[index]._size, stats.player.Spells[index]._aoePrefab, stats.player.Spells[index]._buff);
        }
        if (stats.player.Spells[index]._archetype == "Melee")
        {
            GameObject obj = Instantiate(stats.player.Spells[index]._prefab, transform.position + transform.up*1, Quaternion.LookRotation(VectorMousePoint.MousePoint() - this.transform.position));

			//This attempts to assign the instantiated object as a child of the player object. Currently finds the player object by name, which is set to "mr2" at runtime.
			obj.transform.parent = GameObject.Find("Cube").transform;
			GameObject.Find("Cube").transform.Rotate(new Vector3(90,0,0), Space.Self);
			//Prints the name of the spell, for debugging, to make sure we've imported the right one to the right hotkey.
            print(stats.player.Spells[index]._name);
            obj.GetComponent<Melee>().RecieveParameters(stats.player.Name, stats.player.Spells[index]._damage, stats.player.Spells[index]._isCleave, stats.player.Spells[index]._meter, stats.player.Spells[index]._aggro, stats.player.Spells[index]._buff);
        }
        if (stats.player.Spells[index]._archetype == "Aoe")
        {
            GameObject obj = Instantiate(stats.player.Spells[index]._prefab, VectorMousePoint.MousePoint(), Quaternion.identity);
            print(stats.player.Spells[index]._name);
            obj.GetComponent<Aoe>().RecieveParameters(stats.player.Name, stats.player.Spells[index]._damage, stats.player.Spells[index]._meter, stats.player.Spells[index]._aggro, stats.player.Spells[index]._size, stats.player.Spells[index]._buff);
        }
        if (stats.player.Spells[index]._archetype == "Buff")
        {
            stats.player.Buffs.Add(stats.player.Spells[index]);
			GameObject.Find ("buffIcon").GetComponentInChildren<Image> ().fillAmount = 1;
			currentBuffTimes[stats.player.Buffs.Count-1] = stats.player.Buffs[stats.player.Buffs.Count-1]._duration;
        }
       
    }
}
