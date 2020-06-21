using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public LevelInfo_SO LevelInfoSo;

    private GameObject[] platfroms;
    private GameObject player;
    private Queue<GameObject> platformPool;
    private Vector2 _nextPos;
    [SerializeField] private float platformOffset;

    [SerializeField] private int count;
    
    
    // Start is called before the first frame update
    void Start() {
        platformPool = new Queue<GameObject>();
        _nextPos = this.transform.position;
        platfroms = LevelInfoSo.platformPrefabs;
        player = LevelInfoSo.playerPrefab;
        
        GenerateLevel();
    }

    private void GenerateLevel() {
        for (int i = 0; i < count; i++) {
            Vector3 pos = new Vector3(_nextPos.x, _nextPos.y + platformOffset);
            GameObject go = Instantiate(GetRandomPlatform(), pos, Quaternion.identity, transform);
            _nextPos = pos;
            
            platformPool.Enqueue(go);
        }    
    }

    private GameObject GetRandomPlatform() {
        return platfroms[Random.Range(0, platfroms.Length)];
    }
    
   
}
