using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class ShaderFoamDistribuance
  {

    [ScriptingProperty( "amplitude" )]
    public Single Amplitude { get; set; }

    [ScriptingProperty( "freq" )]
    public Single Frequency { get; set; }

    [ScriptingProperty( "speed" )]
    public Single Speed { get; set; }

  }

}
