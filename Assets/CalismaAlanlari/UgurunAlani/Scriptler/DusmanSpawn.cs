using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DusmanSpawn : MonoBehaviour
{
    public float YariCap=1;
    public int DusmanSayisi;
    public LayerMask TerrainKatmani;
    public GameObject Dusmanlar;
    public GameObject DusmanPrefabi;
    public Mesh Gimocizimi;
    void Start()
    {
        DusmanlariSpawnEt();
    }
    public void DusmanlariSpawnEt()
    {
        for (int i = 0; i < DusmanSayisi; i++)
        {
            GameObject Dusman = Instantiate(DusmanPrefabi);

            Vector2 yon = new Vector2(Random.Range(-1f,1f),Random.Range(-1,1f)).normalized;
            float YaricapUzakligi = Random.Range(-(YariCap/2), YariCap/2);
            Vector3 rayAtmaOfset = new Vector3(yon.x*YaricapUzakligi,transform.position.y,yon.y*YaricapUzakligi);
            RaycastHit raycastHit;
            if (Physics.Raycast(transform.position+rayAtmaOfset,Vector3.down,out raycastHit,TerrainKatmani))
            {
                Vector3 spawnKonumu = FindClosestNavMeshPoint(raycastHit.point, 10f);
                Dusman.transform.position = spawnKonumu;
            }
        }
    }
    public Vector3 FindClosestNavMeshPoint(Vector3 searchPoint,float searchRadius)
    {
        NavMeshHit closestHit;

        if (NavMesh.SamplePosition(searchPoint, out closestHit, searchRadius, NavMesh.AllAreas))
        {
            return closestHit.position; // En yakýn noktayý döndür
        }
        else
        {
            return searchPoint; // Eðer bir nokta bulunamazsa, null döndür
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawMesh(Gimocizimi,transform.position,Quaternion.identity,new(YariCap,1,YariCap));
    }
}
