using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSaber.QuakeChampions.Serialization.Scripting;

namespace LibSaber.QuakeChampions.Structures.Materials;

public class MaterialExtraUVData
{

  [ScriptingProperty("uvSetIdx")]
  public int UvSetIdx { get; set; }

}
