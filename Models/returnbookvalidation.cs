using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace u19074362_HW5_2._5.Models
{

    [MetadataType(typeof(returnbookeMtaData))]
    public partial class returnbook
    {

        public class returnbookeMtaData
        {



            [DisplayName("ID")]

            public int id { get; set; }



            [DisplayName("Member ID")]
            public Nullable<int> mid { get; set; }

            [DisplayName("Book ID")]
            public string book { get; set; }



            [DisplayName("Elapse ")]
            public Nullable<int> elap { get; set; }



            [DisplayName("Return Date")]
            public Nullable<System.DateTime> returndate { get; set; }



            [DisplayName("Fine")]
            public Nullable<int> fine { get; set; }


        }




    }
}