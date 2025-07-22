using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class ShaderDoubleSideLighting
  {

    [ScriptingProperty( "backLightTint" )]
    public SaberColor BackLightTint { get; set; }

    [ScriptingProperty( "use" )]
    public Boolean Use { get; set; }

    [ScriptingProperty( "viewDependence" )]
    public Single ViewDependence { get; set; }

  }

}
