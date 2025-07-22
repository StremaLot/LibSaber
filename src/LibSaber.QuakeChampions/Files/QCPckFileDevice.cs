using System.IO.Compression;
using LibSaber.FileSystem;
using LibSaber.QuakeChampions.Structures.Resources;
using static LibSaber.QuakeChampions.Structures.Resources.fioZIP_CACHE_FILE;

namespace LibSaber.QuakeChampions.Files;

public class QCPckFileDevice : FileSystemDevice
{

  #region Data Members

  private readonly string _filePath;
  private readonly fioZIP_FILE _zipFile;

  #endregion

  #region Constructor

  public QCPckFileDevice(string filePath)
  {
    _filePath = filePath;
    _zipFile = fioZIP_FILE.Open(filePath);
  }

  #endregion

  #region Overrides

  public override Stream GetStream(IFileSystemNode node)
  {
    var smNode = node as QCFileSystemNode;
    ASSERT(smNode != null, "Node is not an QCFileSystemNode.");

    return _zipFile.GetFileStream(smNode.Entry);
  }

  protected override IFileSystemNode OnInitializing()
      => InitNodes();

  protected override void OnDisposing()
  {
    _zipFile?.Dispose();
    base.OnDisposing();
  }

  #endregion

  #region Private Methods

  private IFileSystemNode InitNodes()
  {
    var fileName = Path.GetFileNameWithoutExtension(_filePath);
    var rootNode = new FileSystemNode(this, fileName);

    foreach (var entry in _zipFile.Entries.Values)
    {
      CreateNode(entry, rootNode);
    }

    return rootNode;
  }

  private void CreateNode(fioZIP_CACHE_FILE.ENTRY entry, IFileSystemNode parent)
  {
    var node = new QCFileSystemNode(this, entry, parent);
    parent.AddChild(node);
  }

  #endregion

}
