using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public Image[] greenHeartContainerImg;
    public Image[] blueHeartContainerImg;
    public Sprite emptyHeartImg;

    public GameObject gameOverPanel;
    public TMP_Text win;

    private void Start() 
    {
        Time.timeScale = 1;
    }
    public void GameOver(string winPlayer)
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        win.text = $"Победитель - {winPlayer}";
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void MenutBtn()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void PlayBtn()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ExitBtn()
    {
        Application.Quit(1);
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
