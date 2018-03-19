using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class PlayerControlled:Entity
    {
    
    //Vector2 direction = mouseLoc - Position;

   // angle = (float) (Math.Atan2(direction.Y, direction.X));
    public PlayerControlled(Texture2D Tex) : base(Tex)
    {
        input = new InputHandler();

        Vector2 direction = input.getMousePos();
        direction.X -= this.bounds.X;
        direction.Y -= this.bounds.Y;
        angle = (float)(Math.Atan2(direction.Y, direction.X));
    }
    
    public void Updateplayer()
    {
        input.Update();
        Vector2 temp;
        temp.X = this.x;
        temp.Y = this.y;
        double xlocaccel = 0;

        double veldub = Convert.ToDouble(velocity);
        double angledub = Convert.ToDouble(angle);

       
        xaccel = Math.Sin(angledub) * velocity;
        yaccel = Math.Cos(angledub) * velocity;

        this.xvel += xaccel;
        this.yvel += xaccel;

        //this.setPosition(new Vector2(this.bounds.X += Convert.ToInt32(this.xvel), this.bounds.Y += Convert.ToInt32(this.yvel)));


        if (input.IsKeyDown(Keys.Left))
        {
           this.setPosition(new Vector2(this.bounds.X -= 3, this.bounds.Y));
        }

        if (input.IsKeyDown(Keys.Right))
        {
            this.setPosition(new Vector2(this.bounds.X += 3, this.bounds.Y));
        }

        if (input.IsKeyDown(Keys.Up))
        {
            this.setPosition(new Vector2(this.bounds.X, this.bounds.Y -= 3));
        }

        if (input.IsKeyDown(Keys.Down))
        {
            this.setPosition(new Vector2(this.bounds.X, this.bounds.Y += 3));
        }


        this.direction = input.getMousePos();
        this.direction.X -= this.bounds.X;
        this.direction.Y -= this.bounds.Y;
        this.angle = (float)(Math.Atan2(this.direction.Y, this.direction.X));
    }


    }

