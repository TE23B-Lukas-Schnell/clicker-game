global using Raylib_cs;
global using System.Numerics;

Raylib.InitWindow(1600, 900, "Game");
Raylib.SetTargetFPS(120);

Image karimImage = Raylib.LoadImage(@"./Assets/karimryde-scaled-400x400.png");
Image mikaelImage = Raylib.LoadImage(@"./Assets/mikaelbergstrom-scaled-400x400.png");

ClickerButton karim = new ClickerButton("Båtar", karimImage, KeyboardKey.F);
ClickerButton mikael = new ClickerButton("Köttar", mikaelImage, KeyboardKey.J);

clickIncreaseUpgrade karimClickIncrease = new clickIncreaseUpgrade(karim);
clickIncreaseUpgrade mikaelClickIncrease = new clickIncreaseUpgrade(mikael);

clickMultiplierUpgrade karimMultiplier = new clickMultiplierUpgrade(karim);
clickMultiplierUpgrade mikaelMultiplier = new clickMultiplierUpgrade(mikael);

autoClickerUpgrade karimAutoClicker = new autoClickerUpgrade(karim);
autoClickerUpgrade mikaelAutoClicker = new autoClickerUpgrade(mikael);

AutoClickerIncreaseUpgrade karimAutoClickerIncrease = new AutoClickerIncreaseUpgrade(karim);
AutoClickerIncreaseUpgrade mikaelAutoClickerIncrease = new AutoClickerIncreaseUpgrade(mikael);

AutoClickerMultiplierUpgrade karimAutoClickerMultiplier = new AutoClickerMultiplierUpgrade(karim);
AutoClickerMultiplierUpgrade mikaelAutoClickerMultiplier = new AutoClickerMultiplierUpgrade(mikael);

AutoClickerTimeUpgrade karimAutoClickerTime = new AutoClickerTimeUpgrade(karim);
AutoClickerTimeUpgrade mikaelAutoClickerTime = new AutoClickerTimeUpgrade(mikael);

Save.LoadGame(Save.ReadSaveFile("./karimSave.txt"), karim, [
    karimClickIncrease,
    karimMultiplier,
    karimAutoClicker,
    karimAutoClickerIncrease,
    karimAutoClickerMultiplier,
    karimAutoClickerTime,
]);

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Gray);

    for (int i = 0; i < ClickableObject.gamelist.Count; i++)
    {
        ClickableObject.gamelist[i].Update();
        ClickableObject.gamelist[i].Draw();
    }

    Raylib.DrawText("VS", (Raylib.GetScreenWidth() / 2) - 50, Raylib.GetScreenHeight() / 3 + 50, 80, Color.Black);

    //this part is for debugging
    /*
    Console.Clear();
    Console.WriteLine("Karim Upgrades:");
    for (int i = 0; i < karim.savedata.Length; i++)
    {
        Console.Write(karim.savedata[i] + ", ");
    }
    Console.WriteLine("");
    Console.WriteLine("Mikael Upgrades:");
    for (int i = 0; i < mikael.savedata.Length; i++)
    {
        Console.Write(mikael.savedata[i] + ", ");
    }
    */

    Raylib.EndDrawing();

    if (Raylib.IsKeyDown(KeyboardKey.F2))
    {
        Save.LoadGame(Save.ReadSaveFile("./karimSave.txt"), karim, [
            karimClickIncrease,
        karimMultiplier,
        karimAutoClicker,
        karimAutoClickerIncrease,
        karimAutoClickerMultiplier,
        karimAutoClickerTime
        ]);
        Save.LoadGame(Save.ReadSaveFile("./mickeSave.txt"), mikael, [
            mikaelClickIncrease,
        mikaelMultiplier,
        mikaelAutoClicker,
        mikaelAutoClickerIncrease,
        mikaelAutoClickerMultiplier,
        mikaelAutoClickerTime
        ]);
    }

    if (Raylib.IsKeyDown(KeyboardKey.F1))
    {
        Save.SaveGame(karim.savedata, "./karimSave.txt");
        Save.SaveGame(mikael.savedata, "./mickeSave.txt");
    }
}

// カリムのボートがおおきです。そしてにく。ボートにのりますとでんしゃにおります。ミカエルはにくをたべたい。



