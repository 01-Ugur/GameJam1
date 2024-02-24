Shader "Unlit/GScale"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _IntensityX ("IntensityX", Float) = 1.0
        _IntensityY ("IntensityY", Float) = 1.0
        _IntensityZ ("IntensityZ", Float) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _IntensityX;
            float _IntensityY;
            float _IntensityZ;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                  // sample the texture
                  fixed4 col = tex2D(_MainTex, i.uv);
                  float intensity = col.x * 0.299 + col.y * 0.587 + col.z * 0.114;
                  fixed4 bandw = fixed4((intensity+(_IntensityX*-intensity+_IntensityX*col.x)), (intensity+(_IntensityY*-intensity+_IntensityY*col.y)), (intensity+(_IntensityZ*-intensity+_IntensityZ*col.z)), col.w);
                  // // apply fog
                  // UNITY_APPLY_FOG(i.fogCoord, col);
                  return bandw;
            }
            ENDCG
        }
    }
}
