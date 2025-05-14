public class clickIncreaseUpgrade : UpgradeButton
{
    public override void Update()
    {
        if (ClickedOn() && buttonReference.clickValue >= currentCost)
        {
            upgradePurchased();
        }
         buttonReference.clickIncrease = upgradeNumber;
    }

    public override void Draw()
    {
        drawUpgrade();
    }

    public clickIncreaseUpgrade(ClickerButton buttonReference)
    {
        placeInList = 1;
        baseCost = 20;
        costMultiplier = 1f;
        upgradeDisplayName = "Additive";
        upgradeRow = 1;
        currentCost = GetCurrentCost(baseCost, costMultiplier, upgradeNumber);
        instantiateUpgrade(buttonReference, upgradeRow);
        // buttonReference.clickIncrease = upgradeNumber;
    }
}