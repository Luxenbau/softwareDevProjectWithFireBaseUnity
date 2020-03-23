using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterTemplateLoad : MonoBehaviour
{
    public GameObject characterTemplate;
    public bool connectComplete;
   [SerializeField] FireBaseConnect firebase;
    public List<Character> characters = new List<Character>();
    public List<GameObject> templates = new List<GameObject>();
    CharacterPartyLoad characterPartyLoad;

    void Start()
    {
        GetData();
    }

    public void GetData()
    {
        for (int i = 0; i < templates.Count; i++)
        {
            Destroy(templates[i].gameObject);
        }
        templates.Clear();
        characters.Clear();
        firebase.GetCharactersFromDatabase();
    }

    //public void SelectCharactersThatAreAlreadyInParty()
    //{
    //    if (characterPartyLoad.templates.Count>0)
    //    {
    //        foreach (var character in templates)
    //        {
    //            foreach (var currentCharacter in characterPartyLoad.templates)
    //            {
    //                if (character==currentCharacter)
    //                {
    //                    character.GetComponent<CharacterDataLoad>().charSelected = true;
    //                }
    //            }
    //        }
    //    }

    //}

    public void LoadCharactersTemplates()
    {
        characters = firebase.CharacterList();

        foreach (var character in characters)
        {
            Debug.Log(string.Format("Characters \nCharacter: {0} \nIcon ID: {1} \nPlayer: {2} \nCharacter: {3}  \nHP: {4}  \nInitiative: {5} \nRace: {6} \nClass: {7}",
                characters.IndexOf(character), 0, character.playerName, character.characterName, character.characterHP, character.characterInitiative, character.characterRace, character.characterClass));
        }

        for (int i = 0; i < characters.Count; i++)
        {   
            Debug.Log("Inside of the for loop");
            GameObject character = Instantiate(characterTemplate, gameObject.transform);
            templates.Add(character);
            character.GetComponent<CharacterDataLoad>().character = characters[i];
            // Save location of the view, where it is located ( party or character add )
            character.GetComponent<CharacterDataLoad>().currentLocation = "selectPage";


          //  if (characterPartyLoad.currentPartyCharacters.Count > 0)
            //{
            //    Debug.Log("Got into the if");
            //    for (int j = 0; j < characterPartyLoad.currentPartyCharacters.Count; j++)
            //    {
            //        if (characterPartyLoad.currentPartyCharacters[j] == characters[i])
            //        {
            //            character.GetComponent<CharacterDataLoad>().testing = true;
            //        }
            //    }
            //}
        }
    }
   
    void Update()
    {
        if (connectComplete)
        {
            LoadCharactersTemplates();
            connectComplete = false;
        }
    }
}
