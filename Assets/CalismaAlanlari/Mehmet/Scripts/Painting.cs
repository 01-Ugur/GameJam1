using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
   //public Renderer [] renderers;
  // public string materialPath = "Assets/Resources/Red.mat"; // Materyal dosyasının yolunu belirtin
    //public int count; // Count değişkeni

    private Material[] myMaterials; // Materyal dosyasını saklamak için değişken
    GameManager gameManager;
    GameObject myPrefab;
    public Camera mainCamera;
    Color cameraBackgroundColor;
    


    
   float maxIntensity=99;
   void Start(){
     // myMaterial = Resources.Load<Material>(materialPath);

    
          cameraBackgroundColor=mainCamera.backgroundColor;
          gameManager= FindObjectOfType<GameManager>();
          myMaterials=new Material[5];
          for (int i = 0; i < 5; i++)
          {
            DontThePaint(i);
          }
       
      




   }
   public void DoThePaint( int index)
   {
      
       
         if(gameManager.intensity[index]>=maxIntensity)
        {
          switch (index)
          {
            case 0:
          
            myMaterials[index] = Resources.Load<Material>("RedM");
            myMaterials[index].SetFloat("_Blend",(gameManager.intensity[index]/maxIntensity));
            break;
            case 1:
            
        myMaterials[index] =Resources.Load<Material>("GreenM");
            myMaterials[index].SetFloat("_Blend",(gameManager.intensity[index]/maxIntensity));
            break;
            case 2:
           
        myMaterials[index] = Resources.Load<Material>("BlueM");
            myMaterials[index].SetFloat("_Blend",(gameManager.intensity[index]/maxIntensity));
            mainCamera.backgroundColor=new Color(0.529f, 0.808f, 0.922f);

            break;
            case 3:
           
        myMaterials[index] = Resources.Load<Material>("BrownM");
            myMaterials[index].SetFloat("_Blend",(gameManager.intensity[index]/maxIntensity));
            if(gameManager.intensity[index]>maxIntensity)
            {
              mainCamera.GetComponent<GrayScale>().RemoweGrayFilter();
            }
            
            break;
            case 4:
           
        myMaterials[index] = Resources.Load<Material>("RockM");
            myMaterials[index].SetFloat("_Blend",(gameManager.intensity[index]/maxIntensity));
            break;

            default: 
            Debug.Log("index yanlış ");
            break;
            
            

          }
        }
        
        
        
    
   }
   public void DontThePaint(int index){
    if(gameManager.intensity[index]<maxIntensity)
        {
          switch (index)
          {
            case 0:
            
        myMaterials[index] = Resources.Load<Material>("RedM");
            myMaterials[index].SetFloat("_Blend",(0));
            break;
            case 1:
            
        myMaterials[index] =  Resources.Load<Material>("GreenM");
            myMaterials[index].SetFloat("_Blend",(0));
            break;
            case 2:
            
        myMaterials[index] =Resources.Load<Material>("BlueM");
            myMaterials[index].SetFloat("_Blend",(0));
            mainCamera.backgroundColor=cameraBackgroundColor;
            break;
             case 3:
           
        myMaterials[index] = Resources.Load<Material>("BrownM");
            myMaterials[index].SetFloat("_Blend",(0));
            break;
            case 4:
           
        myMaterials[index] = Resources.Load<Material>("RockM");
            myMaterials[index].SetFloat("_Blend",(0));
            break;
            default: 
            Debug.Log("index yanlış ");
            break;
            
            

          }
        }
   }

}
