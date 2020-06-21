using UnityEngine;


public class Bucket : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform coinSpawnPos;

    [SerializeField] private bool isSpawnCoin = false;
    
    // Start is called before the first frame update
    void Start() {
        if (!isSpawnCoin) {
            return;
        }
        
        float rand = Random.Range(1f, 100f);
        // 50% chance to spawn coin
        if (rand >= 50) {
            Instantiate(coinPrefab, coinSpawnPos.position, Quaternion.identity, transform);
        }
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
