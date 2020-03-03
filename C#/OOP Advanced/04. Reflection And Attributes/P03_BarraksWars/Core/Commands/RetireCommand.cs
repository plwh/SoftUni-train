using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Commands
{
    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository) 
            : base(data)
        {
            this.Repository = repository;
        }

        protected IRepository Repository
        {
            get { return this.repository; }
            set { this.repository = value; }
        }

        public override string Execute()
        {
            var typeOfUnit = Data[1];

            try
            {
                this.Repository.RemoveUnit(typeOfUnit);
                return $"{typeOfUnit} retired!";
            }
            catch (ArgumentException ae)
            {
                return ae.Message;
            }
        }
    }
}
