public class ClickerButton : ClickableObject
{
    public float clickValue = 0;
    public string clickValueName;
    public float clickIncrease = 1; // this value is added every time you click
    public float clickMultiplier = 1; // this value is multiplied by the clickIncrease 
    public readonly int textSize = 50;
    public Texture2D texture;
    public KeyboardKey button;

    public void DrawButton(Texture2D texture)
    {
        Raylib.DrawTexture(texture, (int)position.X, (int)position.Y, Color.White);
        if (showHitboxes())
        {
            Raylib.DrawRectangleRec(GetHitbox(), Color.Red);
        }
    }

    public override void Update()
    {
        if (ClickedOn() || Raylib.IsKeyPressed(button))
        {
            clickValue += clickIncrease * clickMultiplier;
        }
    }

    public override void Draw()
    {
        DrawButton(texture);
        Raylib.DrawText($"{clickValueName}: {clickValue}", (int)(position.X + size.X * 0.25f), (int)position.Y - textSize, textSize, Color.Black);
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