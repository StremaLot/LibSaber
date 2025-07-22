using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class AlphaKillSmooth
  {

    [ScriptingProperty( "enable" )]
    public Boolean Enable { get; set; }

    [ScriptingProperty( "smoothness" )]
    public Single Smoothness { get; set; }

  }

}
