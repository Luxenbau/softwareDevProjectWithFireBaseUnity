using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterTemplateLoad : MonoBehaviour
{
    public GameObject characterTemplate;
    public bool connectComplete;
   [SerializeField] FireBaseConnect firebase;
    public List<Character> characters = new List<Character>();
    void Start()
    {
        Debug.Log("The very start, before characterlist execution");
        characters = firebase.CharacterList();
        Debug.Log(characters.Count +"Char");
        foreach (var character in characters)
        {
            Debug.Log(string.Format("Characters \nCharacter: {0} \nIcon ID: {1} \nPlayer: {2} \nCharacter: {3}  \nHP: {4}  \nInitiative: {5} \nRace: {6} \nClass: {7}",
                characters.IndexOf(character), 0, character.playerName, character.characterName, character.characterHP, character.characterInitiative, character.characterRace, character.characterClass));
        }

        for (int i = 0; i < characters.Count; i++)
        {
            Debug.Log("Inside of the for loop");
            GameObject character =  Instantiate(characterTemplate, gameObject.transform);
            character.GetComponent<CharacterDataLoad>().character = characters[i];
        }
    }

   
    void Update()
    {
        
    }
}
