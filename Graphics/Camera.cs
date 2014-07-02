using System;
using SlimDX;
using DoC.MapEditor.Data;

namespace DoC.MapEditor.Graphics
{
    static class Camera
    {
        public static Vector2 Location = Vector2.Zero;
        public static int OffsetX;
        public static int OffsetY;

        /// <summary>
        /// Updates the camera
        /// </summary>
        public static void Update()
        {
            Vector2 offset = new Vector2(Location.X / Tile.Width, Location.Y / Tile.Height);
            OffsetX = (int)offset.X;
            OffsetY = (int)offset.Y;
        }
    }
}
