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
        upgradeDisplayName = "Additive";
        upgradeRow = 1;
        instantiateUpgrade(buttonReference, upgradeRow);
    }
}