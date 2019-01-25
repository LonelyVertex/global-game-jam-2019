Shader "Hidden/Custom/Dither"
{
    HLSLINCLUDE

#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

    TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
    int _Levels;

    static const float4x4 ditherTable = float4x4
        (
            0, 8, 2, 10,
            12, 4, 14, 6,
            3, 11, 1, 9,
            15, 7, 13, 5
        );

    float dither(float color, uint2 pixelCoord) {
        float closestColor = (color < 0.5) ? 0 : 1;
        float secondClosestColor = 1 - closestColor;
        float d = ditherTable[pixelCoord.x % 4][pixelCoord.y % 4];
        float distance = abs(closestColor - color);
        return (distance < d) ? closestColor : secondClosestColor;
    }

    float4 Frag(VaryingsDefault i) : SV_Target
    {
        float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);

        color.rgb = saturate(dot(color.rgb, float3(0.2126729, 0.7151522, 0.0721750)));
        uint2 pixelCoord = i.texcoord * _ScreenParams.xy;
        color.rgb = dither(color.r, pixelCoord);
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