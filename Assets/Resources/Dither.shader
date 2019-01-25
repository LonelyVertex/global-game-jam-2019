Shader "Hidden/Custom/Dither"
{
    HLSLINCLUDE

#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

    TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
    int _Levels;

    static const float4x4 ditherTable = float4x4
        (
            0.058, 0.529, 0.176, 0.647,
            0.764, 0.294, 0.882, 0.411,
            0.235, 0.705, 0.117, 0.588,
            0.941, 0.470, 0.823, 0.352
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