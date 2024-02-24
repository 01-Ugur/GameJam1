using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnimasyonEventler : MonoBehaviour
{
    public DusmanIA dusmanIA;
    public void HasarVer()
    {
        dusmanIA.SaldiyiYap();
    }
    public void SaldiriBitti()
    {
        dusmanIA.SaldiriBitti();
    }
}
