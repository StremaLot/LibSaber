using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures;

public class ShaderColorization
{

  [ScriptingProperty("color")]
  public SaberColor Color { get; set; }

  [ScriptingProperty("use")]
  public bool Use { get; set; }

  [ScriptingProperty("useTranslucencyAsMask")]
  public bool UseTranslucencyAsMask { get; set; }

  [ScriptingProperty("amount")]
  public float Amount { get; set; }

}
