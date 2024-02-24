using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Dolasmada : IDavranisDurumu
{
    public void Giris(DusmanIA dusmanIA)
    {
        dusmanIA.hedefKonum = dusmanIA.transform.position;
    }
    public void Guncelle(DusmanIA dusmanIA)
    {
        if (dusmanIA.Radar())
        {
            dusmanIA.DavranisDurumuDegistir(new Saldirmada());
        }
        dusmanIA.RasgeleDolasNA();
    }
    public void Cikis(DusmanIA dusmanIA)
    {

    }
}
