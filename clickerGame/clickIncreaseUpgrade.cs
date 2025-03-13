public class clickIncreaseUpgrade : UpgradeButton
{

    public override void Update()
    {
        if (ClickedOn() && buttonReference.clickValue >= currentCost)
        {
            upgradePurchased();
            buttonReference.clickIncrease++;
        }
    }

    public override void Draw()
    {
        Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, new Color(255, 255, 255));
        Raylib.DrawText($"level: {upgradeNumber}", (int)position.X + textOffset, (int)position.Y + textOffset, textSize, Color.Black);
        Raylib.DrawText($"cost: {currentCost}", (int)position.X + textOffset, (int)position.Y + textSize + textOffset, textSize, Color.Black);

    }
    public clickIncreaseUpgrade(ClickerButton buttonReference)
    {
        this.buttonReference = buttonReference;
        currentCost = baseCost;
        size.X = 200 + textOffset;
        size.Y = textSize * 2 + textOffset * 2;
        if (buttonReference.position.X < Raylib.GetScreenWidth() / 2) position.X = 0;
        else position.X = Raylib.GetScreenWidth() - size.X;
        position.Y = Raylib.GetScreenHeight() * 0.2f;
        gamelist.Add(this);
    }
}