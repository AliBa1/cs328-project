using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pause : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        void Resume()
        {

        }

        void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GamePaused = true;
        }
    }
}
