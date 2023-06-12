namespace BankAPP.Interfaces.Account_Interface
{
    public interface IAccountServices
    {
        void CollectAccountNo();
        void TransferMoney();
        void WithdrawAmount();
        void GetStatment();
        void Details();
        void DisplayBalance();
    }
}
