using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace VelcroSuite
{
    class DrawLineTwoPoint
    {

        #region Private Members

      
        private Texture2D pixel;
       
        #endregion

        public DrawLineTwoPoint()
        {
            
        }

        #region Private Methods

        private void CreateThePixel(SpriteBatch SpriteBatch)
        {
            pixel = new Texture2D(SpriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });
        }

        #endregion

        /// <summary>
        /// Draws a list of connecting points
        /// </summary>
        /// <param name="spriteBatch">The destination drawing surface</param>
        /// /// <param name="position">Where to position the points</param>
        /// <param name="points">The points to connect with lines</param>
        /// <param name="color">The color to use</param>
        /// <param name="thickness">The thickness of the lines</param>
        private void DrawPoints(SpriteBatch SpriteBatch, Vector2 position, List<Vector2> points, Color color, float thickness)
        {
            if (points.Count < 2)
                return;

            for (int i = 1; i < points.Count; i++)
            {
                Draw(SpriteBatch,  points[i - 1] + position, points[i] + position, color, thickness);
            }
        }


        /// <summary>
        /// Draws a line from point1 to point2 with an offset
        /// </summary>
        /// <param name="spriteBatch">The destination drawing surface</param>
        /// <param name="x1">The X coord of the first point</param>
        /// <param name="y1">The Y coord of the first point</param>
        /// <param name="x2">The X coord of the second point</param>
        /// <param name="y2">The Y coord of the second point</param>
        /// <param name="color">The color to use</param>
        public void Draw(SpriteBatch SpriteBatch, float x1, float y1, float x2, float y2, Color color)
        {
           Draw(SpriteBatch, new Vector2(x1, y1), new Vector2(x2, y2), color, 1.0f);
        }


        /// <summary>
        /// Draws a line from point1 to point2 with an offset
        /// </summary>
        /// <param name="spriteBatch">The destination drawing surface</param>
        /// <param name="x1">The X coord of the first point</param>
        /// <param name="y1">The Y coord of the first point</param>
        /// <param name="x2">The X coord of the second point</param>
        /// <param name="y2">The Y coord of the second point</param>
        /// <param name="color">The color to use</param>
        /// <param name="thickness">The thickness of the line</param>
        public void Draw(SpriteBatch SpriteBatch,  float x1, float y1, float x2, float y2, Color color, float thickness)
        {
            Draw(SpriteBatch,  new Vector2(x1, y1), new Vector2(x2, y2), color, thickness);
        }

        /// <summary>
        /// Draws a line from point1 to point2 with an offset
        /// </summary>
        /// <param name="spriteBatch">The destination drawing surface</param>
        /// <param name="point1">The first point</param>
        /// <param name="point2">The second point</param>
        /// <param name="color">The color to use</param>
        public  void Draw(SpriteBatch SpriteBatch,  Vector2 point1, Vector2 point2, Color color)
        {
            Draw(SpriteBatch,  point1, point2, color, 1.0f);
        }


        /// <summary>
        /// Draws a line from point1 to point2 with an offset
        /// </summary>
        /// <param name="spriteBatch">The destination drawing surface</param>
        /// <param name="point1">The first point</param>
        /// <param name="point2">The second point</param>
        /// <param name="color">The color to use</param>
        /// <param name="thickness">The thickness of the line</param>
        public void Draw(SpriteBatch SpriteBatch, Vector2 point1, Vector2 point2, Color color, float thickness)
        {
            // calculate the distance between the two vectors
            float distance = Vector2.Distance(point1, point2);

            // calculate the angle between the two vectors
            float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);

            Draw(SpriteBatch, point1, distance, angle, color, thickness);
        }


        /// <summary>
        /// Draws a line from point1 to point2 with an offset
        /// </summary>
        /// <param name="spriteBatch">The destination drawing surface</param>
        /// <param name="point">The starting point</param>
        /// <param name="length">The length of the line</param>
        /// <param name="angle">The angle of this line from the starting point in radians</param>
        /// <param name="color">The color to use</param>
        public void Draw(SpriteBatch SpriteBatch, Vector2 point, float length, float angle, Color color)
        {
           Draw(SpriteBatch,  point, length, angle, color, 1.0f);
        }

        /// <summary>
        /// Draws a line from point1 to point2 with an offset
        /// </summary>
        /// <param name="spriteBatch">The destination drawing surface</param>
        /// <param name="point">The starting point</param>
        /// <param name="length">The length of the line</param>
        /// <param name="angle">The angle of this line from the starting point</param>
        /// <param name="color">The color to use</param>
        /// <param name="thickness">The thickness of the line</param>
        public  void Draw(SpriteBatch SpriteBatch, Vector2 point, float length, float angle, Color color, float thickness)
        {
            if (pixel == null)
            {
                CreateThePixel(SpriteBatch);
            }

            // stretch the pixel between the two vectors
            SpriteBatch.Draw(pixel,
                             point,
                             null,
                             color,
                             angle,
                             Vector2.Zero,
                             new Vector2(length, thickness),
                             SpriteEffects.None,
                             0);
        }


        #region PutPixel

        public void PutPixel(SpriteBatch SpriteBatch, float x, float y, Color color)
        {
            PutPixel(SpriteBatch,  new Vector2(x, y), color);
        }


        public void PutPixel(SpriteBatch SpriteBatch, Vector2 position, Color color)
        {
            if (pixel == null)
            {
                CreateThePixel(SpriteBatch);
            }

            SpriteBatch.Draw(pixel, position, color);
        }

        #endregion


    }
}
