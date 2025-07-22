using LibSaber.FileSystem;
using LibSaber.QuakeChampions.Structures.Resources;

namespace LibSaber.QuakeChampions.Files;

public class QCFileSystemNode : FileSystemNode
{

    #region Properties

    internal fioZIP_CACHE_FILE.ENTRY Entry { get; set; }
    public long SizeInBytes { get; set; }

    #endregion

    #region Constructor

    public QCFileSystemNode( IFileSystemDevice device, fioZIP_CACHE_FILE.ENTRY entry, IFileSystemNode parent = null)
        : base( device, entry.FileName, parent )
    {
        Entry = entry;
        SizeInBytes = entry.Size;
    }

    #endregion

}
