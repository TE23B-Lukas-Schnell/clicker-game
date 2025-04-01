class Save
{
    

    public static void SaveGame(int[] content, string filePath)
    {
        string[] saveData = new string[content.Length];

        for (int i = 0; i < content.Length; i++)
        {
            saveData[i] = content[i].ToString();
        }
        File.WriteAllText(filePath, string.Join(",", saveData));
    }


    public static int[] ReadSaveFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);
            string[] stringArray = content.Split(','); // dela upp med kommatecken

            int[] loadedData = new int[stringArray.Length];

            for (int i = 0; i < stringArray.Length; i++)
            {
                if (int.TryParse(stringArray[i], out int number))
                {
                    loadedData[i] = number; // Convert and store in the integer array
                }
                else
                {
                    Console.WriteLine($"Error parsing value at index {i}: {stringArray[i]}");
                    return [0, 0, 0, 0, 0, 0, 0];
                }
            }
            // Console.WriteLine("Loaded Data: " + string.Join(", ", loadedData));
            return loadedData;
        }
        else
        {
            Console.WriteLine("Save file not found.");
            return [0, 0, 0, 0, 0, 0, 0];
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="savedata">
    // the first value should be the amount of båtar/köttar
    // the other numbers are upgrades purchased
    // </param>
    /// <param name="button"></param>
    /// <param name="upgrades">
    // the upgrades needs to be in the order for it to work. the order should be determined by the placeInList variable
    // </param>
    public static void LoadGame(int[] savedata, ClickerButton button, UpgradeButton[] upgrades)
    {
        button.clickValue = savedata[0];
        for (int i = 1; i < upgrades.Length; i++)
        {
            upgrades[i].upgradeNumber = savedata[i];
        }
    }

}