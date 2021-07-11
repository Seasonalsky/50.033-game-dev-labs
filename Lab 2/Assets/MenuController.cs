using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    bool gameEnded = false;
    public bool RestartState = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform eachChild in transform)
        {
            if ((eachChild.name == "EndGameUI" || eachChild.name == "Score"))
            {
                Debug.Log("Child found. Name: " + eachChild.name);
                // disable only endgame ui
                eachChild.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        RestartState = false;
    }

    void Awake()
    {
        Time.timeScale = 0.0f;
    }

    public void StartButtonClicked()
    {
        Time.timeScale = 1.0f;
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name != "Score")
            {
                Debug.Log("Hiding all UI except score");
                // disable everything except score
                eachChild.gameObject.SetActive(false);
            }
            if (eachChild.name == "Score")
            {
                Debug.Log("Showing score");
                // enable score
                eachChild.gameObject.SetActive(true);

            }
        }
    }

    public void EndGame()
    {
        if (gameEnded == false)
        {
            foreach (Transform eachChild in transform)
            {
                if (eachChild.name == "EndGameUI")
                {
                    Debug.Log("Loading endgame sceen");
                    // enable endgame ui
                    eachChild.gameObject.SetActive(true);
                    Time.timeScale = 0.0f;
                }
            }
        }
        Debug.Log("Game Over");
    }

    public void RestartClicked()
    {
        if (RestartState == false)
        {
            {
                StartButtonClicked();
                RestartState = true;
            }
        }
        Debug.Log("Game restarted");
    }
}
