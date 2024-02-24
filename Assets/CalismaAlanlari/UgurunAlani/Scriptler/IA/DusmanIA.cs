using UnityEngine;
using UnityEngine.AI;
public class DusmanIA : MonoBehaviour
{
    private IDavranisDurumu AnlikDavranisDurumu;
    private IAnimayonDurumlari AnlikAnimasyonDurumu;
    private IAnimayonDurumlari EskiAnimasyonDurumu;
    [Header("Parametreler")]
    [SerializeField] private float MaxCan;
    [SerializeField] private float AnliKCan;
    [SerializeField] private float Hiz;
    [SerializeField] private float RadarYariCapi;
    [SerializeField] private LayerMask RadarKatmani;
    [SerializeField] private Vector3 MerkezOfeset;
    public float HedefUzakligi;
    [Header("SaldiriParametreleri")]
    public float Saldiri1Hasari;
    public float Saldiri1BeklemeSuresi;
    public float Saldiri1AnlikBeklemeSuresi;
    public float Saldiri1Menzil;
    [Header("Kodla Atanan Kablolar")]
    public Transform Hedef;
    [Header("kablolar")]
    public NavMeshAgent agent;
    [SerializeField] private Animator animator;
    void Start()
    {
        AnliKCan = MaxCan;
        agent.speed = Hiz;

        AnlikDavranisDurumu = new Dolasmada();//Baslangic Durumu Ata
        AnlikDavranisDurumu.Giris(this);
    }
    void Update()
    {
        if (Hedef != null)
        {
            HedefUzakligi = (transform.position - Hedef.position).magnitude;
        }
        else
        {
            HedefUzakligi = 1000f;
        }

        AnlikDavranisDurumu.Guncelle(this);
    }
    public void DavranisDurumuDegistir(IDavranisDurumu yeniDurum)
    {
        yeniDurum.Cikis(this);
        AnlikDavranisDurumu = yeniDurum;
        yeniDurum.Giris(this);
    }
    public void AnimasyonDurumuDegistir(IAnimayonDurumlari yeniDurum)
    {
        EskiAnimasyonDurumu = AnlikAnimasyonDurumu;
    }
    public bool Radar()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position + MerkezOfeset, RadarYariCapi,RadarKatmani);
        if (0 < colliders.Length)
        {
            Hedef = colliders[0].transform;
            return true;
        }
        return false;
    }
}
