using System.Collections;
using System.Collections.Generic;
using GM_Infinity;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public LevelInfo_SO LevelInfoSo;

    private GameObject[] platfroms;
    private GameObject player;
    private List<GameObject> platformPool;
    private Vector2 _nextPos;
    [SerializeField] private float platformOffset;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private int count;
    
    
    // Start is called before the first frame update
    void Start() {
        // init 
        _playerController.del_SpawnPlatform += ReSpawnPlatform;
        
        platformPool = new List<GameObject>();
        _nextPos = this.transform.position;
        platfroms = LevelInfoSo.platformPrefabs;
        player = LevelInfoSo.playerPrefab;
        
        
        //GenerateLevel();
        StartCoroutine(GenerateLevel());
    }

    private IEnumerator GenerateLevel() {
        for (int i = 0; i < count; i++) {
            Vector3 pos = new Vector3(_nextPos.x, _nextPos.y + platformOffset);
            GameObject go = Instantiate(GetRandomPlatform(), pos, Quaternion.identity, transform);
            _nextPos = pos;
            // add platform to pool
            platformPool.Add(go);
            yield return null;
        }    
    }

    private GameObject GetRandomPlatform() {
        return platfroms[Random.Range(0, platfroms.Length)];
    }
    
    /// <summary>
    /// it should be event trigger 
    /// </summary>
    public void ReSpawnPlatform() {
        // foreach (GameObject o in platformPool) {
        //     if (!o.activeInHierarchy) {
        //         Vector3 pos = new Vector3(_nextPos.x, _nextPos.y + platformOffset);
        //         o.transform.position = pos;
        //         o.SetActive(true);
        //         _nextPos = pos;
        //         return;
        //     }
        // }
        
        Vector2 newPos = new Vector2(_nextPos.x, _nextPos.y + platformOffset);
        GameObject go = Instantiate(GetRandomPlatform(), newPos, Quaternion.identity, transform);
        _nextPos = newPos;
        // add platform to pool
        platformPool.Add(go);
        
    } // end 
    
   
} // end 
