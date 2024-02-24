using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DunyaRenkleriYonetici : MonoBehaviour
{
    public static DunyaRenkleriYonetici Instance;
    public GameManager GameManager;
    public float Mavi;
    public float kahveRengi;
    public float Yesil;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void RasgeleRenkArtdir()
    {
        float RandomSayisi = Random.Range(0f,100f);
        if (RandomSayisi<=20)
        {
            Yesil++;
        }
        else if (RandomSayisi<=60)
        {
            Mavi++;
        }
        else 
        {
            Yesil++;
        }

        
    }
}
