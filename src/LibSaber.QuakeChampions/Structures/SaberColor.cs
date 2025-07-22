using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures
{

  public class SaberColor
  {

    #region Properties

    [ScriptingProperty( "R", arrayIndex: 0 )]
    public float R { get; set; }

    [ScriptingProperty( "G", arrayIndex: 1 )]
    public float G { get; set; }

    [ScriptingProperty( "B", arrayIndex: 2 )]
    public float B { get; set; }

    [ScriptingProperty( "A", arrayIndex: 3 )]
    public float A { get; set; }

    #endregion

  }

}
