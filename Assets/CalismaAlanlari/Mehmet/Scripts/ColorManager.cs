using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
   public int index;
   int maxIntensity=99;
   Painting painting;
   GameManager gameManager;
   bool isPainted=false;
   private void Start() {
      painting= FindObjectOfType<Painting>().GetComponent<Painting>();
      gameManager= FindObjectOfType<GameManager>();   }

   private void Update() {
      if(gameManager.intensity[index]>maxIntensity&& !isPainted)
      {
         painting.DoThePaint(index);
         isPainted=true;
      }
      else if(gameManager.intensity[index]<=maxIntensity&&isPainted)
      {
         painting.DontThePaint(index);
         isPainted=false;
      }

      
    
   }
}
