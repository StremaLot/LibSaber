using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures
{

  public class ShaderEyes
  {

    [ScriptingProperty( "glossiness" )]
    public Single Glossiness { get; set; }

    [ScriptingProperty( "intensity" )]
    public Single Intensity { get; set; }

    [ScriptingProperty( "nmScale" )]
    public Single NormalMapScale { get; set; }

    [ScriptingProperty( "x" )]
    public Single X { get; set; }

    [ScriptingProperty( "y" )]
    public Single Y { get; set; }

  }

}
