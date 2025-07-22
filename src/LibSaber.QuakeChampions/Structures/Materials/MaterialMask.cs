using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Materials
{

  public class MaterialMask
  {

    [ScriptingProperty( "textureName" )]
    public string TextureName { get; set; }

    [ScriptingProperty( "tilingU" )]
    public float TilingU { get; set; }

    [ScriptingProperty( "tilingV" )]
    public float TilingV { get; set; }

    [ScriptingProperty( "uvSetIdx" )]
    public int UvSetIndex { get; set; }

  }

}
