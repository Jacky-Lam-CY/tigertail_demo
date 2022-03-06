using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TigerTail.FPSController
{
    public class RopeMovement : MonoBehaviour
    {
        private bool onRope = false;
        public GameObject player;
        Rigidbody rope;
        Rigidbody self;

        CharacterJoint cj;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindWithTag("Player");
            self = gameObject.GetComponent<Rigidbody>();
            onRope = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Rope") && Input.GetKey("f"))
            {
                onRope = true;
                GetComponent<FPSMovement>().enabled = false;
                rope = other.GetComponent<Rigidbody>();
                GetComponent<Rigidbody>().mass = 5f;
                cj = this.gameObject.AddComponent<CharacterJoint>();
                cj.connectedBody = rope;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (onRope && Input.GetKey("r"))
            {
                Destroy(cj);
                self.AddForce(self.velocity.normalized * 5000);
                GetComponent<Rigidbody>().mass = 65f;            
                onRope = false;
                GetComponent<FPSMovement>().enabled = true;
            }

            float Vertical = 200;

            if (onRope && Input.GetKey("w"))
            {
                rope.AddForce(transform.forward * Vertical,ForceMode.Acceleration);
            }
        }
    }
}