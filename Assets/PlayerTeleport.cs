using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    [SerializeField]
    GameObject Destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        other.transform.position = Destination.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
