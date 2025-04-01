class ScreenText
{
    public string text;
    public Vector2 position;
    public int fontSize;
    public Color color;
    public int timeBeforeFading;
    public float fadePerFrame;
    // public bool permanent;

    public ScreenText(string text, Vector2 position, int fontSize, Color color)
    {
        this.text = text;
        this.position = position;
        this.fontSize = fontSize;
        this.color = color;
    }

    public ScreenText(string text, Vector2 position, int fontSize, Color color, int timeBeforeFading, float fadePerFrame)
    {
        this.text = text;
        this.position = position;
        this.fontSize = fontSize;
        this.color = color;
        this.timeBeforeFading = timeBeforeFading;
        this.fadePerFrame = fadePerFrame;
    }

    // public ScreenText()
    /*
        public static void DrawFadingText(string text, Vector2 position, int size, Color color, int timeBeforeFading, float fadePerFrame)
        {
            Raylib.DrawText(text, (int)position.X, (int)position.Y, size, color);
            color.A = (byte)-fadePerFrame;
        }
        */
}