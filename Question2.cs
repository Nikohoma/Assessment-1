using System;
using System.Numerics;

namespace Question2;


/// <summary>
/// Class to calculate Sale Transactions
/// </summary>
public class SaleTransaction
{
    #region Declarations and validations
    private string InvoiceNo { get; set; }

    public string invoiceNo
    {
        set
        {
            if (value != null) {InvoiceNo = value;}
        }
    }


    public string CustomerName { get; set; }
    public string ItemName { get; set; }
    private int Quantity { get; set; }

    public int quantity {set
        {
            if (value > 0) {Quantity = value;}
        }
    }
    private decimal PurchaseAmount { get; set; }

    public decimal purchaseAmount {
        set
        {
            if(value > 0) {PurchaseAmount = value;}
        }
    }
    private decimal SellingAmount { get; set; }

    public decimal sellingAmount
    {
        set
        {
            if (value >= 0) {SellingAmount = value;}
        }
    }

    public string ProfitOrLossStatus { get; set; }
    public decimal ProfitOrLossAmount { get; set; }
    public decimal ProfitMarginPercent { get; set; }

    public static SaleTransaction LastTransaction;
    public static bool HasLastTransaction = false;


    #endregion


    #region Constructor
    public SaleTransaction(string InvoiceNo, string CustomerName, string ItemName, int Quantity, decimal PurchaseAmount, decimal SellingAmount)
    {
        this.InvoiceNo = InvoiceNo;
        this.CustomerName = CustomerName;
        this.ItemName = ItemName;
        this.Quantity = Quantity;
        this.PurchaseAmount = PurchaseAmount;
        this.SellingAmount = SellingAmount;
    }
    #endregion


    #region Register
    public void Register()
    {
        if (InvoiceNo == null)
        {
            Console.WriteLine("Invoice Number cannot be null.");
            return;
        }

        if (Quantity <= 0)
        {
            Console.WriteLine("Quantity must be greater than 0.");
            return;
        }

        if (PurchaseAmount <= 0)
        {
            Console.WriteLine("Purchase Amount must be greater than 0.");
            return;
        }

        if (SellingAmount < 0)
        {
            Console.WriteLine("Selling Amount cannot be negative.");
            return;
        }

        Calculate();

        LastTransaction = this;
        HasLastTransaction = true;

        Console.WriteLine("\nTransaction saved successfully.");
        PrintSummary();
    }
    #endregion


    #region Recalculate
    public static void Recalculate()
    {
        if (!HasLastTransaction)
        {
            Console.WriteLine("\n No transaction available. Please create a new transaction first.");
            return;
        }

        LastTransaction.Calculate();
        Console.WriteLine("\n Recalculated successfully.");
        LastTransaction.PrintSummary();
    }
    #endregion


    #region View MEthod
    public static void View()
    {
        if (!HasLastTransaction)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }

        Console.WriteLine("\n----- Last Saved Transaction -----");
        LastTransaction.PrintSummary();
    }
    #endregion


    #region Calculations
    private void Calculate()
    {
        if (SellingAmount > PurchaseAmount)
        {
            ProfitOrLossStatus = "PROFIT";
            ProfitOrLossAmount = SellingAmount - PurchaseAmount;
        }
        else if (SellingAmount < PurchaseAmount)
        {
            ProfitOrLossStatus = "LOSS";
            ProfitOrLossAmount = PurchaseAmount - SellingAmount;
        }
        else
        {
            ProfitOrLossStatus = "BREAK-EVEN";
            ProfitOrLossAmount = 0;
        }

        ProfitMarginPercent = (ProfitOrLossAmount / PurchaseAmount)* 100;
    }
    #endregion


    #region Print
    private void PrintSummary()
    {
        Console.WriteLine($"Status: {ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {Math.Round(ProfitOrLossAmount, 2)}");
        Console.WriteLine($"Profit Margin (%): {Math.Round(ProfitMarginPercent, 2)}");
        Console.WriteLine("------------------------------------------------------\n");
    }
    #endregion
}
