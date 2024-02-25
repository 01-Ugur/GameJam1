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
        
    }
    public void BackToMenu(){
        SceneManager.LoadScene("Start");
    }

    public void OyunuKapat()
    {
        Application.Quit();
    }
}
