using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Numerics;
//documentation = http://www.monogame.net/documentation/?page=main
namespace crawl
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    ///
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        PlayerControlled player;
        Entity wall;
        Projectile bullet;
        private InputHandler input;
       
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            input = new InputHandler();

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D disciple = Content.Load<Texture2D>("Disciplesmall");
            Texture2D wall_tex = Content.Load<Texture2D>("dummywall");
            Texture2D bullet_tex = Content.Load<Texture2D>("mage_bullet");
            player = new PlayerControlled(disciple);
            wall = new Entity(wall_tex);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            float turnval = 0.1f;
            input.Update();

            player.Updateplayer();

            if (input.IsKeyDown(Keys.Q))
            {
                wall.setAngle(wall.angle += turnval);
            }

            if (input.isMouseButtonClick())
            {
                Texture2D bullet_tex = Content.Load<Texture2D>("mage_bullet");
                bullet = new Projectile(bullet_tex, player.getX() + 10, player.getY() - 10);
            }
            if (bullet != null)
            {
                bullet.update(gameTime);
               
                //Vector2 xd = input.getMousePos();
                //xd.Normalize();
                //Debug.Print(xd.ToString());
                //Debug.Print(bullet.direction.ToString() + "dest");
            }
            Vector2 x = input.getMousePos();
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            wall.bounds.X = 0 + wall.texture.Height/2;
            wall.bounds.Y = 100;
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            player.Draw(spriteBatch);
            wall.Draw(spriteBatch);
            if (bullet != null)
            {
                //bullet.setPosition(new Vector2(10, 10));
                bullet.Draw(spriteBatch);
            }
            
            spriteBatch.End();
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        
    }
}
