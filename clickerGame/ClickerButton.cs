public class ClickerButton : ClickableObject
{
    public float clickValue = 0;
    public string clickValueName;
    public float clickIncrease = 1; // this value is added every time you click
    public float clickMultiplier = 1; // this value is multiplied by the clickIncrease 
    public readonly int textSize = 50;
    public Texture2D texture;
    public KeyboardKey button;
    public void valueIncrease() //this is supposed to run whenever you click the button
    {
        clickValue += clickIncrease * clickMultiplier;
    }

    public void DrawButton(Texture2D texture)
    {
        Raylib.DrawTexture(texture, (int)position.X, (int)position.Y, Color.White);
        if (showHitboxes()) Raylib.DrawRectangleRec(GetHitbox(), Color.Red);
    }

    public override void Update()
    {
        if (ClickedOn() || Raylib.IsKeyPressed(button))
        {
            valueIncrease();
        }
    }

    public override void Draw()
    {
        DrawButton(texture);
        Raylib.DrawText($"{clickValueName}: {clickValue}", (int)(position.X + size.X * 0.25f), (int)position.Y - textSize, textSize, Color.Black);
        for (int i = 0; i < AutoClicker.AutoClickers.Count; i++)
        {
            AutoClicker.AutoClickers[i].Update();
            AutoClicker.AutoClickers[i].Draw();
        }
    }

    public class AutoClicker
    {
        public static List<AutoClicker> AutoClickers = new List<AutoClicker>();



        public Vector2 position;
        public Vector2 size;
        public ClickerButton buttonReference;

        public float timeBetweenClicks = 0;
        public float clickTimeInFrames = 120 * 5;

        public void Update()
        {
            timeBetweenClicks--;
            if (timeBetweenClicks <= 0)
            {
                timeBetweenClicks = clickTimeInFrames;
                buttonReference.valueIncrease();
            }
        }
        public void Draw()
        {
            // byte colorMultiplier = 
            Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, new Color((byte)60,(byte)120,(byte)timeBetweenClicks/2));
        }

        public AutoClicker(ClickerButton buttonReference)
        {
            this.buttonReference = buttonReference;

            this.size = new Vector2(30, 30);

            this.position = buttonReference.position;

            /* if (AutoClickers.Count == 0)
             {
                 this.position = buttonReference.position;
             }
             else if (AutoClickers[AutoClickers.Count].position.X <= buttonReference.position.X + buttonReference.size.X && AutoClickers[AutoClickers.Count].position.Y <= buttonReference.position.Y + buttonReference.size.Y)
             {
                 this.position = buttonReference.position + new Vector2(size.X * 2 * AutoClickers.Count, 0);

             }
             else if (AutoClickers[AutoClickers.Count].position.X >= buttonReference.position.X + buttonReference.size.X && AutoClickers[AutoClickers.Count].position.Y <= buttonReference.position.Y + buttonReference.size.Y)
             {
                 this.position = buttonReference.position + new Vector2(buttonReference.position.X + buttonReference.size.X, size.Y * 2 * AutoClickers.Count);
             }
 */



            AutoClickers.Add(this);
        }
    }

    public void spawnClicker()
    {
        new AutoClicker(this);
    }

    public ClickerButton(Vector2 position, string importantValueName, Image sprite, KeyboardKey button)
    {
        this.position = position;
        this.clickValueName = importantValueName;
        size.X = sprite.Width;
        size.Y = sprite.Height;
        gamelist.Add(this);
        texture = Raylib.LoadTextureFromImage(sprite);
        this.button = button;
    }
}