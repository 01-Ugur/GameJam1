using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolasmada : IDavranisDurumu
{
    public void Giris(DusmanIA dusmanIA)
    {

    }
    public void Guncelle(DusmanIA dusmanIA)
    {
        if (dusmanIA.Radar())
        {
            dusmanIA.DavranisDurumuDegistir(new Saldirmada());
        }
    }
    public void Cikis(DusmanIA dusmanIA)
    {

    }
}
