using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Materials;

public class MaterialParallax
{

  [ScriptingProperty("baseLayerParallax")]
  public MaterialParallaxLayer BaseLayerParallax { get; set; }

  [ScriptingProperty("secondLayerParallax")]
  public MaterialParallaxLayer SecondLayerParallax { get; set; }

  [ScriptingProperty("parallaxSettings")]
  public ParallaxSettings ParallaxSettings { get; set; }



}

public class MaterialParallaxLayer
{

  [ScriptingProperty("colorSetIdx")]
  public int ColorSetIdx { get; set; }

  [ScriptingProperty("textureName")]
  public string TextureName { get; set; }

  [ScriptingProperty("tilingU")]
  public float TilingU { get; set; }

  [ScriptingProperty("tilingV")]
  public float TilingV { get; set; }

  [ScriptingProperty("uvSetIdx")]
  public int UvSetIdx { get; set; }

}

public class ParallaxSettings
{

  [ScriptingProperty("enableSecondParallaxLayer")]
  public int EnableSecondParallaxLayer { get; set; }

  [ScriptingProperty("flatten")]
  public ParallaxFlatten Flatten { get; set; }

  [ScriptingProperty("overrideSecondParallaxTexture")]
  public int OverrideSecondParallaxTexture { get; set; }

}

public class ParallaxFlatten
{

  [ScriptingProperty("colorSetIdx")]
  public int ColorSetIdx { get; set; }

}