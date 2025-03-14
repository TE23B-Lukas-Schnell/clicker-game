class autoClickerUpgrade : UpgradeButton{
    public override void Update()
    {
        if (ClickedOn() && buttonReference.clickValue >= currentCost)
        {
            upgradePurchased();
            buttonReference.SpawnAutoClicker();
        }
    }

    public override void Draw()
    {
        drawUpgrade();
    }

    public autoClickerUpgrade(ClickerButton buttonReference)
    {
        baseCost = 60;
        costMultiplier = 0.8f;
        upgradeRow = 3;
        upgradeDisplayName = "Generators";
        instantiateUpgrade(buttonReference, upgradeRow);
    }
}