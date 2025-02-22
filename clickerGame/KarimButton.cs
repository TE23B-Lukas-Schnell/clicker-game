/*public class KarimButton : ClickerButton
{
    public float importantValue = 0;
    public string importantValueName;
    public float valuePerClick = 1;
    public Texture2D texture;

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
        if (ClickedOn())
        {
            importantValue += valuePerClick;
        }
    }

    public override void Draw()
    {
        DrawButton(texture);
        Raylib.DrawText($"{importantValueName}: {importantValue}", (int)Middle().X, (int)position.Y-20 , 20, Color.Black);
    }

    public KarimButton(Vector2 position, string importantValueName, Image sprite)
    {
        this.position = position;
        this.importantValueName = importantValueName;
        size.X = sprite.Width;
        size.Y = sprite.Height;
        gamelist.Add(this);
        texture = Raylib.LoadTextureFromImage(sprite);

    }
}*/