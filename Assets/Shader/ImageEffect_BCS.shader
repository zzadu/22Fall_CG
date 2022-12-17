Shader "My/ImageEffect/BCS"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Brightness ("Brightness", Range(0, 1)) = 1
        _Saturation ("Saturation", Range(0, 1)) = 1
        _Contrast ("Contrast", Range(0, 1)) = 1
        
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _Brightness;
            float _Saturation;
            float _Contrast;

            float3 BCS(float3 color, float b, float s, float c)
            {
                float averageR = 0.5;
                float averageG = 0.5;
                float averageB = 0.5;

                float Luminance = float3(0.2125, 0.7154, 0.0721);

                float averageLumi = float3(averageR, averageG, averageB);
                float bright = color * b;
                float intensity = dot(bright, Luminance);
                float3 intensity3 = float3(intensity, intensity, intensity);

                float3 sat = lerp(intensity3, bright, s);

                float3 con = lerp(averageLumi, sat, c);

                return con;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                // just invert the colors
                col.rgb = BCS(col.rgb, _Brightness, _Saturation, _Contrast);
                return col;
            }
            ENDCG
        }
    }
}
