/*using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CastingBar : MonoBehaviour {

	private UISlider _slider;
	public GameObject foreground;
	public bool isCasting = false;

	public bool _castSpell = false;
	private float castTime;
	float time = 0.0f;

	void Update()
	{
		if(_slider.foreground.localScale.y != 20)
		{
			_slider.foreground.localScale = new Vector3(_slider.foreground.localScale.x,20,_slider.foreground.localScale.z);
		}

		if(_castSpell == true)
		{  
			_slider.foreground.localScale = new Vector3((float)(time / castTime) * 200,20,_slider.foreground.localScale.z);
		}
	}

	public void Castspell(float _time) {
		_slider = GetComponent<UISlider>();
		castTime = _time;
		gameObject.SetActiveRecursively(true); //Turn everything on! We are ready to go...
		_castSpell = true;
		isCasting = true;
		InvokeRepeating("Timer",0.05f,0.05f);
	}

	public void ShutDown()
	{
		CancelInvoke("Timer");
		_slider.foreground.localScale = new Vector3(0,20,_slider.foreground.localScale.z);
		time = 0.0f;
		_castSpell = false;
		isCasting = false;
		gameObject.SetActiveRecursively(false);
	}
	void Timer()
	{
		if(time < castTime)
		{
			time += 0.05f;
		}else{
			ShutDown();
		}
	}
}*/