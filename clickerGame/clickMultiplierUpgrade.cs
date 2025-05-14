public class clickMultiplierUpgrade : UpgradeButton
{
    public override void Update()
    {
        if (ClickedOn() && buttonReference.clickValue >= currentCost)
        {
            upgradePurchased();
        }
        buttonReference.clickMultiplier = upgradeNumber;
    }

    public override void Draw()
    {
        drawUpgrade();
    }

    public clickMultiplierUpgrade(ClickerButton buttonReference)
    {
        placeInList = 2;
        baseCost = 50;
        costMultiplier = 4f;
        upgradeRow = 2;
        upgradeDisplayName = "Multiplier";
        currentCost = GetCurrentCost(baseCost, costMultiplier, upgradeNumber);
        instantiateUpgrade(buttonReference, upgradeRow);
    }
}