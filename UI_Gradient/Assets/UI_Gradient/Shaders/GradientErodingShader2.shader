Shader "Custom/GradientErodingShader2"
{
    Properties
    {
        _StartColor ("Start Color", Color) = (1,0,0,1)
        _EndColor ("End Color", Color) = (0,0,1,1)
        _ErodingTime ("Eroding Time", Float) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }
        LOD 200

        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode"="UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float2 uv : TEXCOORD0;
                float4 positionHCS : SV_POSITION;
            };

            CBUFFER_START(UnityPerMaterial)
                half4 _StartColor;
                half4 _EndColor;
                float _ErodingTime;
            CBUFFER_END

            Varyings vert(Attributes input)
            {
                Varyings output;
                output.positionHCS = TransformObjectToHClip(input.positionOS);
                output.uv = input.uv;
                return output;
            }

            half4 frag (Varyings input) : SV_Target
            {
                float lerpValue = frac(_Time.y / _ErodingTime);
                half4 gradientColor = lerp(_StartColor, _EndColor, input.uv.x);
                half4 color = lerp(gradientColor, _EndColor, lerpValue);
                return color;
            }
            ENDHLSL
        }
    }
    FallBack "Universal Render Pipeline/Lit"
}