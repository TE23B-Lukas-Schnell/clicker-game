global using Raylib_cs;
global using System.Numerics;

Raylib.InitWindow(1600, 900, "Game");
Raylib.SetTargetFPS(60);

Image karimImage = Raylib.LoadImage(@"./Assets/karimryde-scaled-400x400.png");
Image mikaelImage = Raylib.LoadImage(@"./Assets/mikaelbergstrom-scaled-400x400.png");

ClickerButton karim = new ClickerButton(new Vector2(Raylib.GetScreenWidth() * 0.3f - karimImage.Width / 2, Raylib.GetScreenHeight() / 3), "Båtar", karimImage, KeyboardKey.F);
ClickerButton mikael = new ClickerButton(new Vector2(Raylib.GetScreenWidth() * 0.7f - mikaelImage.Width / 2, Raylib.GetScreenHeight() / 3), "Köttar", mikaelImage, KeyboardKey.D);

clickIncreaseUpgrade karimUpgrade = new clickIncreaseUpgrade(karim);
clickIncreaseUpgrade mikaelUpgrade = new clickIncreaseUpgrade(mikael);

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Gray);

    for (int i = 0; i < ClickableObject.gamelist.Count; i++)
    {
        ClickableObject.gamelist[i].Update();
        ClickableObject.gamelist[i].Draw();
    }

    Raylib.DrawText("VS", (Raylib.GetScreenWidth() / 2)-20, Raylib.GetScreenHeight() / 2, 70, Color.Black);
    Raylib.DrawText($"mus:{Raylib.GetMousePosition()}", 0, 0, 50, Color.Black);

    Raylib.EndDrawing();
}

