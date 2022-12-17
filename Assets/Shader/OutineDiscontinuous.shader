Shader "My/OutineDiscontinuous"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        cull front
        CGPROGRAM
        #pragma surface surf NoLight vertex:vert noshadow noambient

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        void vert(inout appdata_full v)
        {
            v.vertex.xyz += v.normal.xyz * 0.05;
        }

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }

        float4 LightingNoLight(SurfaceOutput s, float3 lightDir, float att)
        {
            return float4(0, 0, 0, 1);
        }
        ENDCG
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
