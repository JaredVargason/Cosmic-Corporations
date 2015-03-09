using UnityEngine;
using System.Collections;

public class FuelGauge : MonoBehaviour {
    
    public RocketBehavior _rocket;
    
    private bool _1;
    private bool _2;
    private bool _3;
    private bool _4;
    private bool _5;
    
	// Use this for initialization
	void Awake ()
    {
        _1 = false;
        _2 = false;
        _3 = false;
        _4 = false;
        _5 = false;
    }
	
	// Update is called once per frame
	void Update () {
	    if (_rocket._fuel <= _rocket._totalFuel * .8 && _rocket._fuel > _rocket._totalFuel *.6 && !animation.IsPlaying("80") && _1 == false)
        {
            animation.Play("80");
            _1 = true;
        }
        
        else if (_rocket._fuel <= _rocket._totalFuel * .6 && _rocket._fuel > _rocket._totalFuel * .4 && !animation.IsPlaying("60") && _2 == false)
        {
            animation.Play("60");
            _2 = true;
        }
        
        else if (_rocket._fuel <= _rocket._totalFuel * .4 && _rocket._fuel > _rocket._totalFuel * .2 && !animation.IsPlaying("40") && _3 == false)
        {  
            animation.Play("40");
            _3 = true;
        }
        
        else if (_rocket._fuel <= _rocket._totalFuel * .2 && _rocket._fuel > 0 && !animation.IsPlaying("20") && _4 == false)
        {
            animation.Play("20");
            _4 = true;
        }
        
        else if (_rocket._fuel <= 0 && animation.IsPlaying("0") && _5 == false)
        {
            animation.Play("0");
            _5 = true;
        }
	}
}
