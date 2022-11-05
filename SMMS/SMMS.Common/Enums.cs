using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.Common
{
    public class Enums
    {
        public enum ProductCatogery
        {
            Furniture = 1,
            Vegitable = 2,
            Toys = 3
        };

        public enum QunitiType
        {
            KG = 1,
            Item = 2,
            Liter = 3
        };

        public enum UserStatus
        {
            Active = 1,
            Inactive = 2,
            Block = 3
        };

        public enum UserLoginResult
        {
            ValidUser = 1,
            InactiveUser = 2,
            InvalidPassword = 3,
            InvalidUser = 4
        };

        public enum UserType
        {
            staff = 1,
            customer = 2
        };

        public enum EmployeeType
        {
            HRManager = 1,
            StockManager = 2,
            SalesManager = 3,
            Cashier = 4,
            Helper = 5,
            Admin = 9

        };

        public enum Department
        {
            HR = 1,
            IT = 2,
            Finance = 3,
            Production = 4
        };

        public enum LeaveType
        {
            Casual = 1,
            Medical = 2,
            Anual = 3,
            Short = 4,
            NoPay = 5
        };

        public enum LeaveMode
        {
            Full = 1,
            Half = 2
        };

        public enum LeaveHalf
        {
            Morning = 1,
            Evening = 2
        };
        public enum LeaveIsApprove
        {
            Pendeing = 0,
            Approved = 1
        };

        public enum Months
        {
            All = 0,
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        };
    }
}
