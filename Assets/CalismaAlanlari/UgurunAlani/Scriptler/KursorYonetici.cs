using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KursorYonetici : MonoBehaviour
{
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // Fare imlecini gizle
    }

    // Fare imlecini aç
    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; // Fare imlecini göster
    }
    private void Start()
    {
        UnlockCursor();
    }
}
