using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class ShaderParallax
  {

    [ScriptingProperty( "scale" )]
    public Single Scale { get; set; }

    [ScriptingProperty( "shadow" )]
    public Boolean Shadow { get; set; }

  }

}
