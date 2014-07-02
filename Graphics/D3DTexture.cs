using System;
using SlimDX.Direct3D9;

namespace DoC.MapEditor.Graphics
{
    public struct D3DTexture
    {
        public Texture Texture;
        public string Path;

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public D3DTexture(Device device, string path) : this()
        {
            Path = path;
            Texture = Texture.FromFile(device, path, Data.Tile.Width, Data.Tile.Height, 0, Usage.RenderTarget,
                Format.Unknown, Pool.Default, Filter.Point, Filter.None, 0);
        }
    }
}
