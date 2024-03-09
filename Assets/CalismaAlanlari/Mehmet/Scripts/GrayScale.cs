
using UnityEngine;

public class GrayScale : MonoBehaviour
{
   
    public Shader _shader;
    public float intensityX,intensityY,intensityZ;
    float brownInstensity=0;
    float x,y,z;
    int maxIntensity=99;

    Material _material;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _material= new Material(_shader);
        gameManager=FindObjectOfType<GameManager>();
        _material.SetFloat("_IntensityX",0);
        _material.SetFloat("_IntensityY",0);
        _material.SetFloat("_IntensityZ",0);

    }
    
    private void Update() {
<<<<<<< Updated upstream
       if(intensityX>=maxIntensity)
=======
        if(gameManager.intensity[3]>99)
        CloseCameraGrayScale();

        /*if(intensityX>=100)
>>>>>>> Stashed changes
        {
            
            _material.SetFloat("_IntensityX",1);
        }
        else
        {
           _material.SetFloat("_IntensityX",0);
        }
        if(intensityY>=maxIntensity)
        {
            _material.SetFloat("_IntensityY",1);
        }
        else{
            _material.SetFloat("_IntensityY",0);
        }
        if(intensityZ>=maxIntensity)
        {
            _material.SetFloat("_IntensityZ",1);
        }
        else
        {
            _material.SetFloat("_IntensityZ",0);
        }
        if(intensityX>99&&intensityY>99&&intensityZ>99)
        Debug.Log("Cong");*/
        
    }
<<<<<<< Updated upstream
    public void RemoweGrayFilter()
    {
        intensityX=maxIntensity+1;
        intensityY=maxIntensity+1;
        intensityZ=maxIntensity+1;
        
    }
=======

    public void CloseCameraGrayScale()
    {   
        _material.SetFloat("_IntensityX",1);
        _material.SetFloat("_IntensityY",1);
        _material.SetFloat("_IntensityZ",1);
    }
    
>>>>>>> Stashed changes
    private void OnRenderImage(RenderTexture src, RenderTexture dest) {
        Graphics.Blit(src,dest,_material);
        
    }

   
}

