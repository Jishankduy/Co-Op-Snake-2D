using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Snake snake;
    public Snake2 snake2;
    public Button buttonStop;
    public Button buttonResume;
    public GameObject LevelLobby;
    
    private void Awake() {
        buttonStop.onClick.AddListener(PlayGame);
        buttonResume.onClick.AddListener(Resume);
    }

    private void PlayGame() {
        //SceneManager.LoadScene(1);
        LevelLobby.SetActive(true);
        snake.StopControl();
        snake2.StopControl();
        
    }

    private void Resume()
    {
        LevelLobby.SetActive(false);
        snake.StartControl();
        snake2.StartControl();
    }
}
