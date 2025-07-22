using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class ShaderLayerMultipliers
  {

    [ScriptingProperty( "layerScaleAtten" )]
    public Single LayerScaleAttenuation { get; set; }

    [ScriptingProperty( "layerWaveAtten" )]
    public Single LayerWaveAttenuation { get; set; }

  }

}
