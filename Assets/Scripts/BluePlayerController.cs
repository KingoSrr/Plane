using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BluePlayerController : MonoBehaviour
{
    public int health = 5;
    private float _speed = 5f; // Скорость передвижения
    private Rigidbody2D _rb; // Ссылка на компонент Rigidbody2D

    public GameObject[] rocketSpawnPoint;    
    public GameObject rocketPrefab; // Префаб ракеты

    private float _fireRate = 0.5f; // Частота стрельбы в выстрелах в секунду
    private float _timeSinceLastShot; // Время с момента последнего выстрела

    private GameObject _scripts;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _scripts = GameObject.FindGameObjectWithTag("Scripts");
    }
    void Update()
    {
        Move();
        if ((_timeSinceLastShot += Time.deltaTime) > _fireRate)
        {
            Shoot();
        }
        CheckHealth();
    }
    public void CheckHealth()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            _scripts.GetComponent<UIController>().GameOver("Синий игрок");
        }
    }
    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _timeSinceLastShot = 0.0f;
            GameObject rocket = Instantiate(rocketPrefab, rocketSpawnPoint[Random.Range(0 , rocketSpawnPoint.Length)].transform.position, Quaternion.Euler(0f, 0f, rocketPrefab.transform.eulerAngles.z + 0));
            rocket.GetComponent<RocketController>().parentTag = gameObject.tag;
        }
    }
    private void Move()
    {
        float horizontal = Input.GetAxis("wasdHorizontal");
        float vertical = Input.GetAxis("wasdVertical");
        Vector2 moveDirection = new Vector2(horizontal, vertical) * _speed;
        _rb.velocity = moveDirection;
    }
    public void GiveDamage()
    {
        health--;
        GameObject.FindGameObjectWithTag("Scripts").GetComponent<UIController>().BlueHeartUpdate(health);
    }
}
