using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
   public int index;

   private void Update() {
    FindObjectOfType<Painting>().DoThePaint(index);
   }
}
