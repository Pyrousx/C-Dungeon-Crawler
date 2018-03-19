using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
class Projectile : Entity
{
    protected int dmg = 1;
    Vector2 movement;
    public Vector2 destination;
    public Vector2 bulletpos;
    private double resultang = 0.5f;
    public Projectile(Texture2D Tex, int x = 0, int y = 0 , int velocity = 1) : base(Tex)
    {
        input.Update();   
        destination = input.getMousePos();
        direction = destination - this.getVector();
        if (direction != Vector2.Zero)
        {
            direction.Normalize();
        }
        
        this.bounds.X = x;
        this.bounds.Y = y;
        bulletpos.Y = y;
        bulletpos.X = x;

    }
    public void update(GameTime gameTime)
    {
        //input.Update();
        
        direction = input.getMousePos() - this.getVector();
        
        
        if (direction != Vector2.Zero)
        {
            direction.Normalize();
        }
        //if (Vector2.Dot(this.getVector(), direction) < 0)
        //{
        //    this.velocity += ()
        //    this.setPosition(Vector2.Add(this.getVector(), ))
        //    //this.setPosition(new Vector2(this.bounds.X, this.bounds.Y += 3));
        //}
        this.setPosition(Vector2.Add(this.getVector(), this.direction * this.velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds));
    }

}
