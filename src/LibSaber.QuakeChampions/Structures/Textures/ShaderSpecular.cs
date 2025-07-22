using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class ShaderSpecular
  {

    [ScriptingProperty( "blinn" )]
    public PhongBlinn Blinn { get; set; }

    [ScriptingProperty( "phong" )]
    public PhongBlinn Phong { get; set; }

    [ScriptingProperty( "tint" )]
    public SaberColor Tint { get; set; }

  }

}
