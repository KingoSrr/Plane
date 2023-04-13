using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GreenPlayerController : MonoBehaviour
{
    public int health = 5;
    private float _speed = 5f; // Скорость передвижения
    private Rigidbody2D _rb; // Ссылка на компонент Rigidbody2D

    public GameObject[] rocketSpawnPoint; // Места спавна ракет
    public GameObject rocketPrefab; // Префаб ракеты

    private float _fireRate = 0.5f; // Частота стрельбы в выстрелах в секунду
    private float _timeSinceLastShot; // Время с момента последнего выстрела

    private GameObject _scripts;
    private float minX, maxX, minY, maxY; // Границы экрана

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _scripts = GameObject.FindGameObjectWithTag("Scripts");
        CheckBorder();
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
    public void CheckBorder()
    {
        Camera mainCamera = Camera.main;
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float cameraHeight = mainCamera.orthographicSize * 2;
        float cameraWidth = cameraHeight * screenRatio;

        minX = mainCamera.transform.position.x - cameraWidth / 2;
        maxX = mainCamera.transform.position.x + cameraWidth / 2;
        minY = mainCamera.transform.position.y - cameraHeight / 2;
        maxY = mainCamera.transform.position.y + cameraHeight / 2;
    }
    public void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.RightControl))
        {
            _timeSinceLastShot = 0.0f;
            GameObject rocket = Instantiate(rocketPrefab, rocketSpawnPoint[Random.Range(0 , rocketSpawnPoint.Length)].transform.position, Quaternion.Euler(0f, 0f, rocketPrefab.transform.eulerAngles.z + 180));
            rocket.GetComponent<RocketController>().parentTag = gameObject.tag;
        }
    }
    private void Move()
    {
        float horizontal = Input.GetAxis("ArrowHorizontal");
        float vertical = Input.GetAxis("ArrowVertical");

        Vector3 moveDirection = transform.position +  new Vector3(horizontal, vertical, 0f);

        moveDirection.x = Mathf.Clamp(moveDirection.x, minX + GetComponent<PolygonCollider2D>().bounds.size.x, maxX - GetComponent<PolygonCollider2D>().bounds.size.x);
        moveDirection.y = Mathf.Clamp(moveDirection.y, minY + GetComponent<PolygonCollider2D>().bounds.size.y, maxY - GetComponent<PolygonCollider2D>().bounds.size.y);

        transform.position = Vector3.Lerp(transform.position, moveDirection, _speed * Time.deltaTime);
    }
    public void GiveDamage()
    {
        health--;
        GameObject.FindGameObjectWithTag("Scripts").GetComponent<UIController>().GreenHeartUpdate(health);
    }
}
