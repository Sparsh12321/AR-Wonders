Shader "Custom/NewSurfaceShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ClipY ("Clip Y Position", Float) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        CGPROGRAM
        #pragma surface surf Standard clip(_ClipY - worldPos.y)

        sampler2D _MainTex;
        struct Input {
            float2 uv_MainTex;
            float3 worldPos;
        };
        float _ClipY;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
        }
        ENDCG
    }
}
