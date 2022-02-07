using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{

    public Button buttonQuit;

    private void Awake(){
        buttonQuit.onClick.AddListener(quit);
    }

    void quit()
	{
        UnityEditor.EditorApplication.isPlaying = false;
		Debug.Log("has quit game");
		Application.Quit();
	}
}
