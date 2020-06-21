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
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private bool _isGrounded = true;
        [SerializeField] private float radius;
        private float tapInterval;
        
        // Start is called before the first frame update
        void Start() {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void FixedUpdate() {

            #region Input

            if (Input.GetMouseButtonDown(0) && _isGrounded && tapInterval <= 0f) {
                tapInterval = 0.50f;
                print("tapped");
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            tapInterval -= Time.deltaTime;

            #endregion
            
            #region ground check

            Vector2 mid = transform.position;
            //Vector2 left = new Vector2(transform.position.x+0.25f, transform.position.y);
            //Vector2 right = new Vector2(transform.position.x-0.25f, transform.position.y);
            
            // raycast only bucket 
            // if (Physics2D.Raycast(transform.position, Vector2.down, 0.30f)) {
            //     _isGrounded = true;
            // }
            // else {
            //     _isGrounded = false;
            // }

             _isGrounded = Physics2D.OverlapCircle(mid, radius, groundLayer);
             
            
            //Debug.DrawRay(mid, Vector2.down * 0.30f, Color.red);
            //Debug.DrawRay(left, Vector2.down * 0.30f, Color.red);
            //Debug.DrawRay(right, Vector2.down * 0.30f, Color.red);
            
            #endregion
            
            
        } // end 

        private void OnDrawGizmos() {
            Vector2 mid = transform.position;
            Gizmos.DrawSphere(mid, radius);
        }

        private void OnCollisionStay2D(Collision2D other) {
            if (other.gameObject.tag.Equals("LevelComplete")) {
                float dot = Vector2.Dot(transform.position, other.gameObject.transform.position);
                //print("level complete platform");
            }
            
        } // end 


        private void OnBecameInvisible() {
            if (_rigidbody.velocity.y < 10f) {
                //GameManager.Instance.RestartLevel();
            }
        }
    }
}