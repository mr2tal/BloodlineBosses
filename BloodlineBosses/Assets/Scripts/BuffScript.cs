using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffScript : MonoBehaviour
{
	private Stats stats;
	public float fillAmount = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
		stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
	{
		for (int i = 0; i < stats.player.Buffs.Count; i++) {
			if (stats.player.Buffs[i] != null) 
			{	
				CastingSpell.currentBuffTimes[i] -= Time.deltaTime;
				fillAmount = ((CastingSpell.currentBuffTimes [i]/ stats.player.Buffs[i]._duration));
				GameObject.Find("buffIcon").GetComponentInChildren<Image> ().fillAmount = fillAmount;
			}
		}
	}
}
