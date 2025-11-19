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

    Rectangle rightPaddle = new Rectangle(780, 0, 20, 100);

     Rectangle ball = new Rectangle(390, 250, 20, 20);
    int ballSpeedX = 5;
    int ballSpeedY = 5;

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
            leftPaddle.Y-=5;
        }
        if (kState.IsKeyDown(Keys.S)&& leftPaddle.Bottom < 480)
        {
            leftPaddle.Y+=5;
        }
        if (kState.IsKeyDown(Keys.Up) && rightPaddle.Y > 0)
        {
            rightPaddle.Y-=5;
        }
        if (kState.IsKeyDown(Keys.Down)&& rightPaddle.Bottom < 480)
        {
            rightPaddle.Y+=5;
        }

        ball.X += ballSpeedX;
        ball.Y += ballSpeedY;
        if (ball.Bottom >= 480)
        {
            ball.Y = 480 - ball.Height;
            ballSpeedY *= -1;
        }
        if (ball.Y <= 0)
        {
            ball.Y = 0;
            ballSpeedY *= -1;
        }
        if (ball.Intersects(leftPaddle) || ball.Intersects(rightPaddle))
        {
            ballSpeedX *= -1;
        }
        // TODO: Add your update logic here

            base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.DarkCyan);

        _spriteBatch.Begin();
        _spriteBatch.Draw(pixel, leftPaddle, Color.DarkOrange);
        _spriteBatch.Draw(pixel, rightPaddle, Color.DarkOrange);
        _spriteBatch.Draw(pixel, ball, Color.DarkMagenta);

        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
