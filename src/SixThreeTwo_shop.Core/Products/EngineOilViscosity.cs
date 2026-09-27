using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Products;

[Table("EngineOilViscosities")]
public class EngineOilViscosity: Entity
{
    public string Name { get; set; }
    
    public List<MotorOil> EngineOils { get; set; }
}