using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Materials
{

  public class MaterialReliefNormalMaps
  {

    [ScriptingProperty( "macro" )]
    public MaterialNormalMap Macro { get; set; }

    [ScriptingProperty( "micro1" )]
    public MaterialNormalMap Micro1 { get; set; }

    [ScriptingProperty( "micro2" )]
    public MaterialNormalMap Micro2 { get; set; }

  }

}
