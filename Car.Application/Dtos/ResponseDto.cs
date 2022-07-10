using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Dtos
{
    public  class ResponseDto
    {
        public bool IsSuccess { get; set; }
    }
    public class ResponseDto<T>:ResponseDto where T:class
    {
        public ResponseDto()
        {
            Errors= new List<string>();
        }
      
        public List<string> Errors { get; set; }
        public List<T> Items { get; set; }

    }
}
