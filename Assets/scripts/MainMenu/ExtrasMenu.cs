using UnityEngine;
using System.Collections;

public class ExtrasMenu : MonoBehaviour 
{
    private AudioSource _source;
    public AudioClip _confirm;
    public AudioClip _confirm2;
    public AudioClip _cursor;
    public AudioClip _back;
    
    public Menu _mainMenu;
    
    public int _selected = 0;
    public bool _action = false;
    public GameObject[] MenuItems = new GameObject[2];
    
    public Transform _camera;
    
    void Awake () 
    {
        foreach(Transform child in transform)
        {
            child.renderer.enabled = false;
        }
        
        _source = GetComponent<AudioSource> ();
        
        MenuItems [0].renderer.material.color = Color.yellow;
        
        float x;
        float y;
        float z;
        
        x = MenuItems[_selected].transform.localScale.x * 1.1f;
        y = MenuItems[_selected].transform.localScale.y * 1.1f;
        z = MenuItems[_selected].transform.localScale.z;
        MenuItems[0].transform.localScale = new Vector3(x, y, z);
        
        if (PlayerPrefs.HasKey("NumberOfTimesStarted"))
        {
            PlayerPrefs.SetInt("Number Of Times Started", PlayerPrefs.GetInt("NumberOfTimesStarted") + 1);
            PlayerPrefs.Save();
        }
        
        else
        {
            PlayerPrefs.SetInt("Number Of Times Started", 1);
        }
        
        if (!PlayerPrefs.HasKey("Time Played"))
        {
            PlayerPrefs.SetFloat("Time Played", 0f);
        }
        
        if (!PlayerPrefs.HasKey("Money Collected"))
        {
            PlayerPrefs.SetFloat("Money Collected", 0f);
        }
        
        if (!PlayerPrefs.HasKey("Money Funded"))
        {
            PlayerPrefs.SetFloat("Money Funded", 0f);
        }
        
        if (!PlayerPrefs.HasKey("Cards Played"))
        {
            PlayerPrefs.SetInt("Cards Played", 0);
        }
        
        if (!PlayerPrefs.HasKey("Missles Shot"))
        {
            PlayerPrefs.SetInt("Missles Shot", 0);
        }
        
        if (!PlayerPrefs.HasKey("Missles Hit"))
        {
            PlayerPrefs.SetInt("Missles Hit", 0);
        }
        
        if (!PlayerPrefs.HasKey("Magnets Used"))
        {
            PlayerPrefs.SetInt("Magnets Used", 0);
        }
    }
    
    void Update () 
    {
        foreach(Transform child in transform)
        {
            child.renderer.enabled = true;
        }
        
        float x;
        float y;
        float z;
        
        if (Input.GetAxis("Vertical 1") != 0 && _action == false)
        {
            _source.PlayOneShot(_cursor);
            MenuItems[_selected].renderer.material.color = Color.white;
            x = MenuItems[_selected].transform.localScale.x / 1.1f;
            y = MenuItems[_selected].transform.localScale.y / 1.1f;
            z = MenuItems[_selected].transform.localScale.z;
            MenuItems[_selected].transform.localScale = new Vector3(x, y, z);
            
            _selected = IntBounds.SetInt(_selected, -Input.GetAxisRaw("Vertical 1"), 0, 1);
            
            MenuItems[_selected].renderer.material.color = Color.yellow;
            x = MenuItems[_selected].transform.localScale.x * 1.1f;
            y = MenuItems[_selected].transform.localScale.y * 1.1f;
            z = MenuItems[_selected].transform.localScale.z;
            MenuItems[_selected].transform.localScale = new Vector3(x, y, z);
            
            _action = true;
        }
        
        if (Input.GetAxis("Vertical 1") == 0)
        {
            _action = false;
        }
        
        if (Input.GetAxis("B1") == 1)
        {
            _source.PlayOneShot(_back);
            _mainMenu.enabled = true;
            
            foreach(Transform child in transform)
            {
                child.renderer.enabled = false;
            }
            
            this.enabled = false;
        }
        
        if (Input.GetAxis("A1") == 1) 
        {
            switch (_selected) 
            {
                case 0:
                    
                    break;
                    
                case 1:
                    
                    break;
                    
                case 2:
                    
                    break;
                    
                case 3:
                    
                    break;
            }
        }
    }
}
