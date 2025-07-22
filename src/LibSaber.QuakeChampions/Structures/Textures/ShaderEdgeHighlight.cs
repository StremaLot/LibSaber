using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures;

public class ShaderEdgeHighlight
{

  [ScriptingProperty("enabled")]
  public Boolean Enabled { get; set; }

  [ScriptingProperty("intensity")]
  public Single Intensity { get; set; }

  [ScriptingProperty("power")]
  public Single Power { get; set; }

  [ScriptingProperty("blendMode")]
  public string BlendMode { get; set; }

}
