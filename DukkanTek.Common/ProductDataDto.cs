namespace DukkanTek.Common;
public record ProductDataDto(int count,string status);

public enum ProductStatus
{
    sold =1,
    inStock =2,
    damaged = 3
}