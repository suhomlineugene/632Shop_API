using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Products;

[Table("TransmissionOilViscosities")]
public class TransmissionOilViscosity: Entity
{
    public string Name { get; set; }
    
    public List<TransmissionFluid> TransmissionFluids { get; set; }
}