using UnityEngine;

namespace HotBloodr
{
    public static class GraphicsHelper
    {
        public static Texture2D Sprite2Texture(Sprite sprite)
        {
            var rect = sprite.rect;
            var colors = sprite.texture.GetPixels((int)rect.xMin, (int)rect.yMin, (int)rect.width, (int)rect.height);
            var texture = new Texture2D((int)rect.width, (int)rect.height);
            texture.SetPixels(0, 0, (int)rect.width, (int)rect.height, colors);
            texture.Apply();

            return texture;
        }
    }
}