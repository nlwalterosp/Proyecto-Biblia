Shader "Custom/StylizedLambertTexture_Transparent"
{
    Properties
    {
        _BaseMap("Base Map", 2D) = "white" {}
        _Color("Color Tint", Color) = (1,1,1,1)
        _DiffuseBoost("Diffuse Boost", Range(0,2)) = 1.0
        _Cutoff("Alpha Cutoff", Range(0,1)) = 0.01
    }

        SubShader
        {
            Tags {
               "RenderPipeline" = "UniversalPipeline"
                "Queue" = "Transparent"
                "RenderType" = "Transparent"
            }

            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite On

            Pass
            {
                Name "Forward"
                Tags { "LightMode" = "UniversalForward" }

                HLSLPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
                #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

                struct Attributes
                {
                    float4 positionOS : POSITION;
                    float3 normalOS   : NORMAL;
                    float2 uv         : TEXCOORD0;
                };

                struct Varyings
                {
                    float4 positionHCS : SV_POSITION;
                    float2 uv          : TEXCOORD0;
                    float3 normalWS    : TEXCOORD1;
                };

                TEXTURE2D(_BaseMap);
                SAMPLER(sampler_BaseMap);

                float4 _Color;
                float _DiffuseBoost;
                float _Cutoff;

                Varyings vert(Attributes IN)
                {
                    Varyings OUT;
                    OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                    OUT.uv = IN.uv;
                    OUT.normalWS = TransformObjectToWorldNormal(IN.normalOS);
                    return OUT;
                }

                float4 frag(Varyings IN) : SV_Target
                {
                    float4 tex = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv);

                    if (tex.a < _Cutoff) discard;

                    float3 base = tex.rgb * _Color.rgb;
                    Light mainLight = GetMainLight();
                    float NdotL = saturate(dot(normalize(IN.normalWS), -mainLight.direction));
                    float3 lambert = base * NdotL * _DiffuseBoost;

                    float3 ambient = base * 0.3;

                    return float4(lambert + ambient, tex.a);
                }
                ENDHLSL
            }
        }
}
