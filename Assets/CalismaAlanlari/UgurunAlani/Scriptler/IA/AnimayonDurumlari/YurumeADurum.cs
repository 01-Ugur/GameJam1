using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class YurumeADurum : IAnimayonDurumlari
{
    public void Giris(DusmanIA dusmanIA)
    {
        dusmanIA.animator.SetInteger("Durum",1);
    }
    public void Guncelle(DusmanIA dusmanIA)
    {

    }
    public void Cikis(DusmanIA dusmanIA)
    {

    }
}
