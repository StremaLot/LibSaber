using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class ShaderAnisoSpecExtra
  {

    [ScriptingProperty("anisotropy")]
    public Single Anisotropy { get; set; }

    [ScriptingProperty( "intensity" )]
    public Single Intensity { get; set; }

    [ScriptingProperty( "shift" )]
    public Single Shift { get; set; }

  }

}
