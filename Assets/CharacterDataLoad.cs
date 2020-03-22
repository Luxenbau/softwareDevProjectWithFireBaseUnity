using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterDataLoad : MonoBehaviour
{
    public TextMeshProUGUI charName;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI className;
    public TextMeshProUGUI raceName;
    public TextMeshProUGUI charHP;
    public TextMeshProUGUI charInitiative;
    public Image charImage;
    public Character character;
    




    public void CharDataLoad()
    {
        //Debug.Log("Starting data load");
        charName.text = character.characterName;
        playerName.text = character.playerName;
        className.text = character.characterClass;
        raceName.text = character.characterRace;
        charHP.text = character.characterHP.ToString();
        charInitiative.text = character.characterInitiative.ToString();

    }



    void Start()
    {
       
        // character = new Character();
        //character.CharacterData(0, "Mark", "Mark", 10, 4, "Dwarf", "Paladin");
    }

   
    void Update()
    {
        if (character != null)
        {
            CharDataLoad();
        }
       
    }
}
