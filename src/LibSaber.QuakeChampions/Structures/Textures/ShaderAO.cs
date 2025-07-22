using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class ShaderAO
  {

    [ScriptingProperty( "intensity" )]
    public Single Intensity { get; set; }

    [ScriptingProperty( "occlusionAmount" )]
    public Single OcclusionAmount { get; set; }

    [ScriptingProperty( "vertexAmbientOcclusion" )]
    public Boolean VertexAmbientOcclusion { get; set; }

  }

}
