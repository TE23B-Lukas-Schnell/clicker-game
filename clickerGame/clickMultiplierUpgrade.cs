public class clickMultiplierUpgrade : UpgradeButton
{
    public override void Update()
    {
        if (ClickedOn() && buttonReference.clickValue >= currentCost)
        {
            upgradePurchased();
            buttonReference.clickMultiplier++;
        }
    }

    public override void Draw()
    {
        drawUpgrade();
    }

    public clickMultiplierUpgrade(ClickerButton buttonReference)
    {
        baseCost = 50;
        costMultiplier = 2f;
        upgradeRow = 2;
        upgradeDisplayName = "Multiplier";
        instantiateUpgrade(buttonReference, upgradeRow);
    }
}