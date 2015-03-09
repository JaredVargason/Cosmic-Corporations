using UnityEngine;
using System.Collections;

public class ShipSelector : MonoBehaviour {
    
    public int _playerNumber;
    
    public GameObject[] _rocketModels = new GameObject[2];
    public Material[] _cartoonMaterials = new Material[3];
    public Material[] _ufoMaterials = new Material[3];
    public Material[] _fireworkMaterials = new Material[3];
    public Material[][] _materials = new Material[3][];
    
    public int _selectedModelIndex;
    public int _selectedMaterialIndex;
    public bool _action;
    
    private float horizontal;
    private float vertical;
    private float x;
    private float y;
    private float z;
	
	void Awake () 
    {
	    _materials[0] = _cartoonMaterials;
        _materials[1] = _ufoMaterials;
        
        _action = false;
        _selectedModelIndex = 0;
        _selectedMaterialIndex = 0;
	}
	
	void Update () 
    {
        getInput();
        rotateModel();
        changeModel();
        changeMaterial();
	}
    
    public void getInput()
    {
        //combine no input statements into one
        if (Input.GetAxis("Horizontal " + _playerNumber) != 0 && _action == false)
        {
            horizontal = Input.GetAxis("Horizontal " + _playerNumber);
            _action = true;
        }
        
        if (Input.GetAxis("Horizontal " + _playerNumber) == 0)
        {
            _action = false;
        }

        if (Input.GetAxis("Vertical " + _playerNumber) != 0)
        {
            vertical = Input.GetAxis("Vertical " + _playerNumber);
        }

        if (Input.GetAxis("Vertical " + _playerNumber) == 0)
        {
            _action = false;
        }
        
        if (Input.GetAxis("Left Bumper " + _playerNumber) == 1 || Input.GetAxis("Right Bumper " + _playerNumber) == 1)
        {
            if (Input.GetAxis("Left Bumper " + _playerNumber) == 1 && Input.GetAxis("Right Bumper ") == 0)
            {
                z = 1;
            }
            
            else
            {
                z = -1;
            }
        }
        
        if (Input.GetAxis("Right Vertical " + _playerNumber) != 0 || Input.GetAxis("Right Horizontal " + _playerNumber) != 0)
        {
            y = Input.GetAxis("Right Horizontal " + _playerNumber);
            x = Input.GetAxis("Right Vertical " + _playerNumber);
        }
    }
    
    public void rotateModel() //uses input to make it so you can observe rocket
    {
        //set up input for rotate: right joystick, bumpers
        _rocketModels[_selectedModelIndex].transform.Rotate(new Vector3(x, y, z));
    }
    
    public void changeModel() //changes models position or deactivates it
    {
        //_rocketModels[_selectedModel].transform.position = offScreenPosition;
        //_rocketModels[_selectedModel].eulersAngles = new Vector3(0, 0, 0); //reset orientation of model
        _selectedModelIndex = IntBounds.SetInt(_selectedModelIndex, horizontal, 0, 1);
        //_rocketModels[_selectedModel].transform.position = new Vector3(_rocketModels[_selectedModel.p
    }
    
    public void changeMaterial()
    {
        _selectedMaterialIndex = IntBounds.SetInt(_selectedMaterialIndex, vertical, 0, 4);
        _rocketModels[_selectedModelIndex].renderer.material = _materials[_selectedModelIndex][_selectedMaterialIndex];
        //left joystick vertical input changes the index of the material and then sets it
    }
}
