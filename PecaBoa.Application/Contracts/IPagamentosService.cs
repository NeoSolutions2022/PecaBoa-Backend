namespace PecaBoa.Application.Contracts;

public interface IPagamentosService
{
    Task PagarComCartao(string token);
}