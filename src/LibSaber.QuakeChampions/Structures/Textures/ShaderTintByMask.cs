using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class ShaderTintByMask
  {

    [ScriptingProperty( "albedo" )]
    public SaberColor Albedo { get; set; }

    [ScriptingProperty( "carpaintMetallness" )]
    public SaberColor CarpaintMetallness { get; set; }

    [ScriptingProperty( "maskFromAlbedoAlpha" )]
    public Boolean MaskFromAlbedoAlpha { get; set; }

    [ScriptingProperty( "metallness" )]
    public SaberColor Metallness { get; set; }

  }

}
