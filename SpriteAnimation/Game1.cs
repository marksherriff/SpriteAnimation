using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpriteAnimation;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D adventurerSheet;
    private Rectangle[] standingAnimation = new Rectangle[4];

    private float timer = 0f;
    private int threshold = 150;
    private int previousAnimationIndex = 0;
    private int currentAnimationIndex = 1;

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

        adventurerSheet = Content.Load<Texture2D>("Spritesheets/adventurer-Sheet");
        standingAnimation[0] = new Rectangle(0, 0, 50, 37);
        standingAnimation[1] = new Rectangle(50, 0, 50, 37);
        standingAnimation[2] = new Rectangle(100, 0, 50, 37);
        standingAnimation[3] = new Rectangle(150, 0, 50, 37);
}

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // Check if the timer has exceeded the threshold.
        if (timer > threshold)
        {
            if (currentAnimationIndex == standingAnimation.Length - 1)
            {
                currentAnimationIndex = 0;
            }
            else
            {
                currentAnimationIndex += 1;
            }
            // Reset the timer.
            timer = 0;
        }
        // If the timer has not reached the threshold, then add the milliseconds that have past since the last Update() to the timer.
        else
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }



        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();

        _spriteBatch.Draw(adventurerSheet, new Vector2(0,0), Color.White);
        _spriteBatch.Draw(adventurerSheet, new Vector2(400,100), standingAnimation[currentAnimationIndex], Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}

