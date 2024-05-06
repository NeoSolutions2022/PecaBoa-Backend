namespace PecaBoa.Application.Dtos.V1.Pedido.PedidoCaracteristica;

public class PedidoCaracteristicaDto
{
    public int Id { get; set; }
    public string? Chave { get; set; }
    public string? Valor { get; set; }
    public int PedidoId { get; set; }
}