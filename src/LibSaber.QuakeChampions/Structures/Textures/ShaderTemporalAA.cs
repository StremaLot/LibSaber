using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures;

public class ShaderTemporalAA
{
  [ScriptingProperty("affectTransparencyMask")]
  public bool AffectTransparencyMask { get; set; }
}
