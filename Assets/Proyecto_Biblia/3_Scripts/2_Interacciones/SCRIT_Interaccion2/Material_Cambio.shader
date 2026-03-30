Shader "Custom/Material_Cambio"
{
	Properties
	{
		_BaseMap("Base Map", 2D) = "white" {}
		_SecondMap("Second Map", 2D) = "white" {}
		_Blend("Blend", Range(0,1)) = 0
		_HeightBlend("Height Blend", Range(0,5)) = 1

		_Color("Color Tint", Color) = (1,1,1,1)
		_DiffuseBoost("Diffuse Boost", Range(0,2)) = 1.0
		_Cutoff("Alpha Cutoff", Range(0,1)) = 0.01
	}

		SubShader
{
	Tags { "RenderPipeline" = "UniversalPipeline" "Queue" = "Geometry" }

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
			float2 uv : TEXCOORD0;
			float3 normalWS : TEXCOORD1;
			float3 positionWS : TEXCOORD2;
		};

		TEXTURE2D(_BaseMap);
		TEXTURE2D(_SecondMap);

		SAMPLER(sampler_BaseMap);
		SAMPLER(sampler_SecondMap);

		float _Blend;
		float _HeightBlend;
		float4 _Color;
		float _DiffuseBoost;

		Varyings vert(Attributes IN)
		{
			Varyings OUT;
			OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
			OUT.uv = IN.uv;
			OUT.normalWS = TransformObjectToWorldNormal(IN.normalOS);
			OUT.positionWS = TransformObjectToWorld(IN.positionOS.xyz);
			return OUT;
		}

		float4 frag(Varyings IN) : SV_Target
		{
			float3 normal = normalize(IN.normalWS);

			float heightMask = saturate(IN.positionWS.y * _HeightBlend);
			float blendValue = saturate(_Blend + heightMask);

			float4 tex1 = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv);
			float4 tex2 = SAMPLE_TEXTURE2D(_SecondMap, sampler_SecondMap, IN.uv);

			float4 tex = lerp(tex1, tex2, blendValue);

			float3 baseTex = tex.rgb * _Color.rgb;

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
