using UnityEngine;
using System.Collections;

public class GameSettingsMenu : MonoBehaviour {

    public static bool _cardsEnabled;
    public static bool _powerupsEnabled;
    
	void Awake () {
	    if (PlayerPrefs.HasKey("Cards Enabled"))
        {
            _cardsEnabled = PlayerPrefsX.GetBool("Cards Enabled");
        }
        
        else 
        {
            PlayerPrefsX.SetBool("Cards Enabled", true);
            _cardsEnabled = true;
        }
        
        if (PlayerPrefs.HasKey("Powerups Enabled"))
        {
            _powerupsEnabled = PlayerPrefsX.GetBool("Powerups Enabled");
        }
        
        else
        {
            PlayerPrefsX.SetBool("Powerups Enabled", true);
            _powerupsEnabled = true;
        }
	}

	void Update () {
	
	}
}
