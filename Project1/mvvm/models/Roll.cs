using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.mvvm.models
{
    public record Roll(
        int Id,
        string Name,
        string Type,
        string ImagePath,
        Traits Traits
        );

    public record Traits (
        string Column1,
        string Column2,
        string Column3,
        string Column4,
        string Origin
        );
    
}
