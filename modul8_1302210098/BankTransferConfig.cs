using System;
using System.IO;
using System.Text.Json;

public class Config
{
    public string lang { get; set; }
    public Transfer transfer { get; set; }
    public List<string> methods { get; set; }
    public Confirmation confirmation { get; set; }    
    
    public Config(string lang , Transfer transfer, List<string> methods, Confirmation confirmation)
    {
        this.lang = lang;
        this.transfer = transfer;
        this.methods = methods;
        this.confirmation = confirmation;
    }
}
public class Transfer
{
    public int threshold { get; set; }
    public int low_fee { get; set; }
    public int high_fee { get; set;}

    public Transfer(int threshold,  int low_fee, int high_fee)
    {
        this.threshold = threshold;
        this.low_fee = low_fee;
        this.high_fee = high_fee;
    }
}
public class Confirmation
{
    public string en { get; set; }
    public string id { get; set; }

    public Confirmation(string en, string id)
    {
        this.en = en;
        this.id = id;
    }
}

public class BankTransferConfig
{
    public Config config;
    public const string FilePath = @"bank_transfer_config.json";

    public BankTransferConfig()
    {
        try
        {
            ReadConfigFile();
        }
        catch (Exception)
        {
            SetDefault();
            WriteConfigFile();
        }
    }
    public Config ReadConfigFile()
    {
        string configJsonData = File.ReadAllText(FilePath);
        config = JsonSerializer.Deserialize<Config>(configJsonData);
        return config;
    }
    public void SetDefault()
    {
        var Methods = new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
        var transferConfig = new Transfer(25000000, 6500, 15000);
        var confirmationConfig = new Confirmation("yes", "ya");
        config = new Config("en", transferConfig, Methods, confirmationConfig);
    }

    public void WriteConfigFile()
    {
        JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(config, options);
        File.WriteAllText(FilePath, jsonString);
    }
}

