﻿using System;
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
        private float levelCompleteTriggerTime;
        
        // Start is called before the first frame update
        void Start() {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void FixedUpdate() {

            #region Input
            // mouse button down slow on mobile
#if UNITY_EDITOR
            
            if (Input.GetMouseButtonDown(0) && _isGrounded && tapInterval <= 0f) {
                transform.parent = null;
                tapInterval = 0.50f;
                print("tapped "+ tapInterval);
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
#endif

#if PLATFORM_ANDROID
            if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Began) && _isGrounded && tapInterval <= 0f) {
                transform.parent = null;
                tapInterval = 0.50f;
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
#endif
            
            tapInterval -= Time.deltaTime;

            #endregion
            
            #region ground check

            Vector2 mid = transform.position;
            _isGrounded = Physics2D.OverlapCircle(mid, radius, groundLayer);
             
            #endregion
            
            
        } // end 

        private void OnDrawGizmos() {
            Vector2 mid = transform.position;
            Gizmos.DrawSphere(mid, radius);
        }

        private void OnCollisionStay2D(Collision2D other) {
            if (other.gameObject.tag.Equals("LevelComplete")) {
                levelCompleteTriggerTime += Time.deltaTime;
                if (levelCompleteTriggerTime >= 1.5f) {
                    GameManager.Instance.RestartLevel();
                }
                
            }
            
        } // end 

        private void OnCollisionExit2D(Collision2D other) {
            if (other.gameObject.tag.Equals("LevelComplete")) {
                levelCompleteTriggerTime = 0f;
            }
        }


        private void OnTriggerEnter2D(Collider2D other) {
            if (other.tag.Equals("Coin")) {
                other.gameObject.SetActive(false);
            }
        }

        private void OnBecameInvisible() {
            if (_rigidbody.velocity.y < 10f) {
                //GameManager.Instance.RestartLevel();
            }
        }
        
    }
}