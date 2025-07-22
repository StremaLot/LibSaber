using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{
    public class PhongBlinn
  {

    [ScriptingProperty( "multiplier" )]
    public Single Multiplier { get; set; }

    [ScriptingProperty( "normalScale" )]
    public Single NormalScale { get; set; }

    [ScriptingProperty( "power" )]
    public Single Power { get; set; }

    [ScriptingProperty( "spotDepth" )]
    public Single SpotDepth { get; set; }

  }

}
