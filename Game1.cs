using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D pixel;
    Rectangle leftPaddle = new Rectangle(0, 0, 20, 100);

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here

        pixel = new Texture2D(GraphicsDevice, 1, 1);
        pixel.SetData([Color.White]);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        KeyboardState kState = Keyboard.GetState();

        if (kState.IsKeyDown(Keys.W) && leftPaddle.Y > 0)
        {
            leftPaddle.Y--;
        }
        if (kState.IsKeyDown(Keys.S)&& leftPaddle.Y < 380)
        {
            leftPaddle.Y++;
        }
        if (kState.IsKeyDown(Keys.D)&& leftPaddle.X < 700)
        {
            leftPaddle.X++;
        }
        if (kState.IsKeyDown(Keys.A)&& leftPaddle.X > 0)
        {
            leftPaddle.X--;
        }
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.DarkCyan);

        _spriteBatch.Begin();
        _spriteBatch.Draw(pixel, leftPaddle, Color.DarkOrange);

        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
