using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurmaADurum : IAnimayonDurumlari
{
    public void Giris(DusmanIA dusmanIA)
    {
        dusmanIA.animator.SetInteger("Durum",0);
    }
    public void Guncelle(DusmanIA dusmanIA)
    {

    }
    public void Cikis(DusmanIA dusmanIA)
    {

    }
}
