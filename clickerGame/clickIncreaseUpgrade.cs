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
        drawUpgrade();
    }

    public clickIncreaseUpgrade(ClickerButton buttonReference)
    {
        placeInList = 1;
        baseCost = 20;
        costMultiplier = 0.8f;
        upgradeDisplayName = "Additive";
        upgradeRow = 1;
        instantiateUpgrade(buttonReference, upgradeRow);
    }
}