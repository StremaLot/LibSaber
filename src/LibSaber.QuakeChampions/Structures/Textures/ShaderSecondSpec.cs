using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures;

public class ShaderSecondSpec
{

  [ScriptingProperty("enabled")]
  public bool Enabled { get; set; }

  [ScriptingProperty("metallicTint")]
  public SaberColor MetallicTint { get; set; }

  [ScriptingProperty("metalness")]
  public ShaderGlossiness Metalness { get; set; }

  [ScriptingProperty("roughness")]
  public ShaderGlossiness Roughness { get; set; }

}
