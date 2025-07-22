using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Materials
{

  public class MaterialHeightMapUvOverride
  {

    [ScriptingProperty( "enabled" )]
    public bool Enabled { get; set; }

    [ScriptingProperty( "tilingU" )]
    public float TilingU { get; set; }

    [ScriptingProperty( "tilingV" )]
    public float TilingV { get; set; }

    [ScriptingProperty( "uvSetIdx" )]
    public int UvSetIndex { get; set; }

  }

}
