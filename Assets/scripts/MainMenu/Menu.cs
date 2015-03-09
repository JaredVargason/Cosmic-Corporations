using UnityEngine;
using System.Collections;

public class Menu : AbstractMenu 
{
	public SettingsMenu _settingsMenu;
    public PlayMenu _playMenu;
    public ExtrasMenu _extrasMenu;
    
	public GameObject[] MenuItems = new GameObject[4];
    
	void Awake () 
	{
        _camera.transform.position = new Vector3(0, 3.57f, -53.3f);
        _camera.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
		_source = GetComponent<AudioSource> ();
        
		MenuItems [0].renderer.material.color = Color.yellow;
        
        float x;
        float y;
        float z;
        
        x = MenuItems[_selected].transform.localScale.x * 1.1f;
        y = MenuItems[_selected].transform.localScale.y * 1.1f;
        z = MenuItems[_selected].transform.localScale.z;
        MenuItems[0].transform.localScale = new Vector3(x, y, z);
	}
    
	void Update () 
	{
        getInput();
        
        foreach(Transform child in transform)
        {
            child.renderer.enabled = true;
        }
        
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, _destination.position, Time.deltaTime * 3f);
        _camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation, Quaternion.Euler(new Vector3(0, 0, 0)), Time.deltaTime * 3f);
        
        float x;
        float y;
        float z;
        
		if (vertical != 0)
		{
			_source.PlayOneShot(_cursor);
			MenuItems[_selected].renderer.material.color = Color.white;
            x = MenuItems[_selected].transform.localScale.x / 1.1f;
            y = MenuItems[_selected].transform.localScale.y / 1.1f;
            z = MenuItems[_selected].transform.localScale.z;
            MenuItems[_selected].transform.localScale = new Vector3(x, y, z);

			_selected = IntBounds.SetInt(_selected, -vertical, 0, 3);

			MenuItems[_selected].renderer.material.color = Color.yellow;
            x = MenuItems[_selected].transform.localScale.x * 1.1f;
            y = MenuItems[_selected].transform.localScale.y * 1.1f;
            z = MenuItems[_selected].transform.localScale.z;
            MenuItems[_selected].transform.localScale = new Vector3(x, y, z);
		}

		if (a == true) 
		{
            foreach(Transform child in transform)
            {
                child.renderer.enabled = false;
            }
            
			switch (_selected) 
			{
				case 0:
					_source.PlayOneShot(_confirm, 1f);
                    _playMenu.enabled = true;
                    this.enabled = false;
					break;

				case 1:
					_source.PlayOneShot(_confirm, 1f);
					_settingsMenu.enabled = true;
					this.enabled = false;
					break;

				case 2:
                    _extrasMenu.enabled = true;
                    _source.PlayOneShot(_confirm);
                    this.enabled = false;
					
					break;

				case 3:
                    PlayerPrefs.Save(); //Unnecessary
					Application.Quit();
					break;
			}
		}
	}
}
