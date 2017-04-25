using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Send : MonoBehaviour
{
    private GameManager GM;
    private string Name;
    private void Start()
    {
        Name = transform.gameObject.name;
    }
    public void OnMouseDown()
    {
        if (Name == "PauseButton")
        {
            GameManager.gs = Gamestate.pause;
        }
        else if (Name == "ReturnButton")
        {
            GameManager.gs = Gamestate.ing;
        }
        else if (Name == "NextButton")
        {
            GameManager.gs = Gamestate.generate;
        }
    }
    private void Update()
    {
        if (Name == "PlayButton")
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Mini");
            }
        }

        else if (Name == "MainButton")
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
            }
        }
    }
}
