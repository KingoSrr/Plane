using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public Image[] greenHeartContainerImg;
    public Image[] blueHeartContainerImg;
    public Sprite emptyHeartImg;

public GameObject gameOverPanel;
    public TMP_Text win;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void GameOver(string winPlayer)
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        win.text = $"Победитель - {winPlayer}";
    }
    public void GreenHeartUpdate(int health)
    {
        greenHeartContainerImg[health].sprite = emptyHeartImg;
    }
    public void BlueHeartUpdate(int health)
    {
        blueHeartContainerImg[health].sprite = emptyHeartImg;
    }
}
