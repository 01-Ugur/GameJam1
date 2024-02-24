using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saldirma1ADurum : IAnimayonDurumlari
{
    public void Giris(DusmanIA dusmanIA)
    {
        dusmanIA.animator.SetInteger("Durum",2);
    }
    public void Guncelle(DusmanIA dusmanIA)
    {
        
    }
    public void Cikis(DusmanIA dusmanIA)
    {

    }
}
