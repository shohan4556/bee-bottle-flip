using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
