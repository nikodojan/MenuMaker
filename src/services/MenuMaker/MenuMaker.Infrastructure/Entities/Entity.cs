using System.ComponentModel.DataAnnotations;

namespace MenuMaker.Infrastructure.Entities;

public abstract class Entity<TId> where TId : notnull
{
    [Key] 
    public TId Id { get; set; }
}

