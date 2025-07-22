using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class ShaderDiffuse
  {

    [ScriptingProperty( "multiplier" )]
    public Single Multiplier { get; set; }

    [ScriptingProperty( "shadowAmbient" )]
    public Single ShadowAmbient { get; set; }

  }

}
