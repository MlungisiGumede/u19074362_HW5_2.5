using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace u19074362_HW5_2._5.Models
{

    [MetadataType(typeof(issuebookeMtaData))]
    public partial class issuebook
    {

        public class issuebookeMtaData
        {



            [DisplayName("ID")]
            public int id { get; set; }


            [DisplayName("Member ID")]
            public Nullable<int> m_id { get; set; }

            [DisplayName("Book ID")]
            public Nullable<int> book_id { get; set; }



            [DisplayName("Issue Date")]
            public Nullable<System.DateTime> issuedate { get; set; }



            [DisplayName("Return Date")]
            public Nullable<System.DateTime> returndate { get; set; }

        }




    }
}