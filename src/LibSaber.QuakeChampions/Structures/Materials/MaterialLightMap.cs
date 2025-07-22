using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Materials
{

  public class MaterialLightMap
  {

    [ScriptingProperty( "source" )]
    public string Source { get; set; }

    [ScriptingProperty( "texName" )]
    public string TextureName { get; set; }

    [ScriptingProperty( "uvSetIdx" )]
    public int UvSetIndex { get; set; }

    [ScriptingProperty( "tangent" )]
    public MaterialTangent Tangent { get; set; }

  }

}
