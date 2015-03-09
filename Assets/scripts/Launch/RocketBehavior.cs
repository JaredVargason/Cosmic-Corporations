using UnityEngine;
using System.Collections;

public abstract class RocketBehavior : MonoBehaviour 
{

	public int _playerNumber;
    
	public float _speed;
	public bool _hasMissle;
	public float _fuel;
    public float _totalFuel;

	public AudioSource[] _source = new AudioSource[2];
	public AudioClip _collision1;
	public AudioClip _collision2;
	public AudioClip _collision3;
	public AudioClip _collision4;
	public AudioClip _rocketSound;
    public AudioClip _collectSound1;
    public AudioClip _collectSound2;
	
	public float velToVol = 0.035f;
	public float pitchMin = .75f;
	public float pitchMax = 1.25f;

    public bool thrustersOn;
    public bool shotMissle;
    
    public float horizontal;
    public float vertical;
    public Vector3 thrust;
    
    public RoundHandler _timer;
	
	void Awake () 
	{
		_source = GetComponents<AudioSource> ();

		setRocketDetails();
	}

	void FixedUpdate ()
	{   
        getInput(); //consider putting in update?
		position();
		accelerate();
        shootMissle();
	}

	void OnCollisionEnter(Collision coll)
	{
		
	}
    
    private void setRocketDetails()
    {
        _speed = BoardGameHandler._speed[_playerNumber - 1];
        _fuel = BoardGameHandler._fuel[_playerNumber - 1];
        _totalFuel = BoardGameHandler._fuel[_playerNumber - 1];
        rigidbody.drag = BoardGameHandler._drag[_playerNumber - 1];
        rigidbody.angularDrag = BoardGameHandler._angularDrag[_playerNumber - 1];
        _hasMissle = BoardGameHandler._hasMissle[_playerNumber - 1];
    }
    
    private void getInput()
    {
        thrustersOn = false;
        shotMissle = false;
        
        if (Input.GetAxis("Horizontal " + _playerNumber) != 0 || Input.GetAxis("Vertical " + _playerNumber) != 0)
        {
            horizontal = -Input.GetAxis("Horizontal " + _playerNumber);
            vertical = Input.GetAxis("Vertical " + _playerNumber);
        }
        
        else
        {
            horizontal = 0;
            vertical = 0;
        }
        
        if (Input.GetAxis("A" + _playerNumber) == 1)
        {
            thrustersOn = true;
        }
        
        if (Input.GetAxis("Powerup " + _playerNumber) == -1)
        {
            shotMissle = true;
        }
    }
    
    public abstract void position();
    
    public abstract void accelerate();
      
    public abstract void shootMissle();
    
}