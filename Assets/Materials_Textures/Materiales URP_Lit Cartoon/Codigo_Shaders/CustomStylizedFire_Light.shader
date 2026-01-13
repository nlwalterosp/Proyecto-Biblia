Shader "Custom/StylizedFire_URP6"
{
    Properties
    {
        _BaseMap("Base Map", 2D) = "white" {}
        _Color("Tint", Color) = (1,1,1,1)
        _DiffuseBoost("Diffuse Boost", Range(0,2)) = 1.0

        _FireColor("Fire Color", Color) = (1,0.5,0.1,1)
        _FireIntensity("Fire Intensity", Range(0,10)) = 1.5
        _FireRange("Fire Range", Range(0,5)) = 1.5
        _FirePos("Fire Position", Vector) = (0,0,0,0)
    }

        SubShader
        {
            Tags {
                "RenderPipeline" = "UniversalRenderPipeline"
                "Queue" = "Geometry"
            }

            Pass
            {
                Name "ForwardLit"
                Tags{ "LightMode" = "UniversalForward" }

                Blend One Zero
                ZWrite On

                HLSLPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma multi_compile _ _MAIN_LIGHT_SHADOWS

            // --- NUEVOS INCLUDES UNITY 6 ---
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 normalWS : TEXCOORD1;
                float3 worldPosWS : TEXCOORD2;
            };

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);

            float4 _Color;
            float _DiffuseBoost;
            float4 _FireColor;
            float _FireIntensity;
            float _FireRange;
            float4 _FirePos;

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.normalWS = TransformObjectToWorldNormal(IN.normalOS);
                OUT.worldPosWS = TransformObjectToWorld(IN.positionOS.xyz);
                OUT.uv = IN.uv;
                return OUT;
            }

            float4 frag(Varyings IN) : SV_Target
            {
                float4 tex = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv);
                float3 baseCol = tex.rgb * _Color.rgb;

                // luz principal lambert
                Light light = GetMainLight();
                float NdotL = saturate(dot(normalize(IN.normalWS), -light.direction));
                float3 lambert = baseCol * _DiffuseBoost * NdotL;

                // luz ambiente
                float3 ambient = baseCol * 0.3;

                // fuego local
                float dist = length(IN.worldPosWS - _FirePos.xyz);
                float falloff = saturate(1.0 - dist / _FireRange);
                float3 fire = _FireColor.rgb * _FireIntensity * falloff;

                return float4(ambient + lambert + fire, 1);
            }
            ENDHLSL
        }
        }
}
