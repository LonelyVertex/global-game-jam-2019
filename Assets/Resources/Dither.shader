Shader "Hidden/Custom/Dither"
{
    HLSLINCLUDE

#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

    TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
    int _Levels;

    static const float4x4 ditherTable = float4x4
        (
            -4.0, 0.0, -3.0, 1.0,
            2.0, -2.0, 3.0, -1.0,
            -3.0, 1.0, -4.0, 0.0,
            3.0, -1.0, 2.0, -2.0
        );


    float4 Frag(VaryingsDefault i) : SV_Target
    {
        float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);

        color.rgb = dot(color.rgb, float3(0.2126729, 0.7151522, 0.0721750));
        uint2 pixelCoord = i.texcoord * _ScreenParams.xy;
        color.rgb *= ditherTable[pixelCoord.x % 4][pixelCoord.y % 4];
        return color;
    }

        ENDHLSL

        SubShader
    {
        Cull Off ZWrite Off ZTest Always

            Pass
        {
            HLSLPROGRAM

                #pragma vertex VertDefault
                #pragma fragment Frag

            ENDHLSL
        }
    }
}