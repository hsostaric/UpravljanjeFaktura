using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZadatakFaktureMVC5.Enums
{
    public enum PDV
    {

        [Display(Name = "PDV - 25%")]
        PDV25 = 1,
        [Display(Name = "PDV - 17%")]
        PDV17 = 2,
        [Display(Name = "PDV - 10%")]
        PDV10 = 3
    }
}