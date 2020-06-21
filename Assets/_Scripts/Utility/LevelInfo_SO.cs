using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum LevelType
{
    infinityLevel,
    sortLevel,
    longLevel
}

[CreateAssetMenu(fileName = "New Level Data", menuName = "Levels/New Level Data", order = 1)]
public class LevelInfo_SO : ScriptableObject
{
    
    public LevelType levelType;
    [Header("Level Platforms")]
    public GameObject[] platformPrefabs;
    [Header("Player Object")]
    public GameObject playerPrefab;
    
    private void OnValidate() {
        if (levelType == LevelType.infinityLevel) {
            Array.Resize(ref platformPrefabs,1);
        }
    }
    
    //todo get last used playerprefab 

}
