using UnityEngine;
using System.Collections;
using TMPro;

public sealed class GameAssetDatabase : MonoBehaviour
{
    private static GameAssetTableForms formsTable;
    public GameAssetTableForms FormsTable { get { return formsTable; } private set { formsTable = value; } }
    private static GameAssetTableCharacters charactersTable;
    public GameAssetTableCharacters CharactersTable { get { return charactersTable; } private set { charactersTable = value; } }

    public void LoadTables()
    {
        Debug.Log("Loading Forms Table.");
        if(formsTable == null)
        {
            formsTable = new GameAssetTableForms();
            StartCoroutine(formsTable.LoadTable());
        }
        if(charactersTable == null)
        {
            charactersTable = new GameAssetTableCharacters();
            StartCoroutine(charactersTable.LoadTable());
        }
    }

    private void Start()
    {
        LoadTables();
        Form academyCreationForm;
        academyCreationForm = this.FormsTable.GetAsset("AcademyCreationForm");
        Character cub1 = this.CharactersTable.GetAsset("Cub");
        //print("Text retrieved: " + academyCreationForm.gameObject.GetComponent<TMP_InputField>().text);
        //print("Char ref: " + this.CharactersTable.Assets.ToString());

    }
}
