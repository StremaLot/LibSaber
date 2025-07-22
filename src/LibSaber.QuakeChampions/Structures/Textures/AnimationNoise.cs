using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class AnimationNoise
  {

    [ScriptingProperty( "amplitude" )]
    public Single Amplitude { get; set; }

    [ScriptingProperty( "speed" )]
    public Single Speed { get; set; }

  }

}
