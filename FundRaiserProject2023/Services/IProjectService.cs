using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Services
{
    public interface IProjectService
    {
        public void Create();
        public void Read();
        public void Update();
        public void Delete();

        public decimal UpdateAmount(decimal a, decimal b);



    }
}
