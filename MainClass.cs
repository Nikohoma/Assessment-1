using MediSureClinic;
using Question2;


public class MainClass
{
    public static void Main()
    {
        
        #region Question1 Menu Console

        // Static storage initialisation

        PatientBill lastBill = null;
        bool hasLastBill = false;
        

        #region Console Menu
        Console.WriteLine("Enter your choice: ");


        //  Infinite While loop to keep the menu console running and exit only using the option.

        while (true)
        {
            Console.WriteLine("\n==================MediSure Clinic Billing==================");
            Console.WriteLine("1. Create New Bill (Enter Patient Details)");
            Console.WriteLine("2. View Last Bill");
            Console.WriteLine("3. Clear Last Bill");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");

            string choice = Console.ReadLine();

            // Create Instance with all the inputs and store them in lastBill, and set hasLastBill to true.
            if (choice == "1")
            {
                Console.WriteLine("Enter Bill Id: ");
                string billId = Console.ReadLine();

                Console.WriteLine("Enter Patient Name: ");
                string? Name = Console.ReadLine();

                Console.WriteLine("Is the Patient Insured? (Y/N): ");
                string? Insurance = Console.ReadLine();
                bool insurance = (Insurance != null && Insurance.ToUpper() == "Y");

                Console.WriteLine("Enter Consultation Fee: ");
                decimal Fees = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter Lab Charges: ");
                decimal labCharges = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter Medicine Charges: ");
                decimal medCharges = decimal.Parse(Console.ReadLine());

                lastBill = new PatientBill(billId, Name, insurance, Fees, labCharges, medCharges);
                lastBill.Register();
                hasLastBill = true;
            }


            // Print the inputs if hasLastBill is not null
            else if (choice == "2")
            {
                if (!hasLastBill || lastBill == null)
                {
                    Console.WriteLine("No bill available. Please create a new bill first.");
                }
                else
                {
                    Console.WriteLine("\n===== Last Bill Details =====");
                    Console.WriteLine($"Bill Id: {lastBill.BillId}");
                    Console.WriteLine($"Patient Name: {lastBill.PatientName}");
                    Console.WriteLine($"Insured: {lastBill.HasInsurance}");
                    Console.WriteLine($"Gross Amount: {lastBill.GrossAmount:F2}");
                    Console.WriteLine($"Discount Amount: {lastBill.DiscountAmount:F2}");
                    Console.WriteLine($"Final Payable: {lastBill.FinalPayable:F2}");
                }
            }


            // Clearing the lastBill and hasLastBill 
            else if (choice == "3")
            {
                lastBill = null;
                hasLastBill = false;
                Console.WriteLine("Last bill cleared.");
            }


            // Exiting
            else if (choice == "4")
            {
                Console.WriteLine("Thank You, Application closed normally.");
                break;
            }

            // Illegal input handling
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    #endregion

    #endregion


        #region Question2 Menu Console

        // Infinite While loop for the Menu Console, Can only exit the console with the option.
        while (true)
        {
            Console.WriteLine("================== QuickMart Traders ==================");
            Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
            Console.WriteLine("2. View Last Transaction");
            Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: \n");

            string choice = Console.ReadLine();
            Console.WriteLine();

            // Inputs for Instance and calling Register()
            if (choice == "1")
            {
                Console.Write("Enter Invoice No: ");
                string invoice = Console.ReadLine();
                Console.Write("Enter customeromer Name: ");
                string customer = Console.ReadLine();
                Console.Write("Enter Item Name: ");
                string item = Console.ReadLine();
                Console.Write("Enter Quantity: ");
                int qty = int.Parse(Console.ReadLine());
                Console.Write("Enter Purchase Amount (total): ");
                decimal purchase = decimal.Parse(Console.ReadLine());
                Console.Write("Enter Selling Amount (total): ");
                decimal selling = decimal.Parse(Console.ReadLine());
                SaleTransaction transaction = new SaleTransaction(invoice, customer, item, qty, purchase, selling);

                transaction.Register();
            }

            // Calling View Method to check if any transaction is available.
            else if (choice == "2")
            {
                SaleTransaction.View();
            }

            // Calling the Recalculate Method
            else if (choice == "3")
            {
                SaleTransaction.Recalculate();
            }

            // Exiting using break
            else if (choice == "4")
            {
                Console.WriteLine("Thank You, Application closed normally.");
                break;
            }

            // Invalid option input handling
            else
            {
                Console.WriteLine("Invalid option. Press only 1-4.");
            }

            Console.WriteLine();
        }

        #endregion







    }

}