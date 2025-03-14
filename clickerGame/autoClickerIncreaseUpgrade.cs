class AutoClickerIncreaseUpgrade : UpgradeButton
{
    public override void Update()
    {
        if (buttonReference.GetAutoclickerLength() > 0)
        {
            if (ClickedOn() && buttonReference.clickValue >= currentCost)
            {
                upgradePurchased();
                buttonReference.AutoClickerIncreaseUpgrade();
            }
        }
    }

    public override void Draw()
    {
        if (buttonReference.GetAutoclickerLength() > 0)
            drawUpgrade();
    }

    public AutoClickerIncreaseUpgrade(ClickerButton buttonReference)
    {
        baseCost = 10;
        costMultiplier = 1.4f;
        upgradeRow = 4;
        upgradeDisplayName = "Gen. add";
        instantiateUpgrade(buttonReference, upgradeRow);
    }
}