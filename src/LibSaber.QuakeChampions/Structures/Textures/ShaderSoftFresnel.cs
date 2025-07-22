using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class ShaderSoftFresnel
  {

    [ScriptingProperty( "edge" )]
    public Boolean Edge { get; set; }

    [ScriptingProperty( "edgeHighlightIntensity" )]
    public Single EdgeHighlightIntensity { get; set; }

    [ScriptingProperty( "enabled" )]
    public Boolean Enabled { get; set; }

    [ScriptingProperty( "power" )]
    public Single Power { get; set; }

  }

}
