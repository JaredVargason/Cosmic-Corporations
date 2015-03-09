using UnityEngine;
using System.Collections;

public class AbstractMenu : MonoBehaviour {

    public AudioSource _source;
    public AudioClip _confirm;
    public AudioClip _confirm2;
    public AudioClip _cursor;
    public AudioClip _back;
    
    public int _selected = 0;
    public bool _moveActionUsed;
    public bool _buttonActionUsed; //used because feels unresponsive it you don't use it
    
    public GameObject _camera;
    public Transform _destination;
    
    public float horizontal;
    public float vertical;
    public bool a;
    public bool b;
    
	public void getInput()
    {
        horizontal = 0;
        vertical = 0;
        a = false;
        b = false;
        
        if (Input.GetAxis("Horizontal 1") != 0 && _moveActionUsed == false)
        {
            horizontal = Input.GetAxis("Horizontal 1");
            _moveActionUsed = true;
        }
        
        if (Input.GetAxis("Vertical 1") != 0 && _moveActionUsed == false)
        {
            vertical = Input.GetAxis("Vertical 1");
            _moveActionUsed = true;
        }
        
        if (Input.GetAxis("A1") == 1 && _buttonActionUsed == false)
        {
            a = true;
            _buttonActionUsed = true;
        }
        
        if (Input.GetAxis("B1") == 1 && _buttonActionUsed == false)
        {
            b = true;
            _buttonActionUsed = true;
        }
        
        if (Input.GetAxis("Horizontal 1") == 0 && Input.GetAxis("Vertical 1") == 0)
        {
            _moveActionUsed = false;
        }
        
        if (Input.GetAxis("A1") == 0 && Input.GetAxis("B1") == 0)
        {
            _buttonActionUsed = false;
        }
    }
    
    void OnEnable()
    {
        _moveActionUsed = true;
    }
}
