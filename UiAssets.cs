using System.Drawing;
using System.Reflection;
using System.Collections.Generic;
using System.IO;

// Only the images and icons used by the extracted UI are embedded.
internal static class UiAssets
{
    private static readonly Dictionary<string, Image> Images = new Dictionary<string, Image>();
    private static readonly Dictionary<string, Icon> Icons = new Dictionary<string, Icon>();
    private static readonly List<Stream> ResourceStreams = new List<Stream>();
    internal static Image Image(string name)
    {
        if (!Images.TryGetValue(name, out var image))
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("UI.Assets." + name);
            ResourceStreams.Add(stream);
            Images[name] = image = System.Drawing.Image.FromStream(stream);
        }
        return image;
    }
    internal static Icon Icon(string name)
    {
        if (!Icons.TryGetValue(name, out var icon))
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("UI.Assets." + name))
                Icons[name] = icon = new Icon(stream);
        return icon;
    }
}
