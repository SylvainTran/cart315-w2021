using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using System.Reflection;

public class GameAssetTableForms : GameAssetTable<Form>
{
    /**
     *  Loads the table.
     */
    public override IEnumerator LoadTable()
    {
        Debug.Log("Asset type label to load: " + "forms");
        yield return Addressables.LoadAssetsAsync<GameObject>("forms", asset =>
        {
            Form a = asset.GetComponent<Form>();
            if (a != null)
            {
                assets.Add(a.GameAssetName, a);
                Debug.Log("Table loaded a " + a.GameAssetName + " with content " + GetAsset(a.GameAssetName));
            }
        });
    }
}
