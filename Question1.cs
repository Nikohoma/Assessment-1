using System;

namespace MediSureClinic
{
    public class PatientBill
    {
        #region Fields
        string billId;
        decimal consultationFee;
        decimal labCharges;
        decimal medicineCharges;
        #endregion
        

        #region Properties and Validations
        public string BillId
        {
            get;
            set
            {
                if (BillId == null)
                    billId = value;
                else
                    Console.WriteLine("Bill Id cannot be null");
            }
        }

        public string PatientName { get; set; }
        public bool HasInsurance { get; set; }

        public decimal ConsultationFee
        {
            get;
            set
            {
                if (value > 0)
                    consultationFee = value;
                else
                    Console.WriteLine("Consultation fee must be more than 0");
            }
        }

        public decimal LabCharges
        {
            get => labCharges;
            set
            {
                if (value >= 0)
                    labCharges = value;
                else
                    Console.WriteLine("Lab Charges cannot be less than 0");
            }
        }

        public decimal MedicineCharges
        {
            get => medicineCharges;
            set
            {
                if (value >= 0)
                    medicineCharges = value;
                else
                    Console.WriteLine("Medicine Charges cannot be < 0");
            }
        }

        public decimal GrossAmount { get;set; }
        public decimal DiscountAmount { get;set; }
        public decimal FinalPayable { get;set; }
        public decimal LastBill { get;set; }
        public bool HasLastBill { get;set; }
        #endregion

        #region Constructor
        public PatientBill(string billId, string patientName, bool hasInsurance, decimal consultationFee, decimal labCharges, decimal medicineCharges)
        {
            BillId = billId;
            PatientName = patientName;
            HasInsurance = hasInsurance;
            ConsultationFee = consultationFee;
            LabCharges = labCharges;
            MedicineCharges = medicineCharges;
        }
        #endregion

        /// <summary>
        /// Method for Calculation
        /// </summary>
        public void Register()
        {
            GrossAmount = ConsultationFee + LabCharges + MedicineCharges;

            if (HasInsurance) {DiscountAmount = GrossAmount * 0.10m;}
            else {DiscountAmount = 0;}

            FinalPayable = GrossAmount - DiscountAmount;

            LastBill = FinalPayable;
            HasLastBill = true;

            Console.WriteLine("\nBill Created Successfully.\n");
            Console.WriteLine($"Gross Amount   : {GrossAmount}");
            Console.WriteLine($"Discount Amount: {DiscountAmount}");
            Console.WriteLine($"Final Payable  : {FinalPayable}\n");
        }

        /// <summary>
        /// Clear Method.
        /// </summary>
        public void Clear()
        {
            LastBill = 0;
            HasLastBill = false;
            Console.WriteLine("Last bill cleared. \n");
        }
    }
}
