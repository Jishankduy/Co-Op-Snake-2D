using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelRestart : MonoBehaviour
{
    public Button buttonRestast;

    private void Awake(){
        buttonRestast.onClick.AddListener(Reloadlevel);
    }

    void Reloadlevel(){
            Debug.Log("Reloading Scene ");
            SceneManager.LoadScene(0);
    }
}
