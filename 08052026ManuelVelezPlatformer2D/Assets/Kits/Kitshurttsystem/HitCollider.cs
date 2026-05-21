using System;
using UnityEngine;
using UnityEngine.Events;

public class HitCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("gol-lpeo");
        if(collision.tag !=gameObject.tag)
        {
        HurtCollider hurtcollider=collision.GetComponent<HurtCollider>();
        hurtcollider?.Notifyhit(this);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
