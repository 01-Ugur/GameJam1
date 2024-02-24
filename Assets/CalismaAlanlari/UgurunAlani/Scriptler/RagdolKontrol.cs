using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdolKontrol : MonoBehaviour
{
    public Rigidbody[] rigidbodies;
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        ToggleRagdoll(false);
    }
    public void ToggleRagdoll(bool state)
    {
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = !state; // Ragdoll aktifse, kinematik olmamalý
        }
    }
}
