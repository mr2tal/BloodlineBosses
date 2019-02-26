using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingSpell : MonoBehaviour
{
    private float timeCasting = 0f;
    private bool isCasting = false;
    private float castTime;
    private float GlobalCooldown = 1f;
    List<float> fullCooldowns = new List<float>();
    List<float> currentCooldowns = new List<float>();
    private int index;
    public Spells Spells;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
       
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
}
