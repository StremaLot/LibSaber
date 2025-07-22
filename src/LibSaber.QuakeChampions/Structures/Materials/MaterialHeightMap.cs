using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Materials
{

  public class MaterialHeightMap
  {

    [ScriptingProperty( "colorSetIdx" )]
    public int ColorSetIndex { get; set; }

    [ScriptingProperty( "invert" )]
    public bool Invert { get; set; }

  }

}
