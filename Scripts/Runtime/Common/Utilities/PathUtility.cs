using System;
using System.IO;

namespace MMHFramework
{
    public static class PathUtility
    {
        public static string GetRegularPath(string path)
        {
            if(path == null)
            {
                return null;
            }
            return path.Replace('\\','/');
        }

        public static string GetRelativePath(string relativeTo,string path)
        {
            relativeTo = Path.GetFullPath(relativeTo);
            path = Path.GetFullPath(path);
            if(Path.GetPathRoot(relativeTo).ToUpper() != Path.GetPathRoot(path).ToUpper())
            {
                return path;
            }
            var uriFrom = new Uri(relativeTo + Path.DirectorySeparatorChar);
            var uriTo = new Uri(path);
            if(uriFrom.Scheme != uriTo.Scheme)
            {
                return path;
            }
            var relativeUri = uriFrom.MakeRelativeUri(uriTo);
            var relativePath = Uri.UnescapeDataString(relativeUri.ToString());
            relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar,Path.DirectorySeparatorChar);
            return relativePath;
        }
    }
}