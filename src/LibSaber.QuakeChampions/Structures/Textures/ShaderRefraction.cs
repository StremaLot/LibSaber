using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class ShaderRefraction
  {

    [ScriptingProperty( "opacityBias" )]
    public Single OpacityBias { get; set; }

    [ScriptingProperty( "opacityDepth" )]
    public Single OpacityDepth { get; set; }

    [ScriptingProperty( "tintBias" )]
    public Single TintBias { get; set; }

    [ScriptingProperty( "tintDepth" )]
    public Single TintDepth { get; set; }

    [ScriptingProperty("blendMode")]
    public string BlendMode { get; set; }

  }

}
