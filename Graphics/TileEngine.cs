using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SlimDX;
using SlimDX.Direct3D9;

namespace DoC.MapEditor.Graphics
{
    class TileEngine : IDisposable
    {
        #region Private Members...

        private Direct3D direct3D;
        private Device device;
        private Sprite sprite;
        private PresentParameters pp;
        private Font font;
        private Dictionary<string, D3DTexture> textureList = new Dictionary<string,D3DTexture>();

        #endregion

        #region Properties...

        public Dictionary<string, D3DTexture> TextureList
        {
            get { return textureList; }
        }

        #endregion

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public TileEngine(IntPtr handle)
        {
            try
            {
                // Instantiate the Direct3D object and get the display mode from the adapter
                direct3D = new Direct3D();
                DisplayMode dispMode = direct3D.GetAdapterDisplayMode(0);

                // Instantiate the present parameters and initialize the properties
                pp = new PresentParameters();
                pp.BackBufferCount = 1;
                pp.BackBufferFormat = dispMode.Format;
                pp.BackBufferHeight = 0;
                pp.BackBufferWidth = 0;
                pp.DeviceWindowHandle = handle;
                pp.PresentationInterval = PresentInterval.Immediate;
                pp.SwapEffect = SwapEffect.Discard;
                pp.Windowed = true;

                // Instantiate the device, sprite, and font objects
                device = new Device(direct3D, 0, DeviceType.Hardware, handle, CreateFlags.SoftwareVertexProcessing, pp);
                sprite = new Sprite(device);
                font = new Font(device, new System.Drawing.Font("Courier New", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dispose();
                Application.Exit();
            }
        }

        /// <summary>
        /// Disposes all created objects
        /// </summary>
        public void Dispose()
        {
            sprite.Dispose();
            device.Dispose();
            direct3D.Dispose();
        }

        /// <summary>
        /// Begins the rendering process
        /// </summary>
        public void BeginRenderingProcess()
        {
            try
            {
                device.Clear(ClearFlags.Target, 0, 1.0f, 0);
                device.BeginScene();
                sprite.Begin(SpriteFlags.AlphaBlend);
            }
            catch (Exception)
            { }
        }

        /// <summary>
        /// Ends the rendering process
        /// </summary>
        public void EndRenderingProcess()
        {
            try
            {
                sprite.End();
                device.EndScene();
                device.Present();
            }
            catch (Exception)
            { }
        }

        /// <summary>
        /// Draws text to the screen
        /// </summary>
        public void DrawText(string text, int x, int y)
        {
            font.DrawString(sprite, text, x, y, System.Drawing.Color.White);
        }

        /// <summary>
        /// Draws tiles to the screen
        /// </summary>
        public void DrawTile(Texture texture, int x, int y)
        {
            sprite.Draw(texture, new Vector3(x, y, 0), new Vector3(0, 0, 0), System.Drawing.Color.White);
        }

        /// <summary>
        /// Gets the frames per second
        /// </summary>
        public string GetFPS()
        {
            return "0";
        }

        /// <summary>
        /// Adds a texture to the texture list
        /// </summary>
        public void AddTexture(string name, string path)
        {
            textureList.Add(name, new D3DTexture(device, path));
        }
    }
}
