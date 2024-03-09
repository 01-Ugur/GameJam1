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

    // Fare imlecini a�
    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; // Fare imlecini g�ster
    }
    private void Start()
    {
        UnlockCursor();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LockCursor();
        }
    }
}
