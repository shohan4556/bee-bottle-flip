using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GM_Infinity
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        public float jumpForce = 10f;
        [SerializeField]
        private bool _isGrounded = true;

        [SerializeField] 
        public float nextTapTime = 0.10f;
        
        // Start is called before the first frame update
        void Start() {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void FixedUpdate() {
            if (Input.GetMouseButtonDown(0) && _isGrounded && nextTapTime <= 0f) {
                print("tapped");
                //_rigidbody.velocity += Vector2.up * jumpForce;
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                nextTapTime -= Time.deltaTime;
            }

            if (Physics2D.Raycast(transform.position, Vector2.down, 0.35f)) {
                _isGrounded = true;
            }
            else {
                _isGrounded = false;
                nextTapTime = 0.2f;
            }
            
            Debug.DrawRay(transform.position, Vector2.down * 0.35f, Color.red);
            
        } // end 

    }
}