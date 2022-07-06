public class Conta
{
    public int Codigo { get; }
    public double Saldo { get; private set; }

    public Conta(int codigo)
    {
        Codigo = codigo;
        Saldo = 0.0;
    }

    public void Sacar(double valor)
    {
        Validarvalor(valor);
        VerificarSaldo(valor);
        //if(valor <= 0)
        //{
        // throw new ArgumentException("O saldo é insuficiente para saque!!");
        //}
        Saldo = Saldo - valor;
    }

    public void Depositar(double valor)
    {
        Validarvalor(valor);
        // if(valor > 0)
        //{
        // throw new ArgumentException("O valor de depósito precisa ser maior que zero!!");
       // }
       Saldo  = Saldo + valor;
    }

    public void Transferir(Conta conta, double valor)
    {
        //Validarvalor(valor);
        Sacar(valor);
        conta.Depositar(valor);
        //Saldo = Saldo - valor;
        //if(Saldo > 0)
        //{
       // Saldo = Saldo + valor
        //}
        // throw new ArgumentException("O saldo é insuficiente para Transferência!!");
    }

    private void Validarvalor(double valor)
    {
        if( valor <= 0.0) throw new ArgumentException("O valor deeve ser maior que zero!!");
    }

    private void VerificarSaldo(double valor)
    {
        if(valor > Saldo)
        throw  new ArgumentException("Saldo insuficiente!!");
    }

}