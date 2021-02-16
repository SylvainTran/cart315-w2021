﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAsset : MonoBehaviour
{
    /**
     * Generic attributes.
     */
    [SerializeField]
    protected static int gameAssetId = default;
    public int GameAssetId { get { return gameAssetId; } set { gameAssetId = value; } }
    /**
     * Used in the database hashmap as the key
     * to retrive this game object.
     */
    [SerializeField]
    protected string gameAssetName;
    public string GameAssetName { get { return gameAssetName; } set { gameAssetName = value; } }

    /**
     * Addressable specific attributes.
     */
    [SerializeField]
    private string label = default;
    public string Label { get { return label; } set { label = value; } }
    [SerializeField]
    private string description = default;
    public string Description { get { return description; } set { description = value; } }

    public GameAsset() {}
}