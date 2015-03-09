using UnityEngine;
using System.Collections;

public class PlayMenu : AbstractMenu {
    
    public Menu _mainMenu;
    public GameSettingsMenu _gameSettingsMenu;
    public static int _gameMode;
    
    public GameObject[] _MenuItems = new GameObject[3];
    
    public static int _numberOfPlayers = 1;
    
    void Awake () 
    {
        _source = GetComponent<AudioSource>();
        
        foreach(Transform child in transform)
        {
            child.renderer.enabled = false;
        }
        
        _gameMode = 0;
        
        _MenuItems [0].renderer.material.color = Color.yellow;
        
        float x;
        float y;
        float z;
        
        x = _MenuItems[_selected].transform.localScale.x * 1.1f;
        y = _MenuItems[_selected].transform.localScale.y * 1.1f;
        z = _MenuItems[_selected].transform.localScale.z;
        _MenuItems[0].transform.localScale = new Vector3(x, y, z);
    }
    
    void Update () 
    {
        getInput();
        foreach(Transform child in transform)
        {
            child.renderer.enabled = true;
        }
        
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, _destination.position, Time.deltaTime * 3f);
        _camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation, Quaternion.Euler(new Vector3(0, 90f, 0)), Time.deltaTime * 3f);
        
        float x;
        float y;
        float z;
        
        if (vertical != 0)
        {
            _source.PlayOneShot(_cursor);
            _MenuItems[_selected].renderer.material.color = Color.white;
            x = _MenuItems[_selected].transform.localScale.x / 1.1f;
            y = _MenuItems[_selected].transform.localScale.y / 1.1f;
            z = _MenuItems[_selected].transform.localScale.z;
            _MenuItems[_selected].transform.localScale = new Vector3(x, y, z);
            
            _selected = IntBounds.SetInt(_selected, -vertical, 0, 2);
            
            _MenuItems[_selected].renderer.material.color = Color.yellow;
            x = _MenuItems[_selected].transform.localScale.x * 1.1f;
            y = _MenuItems[_selected].transform.localScale.y * 1.1f;
            z = _MenuItems[_selected].transform.localScale.z;
            _MenuItems[_selected].transform.localScale = new Vector3(x, y, z);
        }
        
        if (b == true)
        {
            foreach(Transform child in transform)
            {
                child.renderer.enabled = false;
            }
            
            _mainMenu.enabled = true;
            _source.PlayOneShot(_back);
            this.enabled = false;
        }
        
        switch (_selected) 
        {
            case 0:
                if (horizontal != 0)
                {
                    PlayMenu._numberOfPlayers = IntBounds.SetInt(PlayMenu._numberOfPlayers, Input.GetAxis("Horizontal 1"), 1, 4);
                    
                    _MenuItems[0].GetComponent<TextMesh>().text = "Number of players: " + PlayMenu._numberOfPlayers;
                    _source.PlayOneShot(_cursor);
                }
                
                break;
                
            case 1:
                if (a == true)
                {
                    _gameSettingsMenu.enabled = true;
                }
                /*if (horizontal != 0)
                {
                    _gameMode = IntBounds.SetInt(_gameMode, Input.GetAxis("Horizontal 1"), 0, 0);
                    _MenuItems[1].GetComponent<TextMesh>().text = "Game Mode: " + _gameMode;
                    _source.PlayOneShot(_cursor);
                }*/
                
                break;
                
            case 2:
                if (a)
                {
                    switch (_gameMode)
                    {
                        case 0:
                          _source.PlayOneShot(_confirm, 1f);
                          BoardGameHandler.ResetGame();
                          Application.LoadLevel(1); //need to scene fade
                          break;
                    }
                }
                break;
        }
    }
}
