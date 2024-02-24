
using UnityEngine;

public class GrayScale : MonoBehaviour
{
   
    public Shader _shader;
    public float intensityX,intensityY,intensityZ;
    float x,y,z;

    Material _material;
    // Start is called before the first frame update
    void Start()
    {
        _material= new Material(_shader);
    }
    
    private void Update() {
        if(intensityX>=100)
        {
            
            _material.SetFloat("_IntensityX",1);
        }
        else
        {
           _material.SetFloat("_IntensityX",0);
        }
        if(intensityY>=100)
        {
            _material.SetFloat("_IntensityY",1);
        }
        else{
            _material.SetFloat("_IntensityY",0);
        }
        if(intensityZ>=100)
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
    private void OnRenderImage(RenderTexture src, RenderTexture dest) {
        Graphics.Blit(src,dest,_material);
        
    }

   
}

