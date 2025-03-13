abstract public class UpgradeButton : ClickableObject
{
    public int upgradeNumber = 1;
    public readonly int textSize = 30;
    public readonly int textOffset = 10;
    public readonly float baseCost = 20;
    public float costMultiplier = 10f;
    public double currentCost;
    public ClickerButton buttonReference;
    public double upgradeCostIncrease(float baseCost, float costMultiplier, int upgradeNumber) 
    => baseCost + (upgradeNumber - 1) * costMultiplier + Math.Pow((upgradeNumber - 1) * costMultiplier, 1.3f);
    
    public void upgradePurchased() // båt
    {
        buttonReference.clickValue -= (float)currentCost;
        upgradeNumber++;
        currentCost = (int)upgradeCostIncrease(baseCost, costMultiplier, upgradeNumber);
    }
/*
    public override void Update()
    {
        if (ClickedOn() && buttonReference.clickValue >= currentCost)
        {

            buttonReference.clickIncrease = upgradeNumber;
        }
    }
*/
/*
    public override void Draw()
    {
        Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, new Color(255, 255, 255));
        Raylib.DrawText($"level: {upgradeNumber}", (int)position.X + textOffset, (int)position.Y + textOffset, textSize, Color.Black);
        Raylib.DrawText($"cost: {currentCost}", (int)position.X + textOffset, (int)position.Y + textSize + textOffset, textSize, Color.Black);
    }
*/
   /* public UpgradeButton(ClickerButton buttonReference)
    {
        currentCost = baseCost;
        size.X = 200 + textOffset;
        size.Y = textSize * 2 + textOffset * 2;
        if (buttonReference.position.X < Raylib.GetScreenWidth() / 2) position.X = 0;
        else position.X = Raylib.GetScreenWidth() - size.X;
        position.Y = Raylib.GetScreenHeight() * 0.2f;
        this.buttonReference = buttonReference;
        gamelist.Add(this);
    }*/
}