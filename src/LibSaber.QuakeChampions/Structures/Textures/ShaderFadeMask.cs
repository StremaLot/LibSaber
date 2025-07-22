using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures;

public class ShaderFadeMask
{

  [ScriptingProperty("R")]
  public bool R { get; set; }
  [ScriptingProperty("G")]
  public bool G { get; set; }
  [ScriptingProperty("B")]
  public bool B { get; set; }
  [ScriptingProperty("A")]
  public bool A { get; set; }

}
