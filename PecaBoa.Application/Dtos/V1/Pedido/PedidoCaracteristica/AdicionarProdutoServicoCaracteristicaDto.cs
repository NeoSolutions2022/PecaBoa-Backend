namespace PecaBoa.Application.Dtos.V1.Pedido.PedidoCaracteristica;

public class AdicionarPedidoCaracteristicaDto
{
    public string? Chave { get; set; }
    public string? Valor { get; set; }
    public int PedidoId { get; set; }
}