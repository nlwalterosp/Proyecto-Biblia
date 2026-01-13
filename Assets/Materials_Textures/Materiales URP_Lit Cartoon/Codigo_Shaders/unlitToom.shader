Shader "Custom/StylizedLambertTexture"
{
    Properties
    {
        _BaseMap("Base Map", 2D) = "white" {}
        _Color("Color Tint", Color) = (1,1,1,1)
        _DiffuseBoost("Diffuse Boost", Range(0,2)) = 1.0
    }

        SubShader
        {
            Tags { "RenderPipeline" = "UniversalPipeline" "Queue" = "Opaque" }

            Pass
            {
                Name "Forward"
                Tags { "LightMode" = "UniversalForward" }

                HLSLPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma multi_compile_fog
                #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
                #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
                #pragma multi_compile _ _ADDITIONAL_LIGHT_SHADOWS

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
                    float3 normal = normalize(IN.normalWS);

                    float3 baseTex = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv).rgb * _Color.rgb;

                    // luz principal
                    Light mainLight = GetMainLight();
                    float NdotL = saturate(dot(normal, -mainLight.direction));
                    float3 lambert = baseTex * NdotL * _DiffuseBoost;

                    // luz ambiente
                    float3 ambient = baseTex * 0.3;

                    return float4(lambert + ambient, 1.0);
                }
                ENDHLSL
            }
        }
}
