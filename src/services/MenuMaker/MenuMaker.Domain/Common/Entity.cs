using System.ComponentModel.DataAnnotations;

namespace MenuMaker.Domain.Common;

public abstract class Entity<TId> where TId : notnull
{
    [Key] 
    public TId Id { get; set; }
}

