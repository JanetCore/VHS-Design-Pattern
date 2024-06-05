using System;

namespace VHS.Core.Models
{
    public abstract class BaseModel
    {
        public Guid Uid { get; set; }

        protected BaseModel()
        {
            Uid = Guid.NewGuid();
        }
    }
}