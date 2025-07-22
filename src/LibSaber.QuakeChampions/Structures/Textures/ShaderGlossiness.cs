using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class ShaderGlossiness
  {

    [ScriptingProperty( "bias" )]
    public Single Bias { get; set; }

    [ScriptingProperty( "scale" )]
    public Single Scale { get; set; }

  }

}
