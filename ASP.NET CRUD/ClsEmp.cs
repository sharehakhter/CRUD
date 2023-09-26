using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DataAccess;

namespace WebApp
{
    public class ClsEmp
    {
        private int _EmpId;
        private string _Event;
        private string _FirstName;
        private string _LastName;
        private string _Address;
        private string _CNICNo;
        private string _PhoneNo;
        private string _JobTitle;
        private string _DOB;
        private string _CurrentSalary;
        private string _SearchWord;
        private string _UserName;
        private string _Password;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public int EmpId
        {
            get { return _EmpId; }
            set { _EmpId = value; }
        }

        public string Event
        {
            get { return _Event; }
            set { _Event = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public string CNICNo
        {
            get { return _CNICNo; }
            set { _CNICNo = value; }
        }
        public string PhoneNo
        {
            get { return _PhoneNo; }
            set { _PhoneNo = value; }
        }
        public string JobTitle
        {
            get { return _JobTitle; }
            set { _JobTitle = value; }
        }
        public string DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }
        public string CurrentSalary
        {
            get { return _CurrentSalary; }
            set { _CurrentSalary = value; }
        }

        public string SearchWord
        {
            get { return _SearchWord; }
            set { _SearchWord = value; }
        }
    }
}