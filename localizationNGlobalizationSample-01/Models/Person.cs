using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace localizationNGlobalizationSample_01.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Person
    {
        [Display(Name = "Name", ResourceType = typeof(localizationNGlobalizationSample_Resource.Resources))]
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(localizationNGlobalizationSample_Resource.Resources))]
        public string Name { get; set; }

        [Display(Name = "Age", ResourceType = typeof(localizationNGlobalizationSample_Resource.Resources))]
        [Required(ErrorMessageResourceName = "AgeRequired", ErrorMessageResourceType = typeof(localizationNGlobalizationSample_Resource.Resources))]
        public int Age { get; set; }
    }
}