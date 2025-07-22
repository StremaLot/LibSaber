using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class ShaderCarPaint
  {

    [ScriptingProperty( "glossiness" )]
    public ShaderGlossiness Glossiness { get; set; }

    [ScriptingProperty( "metalness" )]
    public SaberColor Metalness { get; set; }

  }

}
