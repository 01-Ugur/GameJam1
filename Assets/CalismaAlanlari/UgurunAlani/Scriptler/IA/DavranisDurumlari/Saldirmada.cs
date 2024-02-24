using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saldirmada : IDavranisDurumu
{
    public void Giris(DusmanIA dusmanIA)
    {

    }
    public void Guncelle(DusmanIA dusmanIA)
    {
        if (dusmanIA.Hedef == null)
        {
            dusmanIA.DavranisDurumuDegistir(new Dolasmada());
            return;
        }
        dusmanIA.agent.SetDestination(dusmanIA.Hedef.position);
        dusmanIA.Saldiri1AnlikBeklemeSuresi -= Time.deltaTime;
        if (dusmanIA.Saldiri1AnlikBeklemeSuresi<=0 && dusmanIA.HedefUzakligi <= dusmanIA.Saldiri1Menzil)
        {

        }
    }
    public void Cikis(DusmanIA dusmanIA)
    {

    }
}
