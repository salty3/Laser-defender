using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private float loadDelay = 1f;
    private GameSession gameSession;
    private UserInfo userInfo;

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");  
        FindObjectOfType<GameSession>().ResetGame();       
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGarage()
    {
        SceneManager.LoadScene("Garage");
    }

    public void LoadDifficulty()
    {
        SceneManager.LoadScene("Difficulty");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene("Game Over");
    }

    public void SetEasy()
    {
        FindObjectOfType<UserInfo>().SetEasy();
    }
    public void SetMedium()
    {
        FindObjectOfType<UserInfo>().SetMedium();
    }
    public void SetHard()
    {
        FindObjectOfType<UserInfo>().SetHard();
    }

}
