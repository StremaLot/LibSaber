using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Materials
{

  public class MaterialUpVector
  {

    [ScriptingProperty( "angle" )]
    public float Angle { get; set; }

    [ScriptingProperty( "enabled" )]
    public bool Enabled { get; set; }

    [ScriptingProperty( "falloff" )]
    public float Falloff { get; set; }

  }

}
