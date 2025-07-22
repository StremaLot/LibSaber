using LibSaber.IO;
using LibSaber.Serialization;
using LibSaber.QuakeChampions.Structures;

namespace LibSaber.QuakeChampions.Serialization;

public class objGEOM_VBUFFER_MAPPINGSerializer : QCSerializerBase<objGEOM_VBUFFER_MAPPING>
{

  public override objGEOM_VBUFFER_MAPPING Deserialize(NativeReader reader, ISerializationContext context)
  {
    var propertyCount = reader.ReadInt32();
    var propertyFlags = (PropertyFlags)reader.ReadByte();

    var mapping = new objGEOM_VBUFFER_MAPPING();

    if (propertyFlags.HasFlag(PropertyFlags.StreamToVBuffer))
      mapping.streamToVBuffer = Serializer<List<objGEOM_STREAM_TO_VBUFFER>>.Deserialize(reader, context);
    if (propertyFlags.HasFlag(PropertyFlags.StreamToVBuffer))
      mapping.vBufferInfo = Serializer<List<objGEOM_VBUFFER_INFO>>.Deserialize(reader, context);

    return mapping;
  }

  enum PropertyFlags : byte
  {
    StreamToVBuffer = 1 << 0,
    VBufferInfo = 1 << 1
  }

}
