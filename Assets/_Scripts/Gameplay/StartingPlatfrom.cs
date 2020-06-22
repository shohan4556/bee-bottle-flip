using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPlatfrom : MonoBehaviour
{
    
    private Transform _player;
    
    // Start is called before the first frame update
    void Start() {
        _player = GameObject.FindWithTag("Player").transform;    
        
    }

    private void Update() {
        Vector2 forward = transform.TransformDirection(Vector2.up);
        Vector2 dir = (_player.position - transform.position);
        
        if (Vector3.Dot(forward, dir) >= 5f) {
            //print("player passed platform "+this.name);
            this.gameObject.SetActive(false);
        }
    }
}
