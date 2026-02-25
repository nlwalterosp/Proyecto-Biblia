Shader "Custom/Water_Cartoon_Lite"
{
    Properties
    {
        _WaterColor("Water Color", Color) = (0.2, 0.6, 0.9, 1)
        _MainTex("Noise Texture", 2D) = "white" {}
        _Speed("Speed", Float) = 0.1
        _Tiling("Tiling", Float) = 1
    }

        SubShader
        {
            Tags { "RenderType" = "Opaque" "Queue" = "Geometry" }
            LOD 100

            Pass
            {
                HLSLPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

                struct Attributes
                {
                    float4 positionOS : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct Varyings
                {
                    float4 positionHCS : SV_POSITION;
                    float2 uv : TEXCOORD0;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float4 _WaterColor;
                float _Speed;
                float _Tiling;

                Varyings vert(Attributes v)
                {
                    Varyings o;
                    o.positionHCS = TransformObjectToHClip(v.positionOS.xyz);
                    o.uv = v.uv * _Tiling;
                    return o;
                }

                half4 frag(Varyings i) : SV_Target
                {
                    float2 uv = i.uv;
                    uv.x += _Time.y * _Speed;

                    half noise = tex2D(_MainTex, uv).r;
                    half4 col = _WaterColor * noise;

                    return col;
                }
                ENDHLSL
            }
        }
}