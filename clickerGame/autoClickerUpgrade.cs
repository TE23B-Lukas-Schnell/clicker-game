class autoClickerUpgrade : UpgradeButton
{
    public override void Update()
    {
        if (ClickedOn() && buttonReference.clickValue >= currentCost)
        {
            upgradePurchased();
            buttonReference.SpawnAutoClicker(1);
        }
    }

    public override void Draw()
    {
        drawUpgrade();
    }

    public autoClickerUpgrade(ClickerButton buttonReference)
    {
        placeInList = 3;
        baseCost = 60;
        costMultiplier = 1;
        upgradeRow = 3;
        upgradeDisplayName = "Generators";
        currentCost = GetCurrentCost(baseCost, costMultiplier, upgradeNumber);
        instantiateUpgrade(buttonReference, upgradeRow);
        buttonReference.SpawnAutoClicker(upgradeNumber);
    }
}