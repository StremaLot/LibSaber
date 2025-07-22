using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class ShaderAnimationBending
  {

    [ScriptingProperty( "amplitude" )]
    public Single Amplitude { get; set; }

    [ScriptingProperty( "centerOffsetY" )]
    public Single CenterOffsetY { get; set; }

    [ScriptingProperty( "speed" )]
    public Single Speed { get; set; }

  }

}
