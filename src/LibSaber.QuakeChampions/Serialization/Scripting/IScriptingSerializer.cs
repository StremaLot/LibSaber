namespace LibSaber.QuakeChampions.Serialization.Scripting
{

  public interface IScriptingSerializer
  {

    dynamic Deserialize( Stream stream );

  }

  public interface IConfigurationSerializer<T> : IScriptingSerializer
    where T : class, new()
  {

    T Deserialize( Stream stream );

  }

}
