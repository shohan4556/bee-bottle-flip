using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public GameObject prefab;
    public float offset;
    
    // Start is called before the first frame update
    void Start() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
       
        float platformTop = this.transform.position.y + _spriteRenderer.size.y/2;
        Vector3 blockCentre = new Vector3(this.transform.position.x, platformTop + offset, this.transform.position.z);
        GameObject test = Instantiate(prefab, blockCentre, Quaternion.identity, this.transform);
    }

    
}
