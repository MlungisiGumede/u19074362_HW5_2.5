using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace u19074362_HW5_2._5.Models
{

    [MetadataType(typeof(categoryMetaData))]
    public partial class category_table
    {

        
        public class categoryMetaData
        {
            [DisplayName("Category Name")]
            public string catname { get; set; }



            [DisplayName("Status")]
            public string status { get; set; }

        }


    }
}