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
        Debug.Log("start sahnesi açıldı");
    }

    public void OyunuKapat()
    {
        Application.Quit();
    }
}
