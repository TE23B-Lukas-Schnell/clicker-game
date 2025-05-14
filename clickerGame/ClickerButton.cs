public class ClickerButton : ClickableObject
{
    public float clickValue = 0;
    public string clickValueName;
    public float clickIncrease = 1;
    public float clickMultiplier = 1;
    public readonly int textSize = 50;
    public Texture2D texture;
    public KeyboardKey button;
    public List<AutoClicker> AutoClickersList = new List<AutoClicker>();

    /// <summary>
    /// the savedata is stored in integers
    /// the first value is the amount of båtar/köttar
    /// the second value is the additive upgrade upgradeNumber
    /// the third value is the multiplier upgrade upgradeNumber
    /// the fourth value is the generator upgrade upgradeNumber
    /// the fifth value is the generator additive upgrade upgradeNumber
    /// the sixth value is the generator multiplier upgrade upgradeNumber
    /// the seventh value is the generator speed upgrade upgradeNumber
    /// </summary>
    public int[] savedata = [0, 0, 0, 0, 0, 0, 0];
    // det är en array för att det kommer inte läggas till fler värden under runtime


    public float CalculateValuePerClick(float clickIncrease, float clickMultiplier)
    {
        return MathF.Round(clickIncrease * MathF.Pow(clickMultiplier, 1.2f) + 1);
    }

    public void DrawButton(Texture2D texture)
    {
        Raylib.DrawTexture(texture, (int)position.X, (int)position.Y, Color.White);
        if (showHitboxes()) Raylib.DrawRectangleRec(GetHitbox(), Color.Red);
    }

    public class AutoClicker
    {
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

            if (buttonReference.AutoClickersList.Count == null)
            {
                this.position = buttonReference.position;
            }
            else
            {
                float autoClickerColumn = buttonReference.AutoClickersList.Count % 10; // everytime autoclikers.count is 10 it decreases back to 0
                float autoClickerRow = buttonReference.AutoClickersList.Count / 10;
                this.position = buttonReference.position + new Vector2(autoClickerColumn * size.X, autoClickerRow * size.Y);
            }
            buttonReference.AutoClickersList.Add(this);
        }
    }

    public int GetAutoclickerLength() => AutoClickersList.Count;

    public void SpawnAutoClicker(int amountToSpawn)
    {
        for (int i = 0; i < amountToSpawn; i++) new AutoClicker(this);
    }
    public void AutoClickerIncreaseUpgrade(float increaseValue)
    {
        for (int i = 0; i < AutoClickersList.Count; i++)
        {
            AutoClickersList[i].autoClickerclickIncrease = increaseValue;
        }
    }
    public void AutoClickerMultiplierUpgrade(float multiplierValue)
    {
        for (int i = 0; i < AutoClickersList.Count; i++)
        {
            AutoClickersList[i].autoClickerclickMultiplier = multiplierValue;
        }
    }
    public void AutoClickerTimeUpgrade(float timeDecreaseCoefficient, float timeDecreaseExponent)
    {
        for (int i = 0; i < AutoClickersList.Count; i++)
        {
            AutoClickersList[i].timeBetweenClicks = MathF.Pow(timeDecreaseCoefficient, timeDecreaseExponent);
        }
    }

    public override void Update()
    {
        if (ClickedOn() || Raylib.IsKeyPressed(button))
        {
            clickValue += CalculateValuePerClick(clickIncrease, clickMultiplier);
        }

        for (int i = 0; i < AutoClickersList.Count; i++)
        {
            AutoClickersList[i].Update();
        }

        savedata[0] = (int)MathF.Round(clickValue);
    }

    public override void Draw()
    {
        DrawButton(texture);
        Raylib.DrawText($"{clickValueName}", (int)(position.X + size.X * 0.3f), (int)position.Y - textSize * 2, textSize, Color.Black);
        Raylib.DrawText($"{clickValue}", (int)(position.X + size.X * 0.3f), (int)position.Y - textSize, textSize, Color.Black);
        for (int i = 0; i < AutoClickersList.Count; i++)
        {
            AutoClickersList[i].Draw();
        }
    }

    public ClickerButton(string importantValueName, Image sprite, KeyboardKey button)
    {
        clickValueName = importantValueName;
        size.X = sprite.Width;
        size.Y = sprite.Height;
        gamelist.Add(this);
        texture = Raylib.LoadTextureFromImage(sprite);
        this.button = button;
        if (importantValueName.ToLower() == "båtar")
        {
            this.position = new Vector2(Raylib.GetScreenWidth() * 0.3f - sprite.Width / 2, Raylib.GetScreenHeight() / 5);
        }
        else if (importantValueName.ToLower() == "köttar")
        {
            this.position = new Vector2(Raylib.GetScreenWidth() * 0.7f - sprite.Width / 2, Raylib.GetScreenHeight() / 5);
        }
    }
}