using JUTPS;
using UnityEngine;
using UnityEngine.AI;
public class DusmanIA : MonoBehaviour
{
    private IDavranisDurumu AnlikDavranisDurumu;
    private IAnimayonDurumlari AnlikAnimasyonDurumu;
    private IAnimayonDurumlari EskiAnimasyonDurumu;
    [Header("Parametreler")]
    [SerializeField] private float MaxCan;
    [SerializeField] private float AnlikCan;
    [SerializeField] private float Hiz;
    public float RadarYariCapi;
    public float HedefiBirakmaYaricapi;
    [SerializeField] private LayerMask RadarKatmani;
    [SerializeField] private Vector3 MerkezOfeset;
    public float HedefUzakligi;
    [Header("SaldiriParametreleri")]
    public float SaldirilarArasiDelay;
    public bool SaldiriAktif;
    public float Saldiri1Hasari;
    public float Saldiri1BeklemeSuresi;
    public float Saldiri1AnlikBeklemeSuresi;
    public float Saldiri1Menzil;
    [Header("DolasmaParametreler")]
    public float Dolas�mBSKatsayisi = 2;
    public float MaxHedefVard�kdanSornaBS = 5;
    public float MinHedefVard�kdanSornaBS = 2;
    private float AnlikHedefVard�kdanSornaBS;
    public float RasgeleDolasmaYaricapi = 7;
    private float AnlikHedefeVarmaSuresi;
    public int AnlikDolasmaIndeksi = 0;
    [Header("Kodla Atanan Kablolar")]
    public Transform Hedef;
    public Vector3 hedefKonum;
    [Header("kablolar")]
    public NavMeshAgent agent;
    public Animator animator;
    public CapsuleCollider capsuleCollider;

    public Rigidbody[] rigidbodies;
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        ToggleRagdoll(false);

        AnlikCan = MaxCan;
        agent.speed = Hiz;

        AnlikDavranisDurumu = new Dolasmada();//Baslangic Durumu Ata
        AnlikDavranisDurumu.Giris(this);

        AnlikAnimasyonDurumu = new DurmaADurum();// Baslangic Durumu Ata
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
        AnlikAnimasyonDurumu.Guncelle(this);
    }
    public void DavranisDurumuDegistir(IDavranisDurumu yeniDurum)
    {
        AnlikDavranisDurumu.Cikis(this);
        AnlikDavranisDurumu = yeniDurum;
        AnlikDavranisDurumu.Giris(this);
    }
    public void AnimasyonDurumuDegistir(IAnimayonDurumlari yeniDurum)
    {
        EskiAnimasyonDurumu = AnlikAnimasyonDurumu;
        AnlikAnimasyonDurumu.Cikis(this);
        AnlikAnimasyonDurumu = yeniDurum;
        AnlikAnimasyonDurumu.Giris(this);
    }
    public bool Radar()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position + MerkezOfeset, RadarYariCapi, RadarKatmani);
        if (0 < colliders.Length)
        {
            Hedef = colliders[0].transform;
            return true;
        }
        return false;
    }
    public void SaldiyiYap()
    {
        if (HedefUzakligi <= Saldiri1Menzil)
        {
            Hedef.GetComponent<JUCharacterController>().TakeDamage(Saldiri1Hasari);
        }
    }

    public void SaldiriBitti()
    {
        SaldiriAktif = false;
        if (Saldiri1AnlikBeklemeSuresi < SaldirilarArasiDelay)
        {
            Saldiri1BeklemeSuresi = SaldirilarArasiDelay;
        }
        if (EskiAnimasyonDurumu.GetType() != new Saldirma1ADurum().GetType())
        {
            AnimasyonDurumuDegistir(EskiAnimasyonDurumu);
        }
    }
    public void RasgeleDolasNA()
    {
        float Distance = Vector3.Distance(transform.position, hedefKonum);

        AnlikHedefeVarmaSuresi -= Time.deltaTime;

        if (Distance <= 0.3f || AnlikHedefeVarmaSuresi <= 0)
        {
            AnlikHedefVard�kdanSornaBS -= Time.deltaTime;

            if (AnlikAnimasyonDurumu.GetType() != new HasarAlmaADurum().GetType())
            {
                AnimasyonDurumuDegistir(new DurmaADurum());
            }
            if (AnlikHedefVard�kdanSornaBS <= 0)
            {
                AnimasyonDurumuDegistir(new YurumeADurum());

                hedefKonum = NavMeshEnyakinNoktaBul(transform.position, RasgeleDolasmaYaricapi);
                AnlikHedefVard�kdanSornaBS = UnityEngine.Random.Range(MinHedefVard�kdanSornaBS, MaxHedefVard�kdanSornaBS);
                AnlikHedefeVarmaSuresi = Vector3.Distance(transform.position, hedefKonum) * agent.speed * Dolas�mBSKatsayisi;
                agent.destination = hedefKonum;
            }
        }
    }
    public Vector3 NavMeshEnyakinNoktaBul(Vector3 merkez, float yaricap)
    {
        Vector3 rasgeleYon = UnityEngine.Random.insideUnitSphere * yaricap;
        rasgeleYon += merkez;

        NavMeshHit carpan;
        Vector3 sonKonum = Vector3.zero;
        if (NavMesh.SamplePosition(rasgeleYon, out carpan, yaricap, NavMesh.AllAreas))
        {
            sonKonum = carpan.position;
        }

        return sonKonum;
    }
    public void HasarAl(float Hasar)
    {
        AnlikCan -= Hasar;
        AnimasyonDurumuDegistir(new HasarAlmaADurum());
        if (AnlikCan <= 0)
        {
            DavranisDurumuDegistir(new Olum());
        }
    }
    public void Olum()
    {
        Destroy(capsuleCollider);
        Destroy(agent);
        Destroy(animator);
        ToggleRagdoll(true);// ragdolu ac
        Destroy(gameObject, 20);
    }
    public void ToggleRagdoll(bool state)
    {
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = !state; // Ragdoll aktifse, kinematik olmamal�
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + MerkezOfeset, RadarYariCapi);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + MerkezOfeset, Saldiri1Menzil);
    }
}
