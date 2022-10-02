using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace u19074362_HW5_2._5.Models
{

    [MetadataType(typeof(bookMetaData))]
    public partial class book
    {



        public class bookMetaData
        {



            [DisplayName("Book Name")]
            public string bname { get; set; }

            [DisplayName("Category ID")]
            public Nullable<int> cat_id { get; set; }

            [DisplayName("Author ID")]
            public Nullable<int> auth_id { get; set; }

            [DisplayName("Publisher ID")]
            public Nullable<int> pub_id { get; set; }

            [DisplayName("Content")]
            public string contents { get; set; }

            [DisplayName("Pages")]
            public Nullable<int> pages { get; set; }

            [DisplayName("Edition")]
            public string edition { get; set; }


        }

    }
}