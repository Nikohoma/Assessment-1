using System;

namespace MediSureClinic
{
    public class PatientBill
    {
        #region Declarations and Validations
        private string billId;
        private decimal consultationFee;
        private decimal labCharges;
        private decimal medicineCharges;

        public string BillId
        {
            get { return billId; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    billId = value;
                else
                    Console.WriteLine("Bill Id cannot be null");
            }
        }

        public string PatientName { get; set; }
        public bool HasInsurance { get; set; }

        public decimal ConsultationFee
        {
            get { return consultationFee; }
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
            get { return labCharges; }
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
            get { return medicineCharges; }
            set
            {
                if (value >= 0)
                    medicineCharges = value;
                else
                    Console.WriteLine("Medicine Charges cannot be < 0");
            }
        }

        public decimal GrossAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalPayable { get; set; }
        public decimal LastBill { get; set; }
        public bool HasLastBill { get; set; }
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


        public void Register()
        {
            GrossAmount = ConsultationFee + LabCharges + MedicineCharges;

            if (HasInsurance)
                DiscountAmount = GrossAmount * 0.10m;
            else
                DiscountAmount = 0;

            FinalPayable = GrossAmount - DiscountAmount;

            LastBill = FinalPayable;
            HasLastBill = true;

            Console.WriteLine("\n Bill Created Successfully.\n");
            Console.WriteLine($"Gross Amount   : {GrossAmount}");
            Console.WriteLine($"Discount Amount: {DiscountAmount}");
            Console.WriteLine($"Final Payable  : {FinalPayable}\n");
        }

        public void Clear()
        {
            LastBill = 0;
            HasLastBill = false;
            Console.WriteLine("Last bill cleared. \n");
        }
    }
}
