using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class Bucket : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform coinSpawnPos;

    [SerializeField] private bool isSpawnCoin = false;
    
    [SerializeField] public AnimationCurve _curve;
    private Vector2 pos1;
    private Vector2 pos2;
    
    // Start is called before the first frame update
    void Start() {

        pos1 = transform.position;
        pos2 = new Vector2(pos1.x+1f, pos1.y);
        //StartCoroutine(Move(pos1, pos2, _curve, 4f));
        
        if (!isSpawnCoin) {
            return;
        }
        
        float rand = Random.Range(1f, 100f);
        // 50% chance to spawn coin
        if (rand >= 50) {
            Instantiate(coinPrefab, coinSpawnPos.position, Quaternion.identity, transform);
        }
    }

    IEnumerator Move ( Vector3 pos1, Vector3 pos2, AnimationCurve ac, float time ) {
        float timer = 0.0f;
        while (timer <= time) {
            transform.position = Vector3.Lerp (pos1, pos2, ac.Evaluate (timer / time));
            timer += Time.deltaTime;
            
            print(Vector2.Distance(transform.position, pos2));
           
            yield return null;
        }

        StartCoroutine(Move(pos2, pos1, _curve, 4f));
    }

    private void Update() {
        transform.position = Vector3.Lerp (pos1, pos2, _curve.Evaluate (Time.deltaTime / 4f));
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Player")) {
            other.transform.parent = this.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Player")) {
            other.transform.parent = null;
        }
    }
    
}
