using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public delegate void PlatfromSpwn();

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
        private Vector2 _initPos;
        
        
        public PlatfromSpwn del_SpawnPlatform;
        
        
        // Start is called before the first frame update
        void Start() {
            _rigidbody = GetComponent<Rigidbody2D>();
            _initPos = transform.position;
        }

        // Update is called once per frame
        void FixedUpdate() {

            #region Input
            // mouse button down slow on mobile
#if UNITY_EDITOR
            
            if (Input.GetMouseButtonDown(0) && _isGrounded && tapInterval <= 0f) {
                transform.parent = null;
                tapInterval = 0.50f;
                //print("tapped "+ tapInterval);
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
#endif

#if PLATFORM_ANDROID
            if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Began) && _isGrounded && tapInterval <= 0f) {
                // todo vibration 
                // todo soundFX
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

            // gameover 
            if (_rigidbody.velocity.y < -15f) {
                _rigidbody.isKinematic = true;
                GameManager.Instance.GameOver("Gameover");
            }
            
            
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
        } // end 

        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.tag.Equals("Ground")) {
                
                //print(transform.position.y - _initPos.y);
                float distance = Vector2.Distance(transform.position, _initPos);
                if (distance >= 1.5f) {
                    _initPos = transform.position;
                    if (del_SpawnPlatform != null) {
                        
                        print("spawn next platform");
                        del_SpawnPlatform();
                    }
                }
                print(distance);
            }
        }// end
        
      
        
        
    }
}