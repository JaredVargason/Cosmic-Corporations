using UnityEngine;
using System.Collections;

public class LaunchMusic : MonoBehaviour {

	//script for 5 audio pieces. needs to change to higher level of each audio each time a rocket gets above the checkpoints.
    
    public AudioClip[] _startingClips = new AudioClip[5];
    public AudioClip[] _musicClips = new AudioClip[5];
    
    public RoundHandler _timer;
    
    private AudioSource _source;
    
    private bool _isPlaying;
    
	void Start () {
	    _source = GetComponent<AudioSource>();
        _source.PlayOneShot(_startingClips[(int)Random.Range(0f, 4.99f)], 1f);
        _source.clip = _musicClips[(int)Random.Range(0f, 4.99f)];
        
        _isPlaying = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (_timer._roundTimer > 0 && !_isPlaying)
        {
            _source.Play();
            _isPlaying = true;
        }
        
        if (Time.timeScale < 1)
        {
            _source.volume = .5f;
        }
	}
}
