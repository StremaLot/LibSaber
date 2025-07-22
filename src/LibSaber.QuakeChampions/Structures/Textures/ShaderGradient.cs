using LibSaber.QuakeChampions.Serialization;
using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class ShaderGradient : ITextureNameProvider
  {

    [ScriptingProperty( "speed" )]
    public Single Speed { get; set; }

    [ScriptingProperty( "tex" )]
    public String Texture { get; set; }

    [ScriptingProperty( "texPhaseOffset" )]
    public String TexturePhaseOffset { get; set; }

    public IEnumerable<string> GetTextureNames()
    {
      if ( !string.IsNullOrWhiteSpace( Texture ) )
        yield return Texture;
    }
  }

}
