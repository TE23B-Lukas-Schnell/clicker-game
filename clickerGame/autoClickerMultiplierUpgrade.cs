class AutoClickerMultiplierUpgrade : UpgradeButton
{
    public override void Update()
    {
        if (buttonReference.GetAutoclickerLength() > 0)
        {
            if (ClickedOn() && buttonReference.clickValue >= currentCost)
            {
                upgradePurchased();
                buttonReference.AutoClickerMultiplierUpgrade(1);
            }
        }
    }

    public override void Draw()
    {
        if (buttonReference.GetAutoclickerLength() > 0)
            drawUpgrade();
    }

    public AutoClickerMultiplierUpgrade(ClickerButton buttonReference)
    {
        placeInList = 5;
        baseCost = 80;
        costMultiplier = 1.3f;
        upgradeRow = 5;
        upgradeDisplayName = "Gen. multiplier";
        instantiateUpgrade(buttonReference, upgradeRow);
    }
}