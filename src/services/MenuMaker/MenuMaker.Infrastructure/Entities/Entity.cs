using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Runtime.InteropServices;

namespace MenuMaker.Infrastructure.Entities;

public abstract class Entity<TId> where TId : notnull
{
    [Key] 
    public TId? Id { get; set; }

}

