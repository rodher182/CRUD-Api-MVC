using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDApiMVC.Models
{
    [MetadataType(typeof(Movies.Valida))]
    public partial class Movies
    {
        sealed class Valida
        {
            [Required]
            public string Name { get; set; }
        }
    }
}