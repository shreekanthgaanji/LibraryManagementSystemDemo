using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Book
    {
        public int BookId { get; set; }
        public String Title { get;set; }
        public String AuthorName { get; set; }

        public Enum Catagory { get; set; }

        public int quantity { get; set; }

    }

    class Lend
    {
        public int LendersId { get; set; }
        public int userId { get; set; }
        public int BookId { get; set; }

    }

    enum Catagory
    {
       Technical =0,
       Spiritual =1,
       Magic =2,
       Science =3,
       Fiction = 4
    }

    class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}
