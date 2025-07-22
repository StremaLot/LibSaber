using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Textures;

public class ShaderOcclusionMask
{

  [ScriptingProperty("vertex_scale")]
  public float VertexScale { get; set; }

  [ScriptingProperty("tex_scale")]
  public float TexScale { get; set; }

}
