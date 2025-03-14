class autoClickerUpgrade : UpgradeButton{
    public override void Update()
    {
        if (ClickedOn() && buttonReference.clickValue >= currentCost)
        {
            upgradePurchased();
            buttonReference.spawnClicker();
        }
    }

    public override void Draw()
    {
        drawUpgrade();
    }

    public autoClickerUpgrade(ClickerButton buttonReference)
    {
        baseCost = 60;
        costMultiplier = 1.3f;
        upgradeRow = 3;
        upgradeDisplayName = "Auto clicker";
        instantiateUpgrade(buttonReference, upgradeRow);
    }
}