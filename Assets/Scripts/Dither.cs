using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(DitherRenderer), PostProcessEvent.AfterStack, "Custom/Dither")]
public sealed class Dither : PostProcessEffectSettings
{
    [Range(0, 255), Tooltip("Levels")]
    public IntParameter levels = new IntParameter { value = 100 };
}

public sealed class DitherRenderer : PostProcessEffectRenderer<Dither>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Dither"));
        sheet.properties.SetFloat("_Levels", settings.levels);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}