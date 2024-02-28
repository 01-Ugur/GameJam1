
using UnityEngine;

public class GrayScale : MonoBehaviour
{
   
    public Shader _shader;
    public float intensityX,intensityY,intensityZ;
    float x,y,z;
    int maxIntensity=99;

    Material _material;
    // Start is called before the first frame update
    void Start()
    {
        _material= new Material(_shader);
    }
    
    private void Update() {
       if(intensityX>=maxIntensity)
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
        Debug.Log("Cong");
    }
    public void RemoweGrayFilter()
    {
        intensityX=maxIntensity+1;
        intensityY=maxIntensity+1;
        intensityZ=maxIntensity+1;
        
    }
    private void OnRenderImage(RenderTexture src, RenderTexture dest) {
        Graphics.Blit(src,dest,_material);
        
    }

   
}

