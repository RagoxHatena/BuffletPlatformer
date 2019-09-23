using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public int toHeal;
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

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(FindObjectOfType<HealthManager>().CurrentHP < FindObjectOfType<HealthManager>().MaxHP)
            {
                FindObjectOfType<HealthManager>().HealPlayer(toHeal);
                Instantiate(pickupEffect, transform.position, transform.rotation);
                Destroy(gameObject, lifetime);
            }
        }
    }
}
