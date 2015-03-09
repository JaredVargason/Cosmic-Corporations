using UnityEngine;
using System.Collections;

public class SettingsMenu : AbstractMenu {

	public GameObject[] MenuItems = new GameObject[7];
	public Menu _mainMenu;
    
    private int _resNumber;
    //Resolution[] resolutions = Screen.resolutions;
    int xRes;
    int yRes;
    private bool _isFullScreen = true;

	void Awake()
	{   
        _source = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("Resolution Number"))
        {
            //_resNumber = PlayerPrefs.GetInt("Resolution Number");
        }
        
        foreach(Transform child in transform)
        {
            child.renderer.enabled = false;
        }
      
		MenuItems[0].renderer.material.color = Color.yellow;
        //MenuItems[0].GetComponent<TextMesh>().text = "Resolution: " + Screen.GetResolution.ToString();
	}
    
    void OnEnable()
    {
        _moveActionUsed = true;
        foreach(Transform child in transform)
        {
            child.renderer.enabled = true;
        }
    }
    
	void Update () 
	{
        getInput();
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, _destination.position, Time.deltaTime * 3f);
        _camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation, Quaternion.Euler(new Vector3(0, -90f, 0)), Time.deltaTime * 3f);
        
		if (vertical != 0)
		{
			MenuItems[_selected].renderer.material.color = Color.white;
            
			_selected = IntBounds.SetInt(_selected, -Input.GetAxis("Vertical 1"), 0, 5);
			
			MenuItems[_selected].renderer.material.color = Color.yellow;
			_source.PlayOneShot(_cursor);
		}
        
        switch (_selected)
        {
            case 0:
                if (horizontal != 0)
                {
                    //_resNumber += (int)Input.GetAxisRaw("Horizontal 1");
                    
                    //MenuItems[0].GetComponent<TextMesh>().text = "Resolution: " + resolutions[_resNumber].width + "x" + resolutions[_resNumber].height;
                }
                
                break;
                
            case 1:
                
                
                break;
                
            case 2:
            
                break;
                
            case 3:
            
                break;
            
            case 4:     //Apply button
                if (a == true)
                {
                    // = resolutions[_resNumber].width;
                    //yRes = resolutions[_resNumber].height;
                    //Screen.SetResolution(resolutions[_resNumber].width, resolutions[_resNumber].height, _isFullScreen, 0);
                    
                    PlayerPrefs.SetInt("Resolution Number", _resNumber);
                    PlayerPrefs.SetInt("xResolution", xRes);
                    PlayerPrefs.SetInt("yResolution", yRes);
                    PlayerPrefs.Save();
                    
                    foreach(Transform child in transform)
                    {
                        child.renderer.enabled = false;
                    }
                    
                    _mainMenu.enabled = true;
                    this.enabled = false;
                }
                
                
                
                break;

            case 5:     //Cancel button
                if (a == true)
                {
                    _mainMenu.enabled = true;
                    foreach (Transform child in transform)
                    {
                        child.renderer.enabled = false;
                    }
                    this.enabled = false;
                }
                break;
                
            case 6:
                
                break;
        }
        
		if (b == true)
		{
            foreach(Transform child in transform)
            {
                child.renderer.enabled = false;
            }
            
			_mainMenu.enabled = true;
            _mainMenu._moveActionUsed = true;
            _source.PlayOneShot(_back);
			this.enabled = false;
		}
	}
}
