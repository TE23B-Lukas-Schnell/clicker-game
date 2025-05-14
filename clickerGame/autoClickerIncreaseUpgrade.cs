class AutoClickerIncreaseUpgrade : UpgradeButton
{
    public override void Update()
    {
        if (buttonReference.GetAutoclickerLength() > 0)
        {
            if (ClickedOn() && buttonReference.clickValue >= currentCost)
            {
                upgradePurchased();
                buttonReference.AutoClickerIncreaseUpgrade(upgradeNumber);
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
        placeInList = 4;
        baseCost = 10;
        costMultiplier = 1f;
        upgradeRow = 4;
        upgradeDisplayName = "Gen. add";
        currentCost = GetCurrentCost(baseCost, costMultiplier, upgradeNumber);
        instantiateUpgrade(buttonReference, upgradeRow);
        buttonReference.AutoClickerIncreaseUpgrade(upgradeNumber);
    }
}