using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

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
        if (dusmanIA.HedefUzakligi <= dusmanIA.Saldiri1Menzil)
        {
            dusmanIA.transform.LookAt(dusmanIA.Hedef);
            dusmanIA.transform.eulerAngles= new Vector3(0,dusmanIA.transform.eulerAngles.y,0);
            if (dusmanIA.Saldiri1AnlikBeklemeSuresi <= 0 && dusmanIA.SaldiriAktif == false)
            {
                dusmanIA.SaldiriAktif = true;
                dusmanIA.Saldiri1AnlikBeklemeSuresi = dusmanIA.Saldiri1BeklemeSuresi;
                dusmanIA.AnimasyonDurumuDegistir(new Saldirma1ADurum());
            }
        }
        
        //if (dusmanIA.HedefiBirakmaYaricapi<=dusmanIA.HedefUzakligi)
        //{
        //    dusmanIA.Hedef = null;
        //    dusmanIA.DavranisDurumuDegistir(new Dolasmada());
        //}
    }
    public void Cikis(DusmanIA dusmanIA)
    {

    }
}
