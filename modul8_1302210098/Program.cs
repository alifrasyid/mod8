using System;

class Program
{
    static void Main(string[] args)
    {
        BankTransferConfig btc = new BankTransferConfig();

        if(btc.config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer: ");
        }else if(btc.config.lang == "id")
        {
            Console.WriteLine("masukkan jumlah uang yang akan di-transfer: ");
        }

        int amount = int.Parse(Console.ReadLine());
        int transferFee = amount <= btc.config.transfer.threshold ? btc.config.transfer.low_fee : btc.config.transfer.high_fee;
        int total = amount + transferFee;

        if (btc.config.lang == "en")
        {
            Console.WriteLine($"Tranfer fee = {transferFee}\nTotal amount = {total}");
        }
        else if (btc.config.lang == "id")
        {
            Console.WriteLine($"Biaya transfer = {transferFee}\nTotal amount = {total}");
        }
    }
}