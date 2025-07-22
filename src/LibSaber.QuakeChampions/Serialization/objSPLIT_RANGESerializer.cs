using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSaber.IO;
using LibSaber.Serialization;
using LibSaber.QuakeChampions.Structures;

namespace LibSaber.QuakeChampions.Serialization;

public class objSPLIT_RANGESerializer : QCSerializerBase<List<objSPLIT_RANGE>>
{

  public override List<objSPLIT_RANGE> Deserialize(NativeReader reader, ISerializationContext context)
  {
    var objectCount = reader.ReadInt32();
    var propertyCount = reader.ReadInt32();

    var ranges = new List<objSPLIT_RANGE>();
    for (var i = 0; i < objectCount; i++)
      ranges.Add(new objSPLIT_RANGE());

    if (propertyCount > 0)
      ReadStartIndex(reader, ranges);
    if (propertyCount > 1)
      ReadNumSplits(reader, ranges);

    return ranges;
  }

  private void ReadStartIndex(NativeReader reader, List<objSPLIT_RANGE> ranges)
  {
    if (reader.ReadByte() == 0)
      return;

    foreach (var range in ranges)
      range.startIndex = reader.ReadInt16();
  }

  private void ReadNumSplits(NativeReader reader, List<objSPLIT_RANGE> ranges)
  {
    if (reader.ReadByte() == 0)
      return;

    foreach (var range in ranges)
      range.numSplits = reader.ReadInt16();
  }

}
