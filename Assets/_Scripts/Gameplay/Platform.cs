using System;
using System.Collections;
using System.Collections.Generic;
using GM_Infinity;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject prefab;
    [SerializeField] private float offset;

    private Transform _player;
    
    // Start is called before the first frame update
    void Start() {
        _player = GameObject.FindWithTag("Player").transform;    
        _spriteRenderer = GetComponent<SpriteRenderer>();
       
        float platformTop = this.transform.position.y + _spriteRenderer.size.y/2;
        Vector3 blockCentre = new Vector3(this.transform.position.x, platformTop + offset, this.transform.position.z);
        GameObject go = Instantiate(prefab, blockCentre, Quaternion.identity, this.transform);
    }

    private void Update() {
        // Vector2 forward = transform.TransformDirection(Vector2.up);
        // Vector2 dir = (_player.position - transform.position);
        //
        // if (Vector3.Dot(forward, dir) >= 5f) {
        //     //print("player passed platform "+this.name);
        //     this.gameObject.SetActive(false);
        // }
    }
}
