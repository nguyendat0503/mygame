using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Level1Control : MonoBehaviour
{
    public static Level1Control instance;

    [SerializeField]
    private Text scoreText,endScoreText,bestScoreText;

    [SerializeField]
    private GameObject gameOverPanel,gamePause;
    [SerializeField]
    private AudioSource audioSoure;

    private void Awake()
    {
        MakeInstance();
        audioSoure.Play();
    }

    void FixedUpdate()
    {
        if(PenguinControl.instance.flag == 1)
        {
            audioSoure.volume -= 0.001f;
        }
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Level1");
    }
    public void RestartStage1Button()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PauseButton()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            gamePause.SetActive(true);
            audioSoure.Stop();
        }
        else
        {
            Time.timeScale = 1;
            gamePause.SetActive(false);
            audioSoure.Play();
        }
    }
    public void SetScore(float score)
    {
        int x = (int)score;
        scoreText.text =""+ x;
    }
    public void GameOverPanel(float score)
    {
        gameOverPanel.SetActive(true);
        int x = (int)score;
        endScoreText.text = "" + x;
        if (score > ManagerControl.instance.GetHightScore())
        {
            ManagerControl.instance.SetHightScore(score);
        }
        bestScoreText.text = "" + ManagerControl.instance.GetHightScore();
    }
}
