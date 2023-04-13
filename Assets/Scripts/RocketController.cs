using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public string parentTag;
    public float rocketSpeed = 10f; // Скорость полета ракеты
    void Start()
    {
        
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * rocketSpeed;
        Destroy(gameObject, 5.0f);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "GreenPlayer" && other.gameObject.tag != parentTag)
        {
            other.gameObject.GetComponent<GreenPlayerController>().GiveDamage();
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "BluePlayer" && other.gameObject.tag != parentTag)
        {
            other.gameObject.GetComponent<BluePlayerController>().GiveDamage();
            Destroy(gameObject);
        }
    }
}
