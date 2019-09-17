using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickup : MonoBehaviour
{

    public int value;
    public GameObject pickupEffect;
    private float lifetime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<GameManager>().addCrystal(value);    
            Instantiate(pickupEffect, transform.position, transform.rotation);         
            Destroy(gameObject, lifetime);
        }
    }
}
