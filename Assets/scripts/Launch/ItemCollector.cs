using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemCollector : MonoBehaviour {
    
    public int _playerNumber;
    public RoundHandler _timer;
    
	private AudioSource _source;
    public AudioClip _collectSound1;
    public AudioClip _collectSound2;

    public CollectableText _collectableText;
    
    void Awake()
    {
        _source = GetComponent<AudioSource>();
    }
    
    void Start()
    {
        _playerNumber = transform.root.GetComponent<RocketBehavior>()._playerNumber;
    }
    
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Coin" && _timer._roundTimer > 0) //if a player hits the coin after round starts
        { 
            _source.PlayOneShot(_collectSound1, 1f);
            transform.root.GetComponent<RocketInfo>()._money += coll.GetComponent<CoinBehavior>()._coinValue;
            
            Destroy(coll.gameObject);
        }
        
        else if (coll.tag == "Card" && _timer._roundTimer > 0)
        {
            _source.PlayOneShot(_collectSound2, 1f);
            transform.root.GetComponent<RocketInfo>()._cardsCollected += 1;
            
            int _whichCard = Random.Range(1, 52);
            if (BoardGameHandler.cards[_playerNumber - 1] == null)
            {
                BoardGameHandler.cards[_playerNumber - 1] = new List<int>();
                BoardGameHandler.cards[_playerNumber - 1].Add(_whichCard);
            }
            
            else
            {
                BoardGameHandler.cards[_playerNumber - 1].Add(_whichCard);
            }
            
            Destroy(coll.gameObject);
        }
        
        else if ((coll.tag == "Coin"  || coll.tag == "Card") && _timer._roundTimer < 0) //if coin spawns on player it moves up and possibly to the left or right so rocket does not automatically collect it
        {  
            float x = coll.transform.position.x;
            float y = coll.transform.position.y;
            float z = coll.transform.position.z;
            
            coll.transform.position = new Vector3(x + Random.Range(-2f, 2f), y + Random.Range(.1f, 1.99f), z);
        }
    }
}
