using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuYonetici : MonoBehaviour
{

    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            BackToMenu();
        }
        if(Input.GetKeyDown(KeyCode.F5))
        {
            Quit();
        }
        
    }
    public void BackToMenu(){
        SceneManager.LoadScene("Start");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
