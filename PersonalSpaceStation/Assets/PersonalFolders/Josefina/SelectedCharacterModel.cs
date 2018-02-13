using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharacterModel : MonoBehaviour {

    public CharacterSelection player;
    public int modelNumber;

   
    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        modelNumber = player.selection;
        //Debug.Log(derp);
	}

   // public void LoadCharacterModel(string derp)
    //{
      //  var derp = Resources.Load(Character) as Character;      
    //}

}

