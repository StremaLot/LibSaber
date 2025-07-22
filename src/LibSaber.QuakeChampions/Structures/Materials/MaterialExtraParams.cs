using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Materials
{

  public class MaterialExtraParams
  {

    [ScriptingProperty( "reliefNormalmaps" )]
    public MaterialReliefNormalMaps ReliefNormalMaps { get; set; }

    [ScriptingProperty( "auxiliaryTextures" )]
    public MaterialAuxiliaryTextures AuxiliaryTextures { get; set; }

    [ScriptingProperty( "transparency" )]
    public MaterialTransparency Transparency { get; set; }

    [ScriptingProperty( "extraVertexColorData" )]
    public MaterialExtraVertexColorData ExtraVertexColorData { get; set; }

    [ScriptingProperty("parallax")]
    public MaterialParallax Parallax { get; set; }

    [ScriptingProperty("extraUVData")]
    public MaterialExtraUVData ExtraUVData { get; set; }

  }

}
