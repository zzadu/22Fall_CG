Shader "My/Discontinuous"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        cull back
        CGPROGRAM
        #pragma surface surf Toon noambient
        
        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };
        
        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }

        float4 LightingToon(SurfaceOutput o, float3 lightDir, float atten)
        {
            float ndot = dot(o.Normal, lightDir) * 0.5 + 0.5;

            ndot = ndot * 4;
            ndot = ceil(ndot)/4;
            
            return ndot;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
