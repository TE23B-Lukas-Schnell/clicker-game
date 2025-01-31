abstract public class ClickableObject
{
    public static List<ClickableObject> gamelist = new List<ClickableObject>();
    public static bool showHitboxes() => Raylib.IsKeyDown(KeyboardKey.A);

    public Vector2 position;
    public Vector2 size;
    public Vector2 Middle() => new Vector2(position.X + (size.X * 0.5f), position.Y + (size.Y * 0.5f));
    public Rectangle GetHitbox() => new Rectangle(position, size); 
    public bool MouseHover() => Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), GetHitbox());
    public bool ClickedOn() => MouseHover() && Raylib.IsMouseButtonPressed(MouseButton.Left);

    //körs varje frame och uppdaterar värderna
    abstract public void Update();
    //körs varje frame och ritar ut till skärmen
    abstract public void Draw();
}

