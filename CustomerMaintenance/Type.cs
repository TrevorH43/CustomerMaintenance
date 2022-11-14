using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMaintenance
{
    public class Type
    {
        [DisplayName("Type Id")]
        /// <summary>
        /// Type ID - Unique ID for a Customer
        /// </summary>
        public int TypeId { get; set; }

        [DisplayName("Type Description")]
        /// <summary>
        /// Type Description
        /// </summary>
        public string TypeDesc { get; set; }
        public Type()
        {
        }

        /// <summary>
        /// All argument constructor
        /// </summary>
        /// <param name="typeId">Type ID</param>
        /// <param name="typeDesc">Type Description</param>
        public Type(int typeId, string typeDesc)
        {
            this.TypeId = typeId;
            this.TypeDesc = typeDesc;
        }
        /// <summary>
        /// Determines if an object that is passed in is equal to the current
        /// instance based on this current instance's properties
        /// </summary>
        /// <param name="obj">The object to check to see if it is equal</param>
        /// <returns>Returns a boolean value indicating if they are equal</returns>
        public override bool Equals(object obj)
        {
            // Is the object passed in null?  If so, it cannot be equal
            if (obj == null)
                return false;

            // Is the object passed in the same type as this class?  If not,
            // then it cannot be equal
            if (obj.GetType() != typeof(Type))
                return false;

            // Now it is safe to cast the generic object that was passed in
            // as a Type
            Type type = (Type)obj;

            // In order to see if this instance of an object is equal to the object
            // passed in, we need to check the values.
            if (this.TypeId == type.TypeId &&
                this.TypeDesc == type.TypeDesc)
                return true;
            else
                return false;
        }
        public override int GetHashCode() => (TypeId, TypeDesc).GetHashCode();

        /// <summary>
        /// Compares to Type objects for equivalence in a logical comparison
        /// </summary>
        /// <param name="type1">Type object instance 1</param>
        /// <param name="type2">Type object instance 2</param>
        /// <returns>Boolean indicating if the two types are equivalent</returns>
        public static bool operator ==(Type type1, Type type2)
        {
            if (Object.Equals(type1, null))
                if (Object.Equals(type2, null))
                    return true;
                else
                    return false;
            else
                return type1.Equals(type2);
        }

        /// <summary>
        /// Compares to Type objects to determine if they are not equivalent 
        /// in a logical comparison
        /// </summary>
        /// <param name="type1">Type object instance 1</param>
        /// <param name="type2">Type object instance 2</param>
        /// <returns>Boolean indicating if the two types are equivalent</returns>
        public static bool operator !=(Type type1, Type type2)
        {
            // Dependent on the prior implementation of the == operator
            return !(type1 == type2);
        }

    }
}
