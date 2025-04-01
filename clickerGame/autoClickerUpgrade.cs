class autoClickerUpgrade : UpgradeButton{
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
        costMultiplier = 0.8f;
        upgradeRow = 3;
        upgradeDisplayName = "Generators";
        instantiateUpgrade(buttonReference, upgradeRow);
    }
}