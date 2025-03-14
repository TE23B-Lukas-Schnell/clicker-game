abstract public class UpgradeButton : ClickableObject
{
    public int upgradeNumber = 1;
    public string upgradeDisplayName = "";
    public readonly int textSize = 30;
    public readonly int textOffset = 10;
    public int upgradeRow;

    public float baseCost = 20;
    public float costMultiplier = 10f;
    public double currentCost;
    public ClickerButton buttonReference;
    public double upgradeCostIncrease(float baseCost, float costMultiplier, double latestCost)
    => + baseCost + Math.Pow((costMultiplier *  latestCost), 1.1f);
    

    public void upgradePurchased() // båt
    {
        buttonReference.clickValue -= (float)currentCost;
        upgradeNumber++;
        currentCost = (int)upgradeCostIncrease(baseCost, costMultiplier, currentCost);
    }

    public void instantiateUpgrade(ClickerButton buttonReference, int upgradeRow)
    {
        currentCost = baseCost;
        size.X = 200 + textOffset;
        size.Y = textSize * 2 + textOffset * 2;
        position.Y = Raylib.GetScreenHeight() * upgradeRow / 5;

        if (buttonReference.position.X < Raylib.GetScreenWidth() / 2) position.X = 0;
        else position.X = Raylib.GetScreenWidth() - size.X;
        this.buttonReference = buttonReference;
        gamelist.Add(this);
    }
    public void drawUpgrade()
    {
        Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, new Color(255, 255, 255));

        if (showHitboxes()) Raylib.DrawRectangleRec(GetHitbox(), Color.Red);
        Raylib.DrawText($"{upgradeDisplayName}", (int)position.X + textOffset, (int)position.Y - textOffset - textSize, textSize, Color.Black);
        Raylib.DrawText($"level: {upgradeNumber}", (int)position.X + textOffset, (int)position.Y + textOffset, textSize, Color.Black);
        Raylib.DrawText($"cost: {currentCost}", (int)position.X + textOffset, (int)position.Y + textSize + textOffset, textSize, Color.Black);
    }
}