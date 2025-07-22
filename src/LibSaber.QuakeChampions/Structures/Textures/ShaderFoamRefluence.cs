using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class ShaderFoamRefluence
  {

    [ScriptingProperty( "amplitude" )]
    public Single Amplitude { get; set; }

    [ScriptingProperty( "freq" )]
    public Single Frequency { get; set; }

    [ScriptingProperty( "posStart" )]
    public Single PositionStart { get; set; }

  }

}
