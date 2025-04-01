class AutoClickerTimeUpgrade : UpgradeButton
{
    public override void Update()
    {
        if (buttonReference.GetAutoclickerLength() > 0)
        {
            if (ClickedOn() && buttonReference.clickValue >= currentCost)
            {
                upgradePurchased();
                buttonReference.AutoClickerTimeUpgrade(0.9f,upgradeNumber);
            }
        }
    }

    public override void Draw()
    {
        if (buttonReference.GetAutoclickerLength() > 0)
            drawUpgrade();
    }

    public AutoClickerTimeUpgrade(ClickerButton buttonReference)
    {
        placeInList = 6;
        baseCost = 100;
        costMultiplier = 0.8f;
        upgradeRow = 6;
        upgradeDisplayName = "Gen. speed";
        instantiateUpgrade(buttonReference, upgradeRow);
    }
}