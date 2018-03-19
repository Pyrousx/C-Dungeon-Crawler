using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


    class Entity
    {
        public int x = 0;
        public int y = 0;
        public double xaccel, yaccel, xvel, yvel;
        public float angle = 0;
        public Color color;
        public int hp = 999;
        public Texture2D texture;
        private uint[] rawData;
        public Rectangle bounds;
        public Vector2 direction;
        protected InputHandler input;
        public float velocity = 1f;
        public Vector2 location; 
  
    public Entity(Texture2D Tex)
        {
            texture = Tex;

            color = Color.White;
            rawData = new uint[texture.Width * texture.Height];
            bounds = new Rectangle(300, 300, texture.Width, texture.Height);
            texture.GetData<uint>(rawData);
            input = new InputHandler();
        }

        public void setPosition(Vector2 p)
        {

            bounds.X = (int)(p.X);
            bounds.Y = (int)(p.Y);

        }
        
        public int getX()
    {
        return this.bounds.X;
    }
    public int getY()
    {
        return this.bounds.Y;
    }

    public void setAngle(float angle)
         {
        
         }

        public bool boundingBoxIntersection(Entity b)
        {
            // check if two Rectangles intersect
            return (bounds.Right > b.bounds.Left && bounds.Left < b.bounds.Right &&
                    bounds.Bottom > b.bounds.Top && bounds.Top < b.bounds.Bottom);
        }

        public bool visiblePixelCollision(Entity b)
        {
            if (boundingBoxIntersection(b))
            {


                int x1 = Math.Max(bounds.X, b.bounds.X);
                int x2 = Math.Min(bounds.X + bounds.Width, b.bounds.X + b.bounds.Width);

                int y1 = Math.Max(bounds.Y, b.bounds.Y);
                int y2 = Math.Min(bounds.Y + bounds.Height, b.bounds.Y + b.bounds.Height);

                for (int y = y1; y < y2; ++y)
                {
                    for (int x = x1; x < x2; ++x)
                    {

                        // start of slow and understandable version
                        int thisX = (x - bounds.X);
                        int thisY = (y - bounds.Y);
                        int bX = (x - b.bounds.X);
                        int bY = (y - b.bounds.Y);

                        Color thisPixelValues = getPixel(thisX, thisY);
                        Color bPixelValues = b.getPixel(bX, bY);

                        // compares the Alpha of each pixel to see if they are both visible
                        if (thisPixelValues.A > 20 && bPixelValues.A > 20)
                        {
                            return true;
                        }

                        // end of slow understandable version
                    }
                }
            }

            return false;
        }

        // get pixel syntax used by slow version
        private Color getPixel(int x, int y)
        {

            Color retrievedColor = new Color();

            int targetPixelIndex = texture.Width * y + x;
            uint packedColour = rawData[targetPixelIndex];

            retrievedColor.B = (byte)(packedColour);
            retrievedColor.G = (byte)(packedColour >> 8);
            retrievedColor.R = (byte)(packedColour >> 16);
            retrievedColor.A = (byte)(packedColour >> 24);

            return retrievedColor;
        }


        public void Draw(SpriteBatch sb)
        {
            //bounds = new Rectangle(300, 300, texture.Width, texture.Height);
            //sb.Draw(texture, bounds, color);
            sb.Draw(texture, bounds, null, color, angle, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 0);
           // spriteBatch.Draw(Player, new Rectangle((int)Position.X, (int)Position.Y, Player.Width, Player.Height), null, Color.White, angle, new Vector2(Player.Width / 2, Player.Height / 2), SpriteEffects.None, 0);
        }

       public void movecalc()
        {
        double veldub = Convert.ToDouble(velocity);
        double angledub = Convert.ToDouble(angle);
        

        xaccel = Math.Sin(angledub) * velocity;
        yaccel = Math.Cos(angledub) * velocity;

        this.xvel += xaccel;
        this.yvel += xaccel;

        this.setPosition(new Vector2(this.bounds.X += Convert.ToInt32(this.xvel), this.bounds.Y += Convert.ToInt32(this.yvel)));

        }

        public Vector2 getVector()
    {
        Vector2 resultVec = new Vector2();

        resultVec.X = this.bounds.X;
        resultVec.Y = this.bounds.Y;

        return resultVec;
    }

    }
