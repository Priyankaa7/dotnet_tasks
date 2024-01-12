namespace sbtransaction
{
    class SBTransaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public override string ToString()
        {
            return $"Transaction ID: {TransactionId}, Date: {TransactionDate}, Account Number: {AccountNumber}, Amount: {Amount}, Type: {TransactionType}";
        }
    }
}