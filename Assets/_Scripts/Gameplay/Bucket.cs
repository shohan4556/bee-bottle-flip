using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class Bucket : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform coinSpawnPos;

    [SerializeField] private bool isSpawnCoin = false;
    [SerializeField] private bool isMove = false;
    
    private Vector3 pos1;
    private Vector3 pos2;

    private float moveSpeed;
    private float rndLength;
    
    // Start is called before the first frame update
    void Start() {

        RandomMovememt();

        pos1 = transform.localPosition;
        pos1.x -= 0.5f;
        
        pos2 = transform.localPosition;
        pos2.x += 0.5f;
             
        float rand = Random.Range(1f, 100f);
        // 50% chance to move or stay freze
        //if (rand >= 50) {
            //isMove = true;
        //}
        
        if (!isSpawnCoin) {
            return;
        }
        
        // 50% chance to spawn coin
        if (rand >= 50) {
            Instantiate(coinPrefab, coinSpawnPos.position, Quaternion.identity, transform);
        }
    }

    private void RandomMovememt() {
        moveSpeed = Random.Range(0.25f, 1f);
        rndLength = Random.Range(0.75f, 1.5f);
    }


    private void Update() {
        if (isMove) {
            transform.localPosition = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * moveSpeed, rndLength));
        }
    }

}
