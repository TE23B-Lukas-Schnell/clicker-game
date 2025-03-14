public class ClickerButton : ClickableObject
{
    public float clickValue = 0;
    public string clickValueName;
    public float clickIncrease = 1; // this value is added every time you click
    public float clickMultiplier = 1; // this value is multiplied by the clickIncrease 
    public readonly int textSize = 50;
    public Texture2D texture;
    public KeyboardKey button;

    public float CalculateValuePerClick(float clickIncrease, float clickMultiplier)
    {
        return clickIncrease * clickMultiplier;
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
            clickValue += CalculateValuePerClick(clickIncrease, clickMultiplier);
        }
        for (int i = 0; i < AutoClicker.AutoClickers.Count; i++)
        {
            AutoClicker.AutoClickers[i].Update();
        }
    }

    public override void Draw()
    {
        DrawButton(texture);
        Raylib.DrawText($"{clickValueName}", (int)(position.X + size.X * 0.3f), (int)position.Y - textSize * 2, textSize, Color.Black);
        Raylib.DrawText($"{clickValue}", (int)(position.X + size.X * 0.3f), (int)position.Y - textSize, textSize, Color.Black);
        // loops through all autoclickers
        for (int i = 0; i < AutoClicker.AutoClickers.Count; i++)
        {
            AutoClicker.AutoClickers[i].Draw();
        }
    }

    public class AutoClicker
    {
        public static List<AutoClicker> AutoClickers = new List<AutoClicker>();

        public Vector2 position;
        public Vector2 size;
        public ClickerButton buttonReference;

        public float clickTime = 0;
        public float timeBetweenClicks = 120 * 10;
        public float autoClickerclickIncrease = 1;
        public float autoClickerclickMultiplier = 1;

        public void Update()
        {
            clickTime--;
            if (clickTime <= 0)
            {
                clickTime = timeBetweenClicks;
                buttonReference.clickValue += buttonReference.CalculateValuePerClick(autoClickerclickIncrease, autoClickerclickMultiplier);
            }
        }
        public void Draw()
        {
            byte colorValue = (byte)(255 * (clickTime / timeBetweenClicks));
            Color autoClickerColor = new Color((byte)(255 - colorValue), (byte)(colorValue), (byte)0, (byte)100);
            Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, autoClickerColor);
        }

        public AutoClicker(ClickerButton buttonReference)
        {
            this.buttonReference = buttonReference;

            this.size = new Vector2(buttonReference.size.X / 10, buttonReference.size.Y / 10);

            if (AutoClickers.Count == null)
            {
                this.position = buttonReference.position;
            }
            else
            {
                float autoClickerColumn = AutoClickers.Count % 10; // everytime autoclikers.count is the sizedivider value it decreases back to 0
                float autoClickerRow = AutoClickers.Count / 10;
                this.position = buttonReference.position + new Vector2(autoClickerColumn * size.X, autoClickerRow * size.Y);
            }
            AutoClickers.Add(this);
        }
    }

    public int GetAutoclickerLength() => AutoClicker.AutoClickers.Count;

    public void SpawnAutoClicker()
    {
        new AutoClicker(this);
    }
    public void AutoClickerIncreaseUpgrade()
    {
        for (int i = 0; i < AutoClicker.AutoClickers.Count; i++)
        {
            AutoClicker.AutoClickers[i].autoClickerclickIncrease++;
        }
    }
    public void AutoClickerMultiplierUpgrade()
    {
        for (int i = 0; i < AutoClicker.AutoClickers.Count; i++)
        {
            AutoClicker.AutoClickers[i].autoClickerclickMultiplier++;
        }
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