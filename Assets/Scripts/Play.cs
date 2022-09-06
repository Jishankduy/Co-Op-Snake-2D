using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public Button buttonRestast;

    private void Awake(){
        buttonRestast.onClick.AddListener(Reloadlevel);
    }


    void Reloadlevel(){
            Debug.Log("Reloading Scene ");
            //Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(1);
    }
}
