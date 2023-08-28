﻿using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveDirectorySynchronization
{
    public class ADUserDetail

    {

        private String _firstName;

        private String _middleName;

        private String _lastName;

        private String _loginName;

        private String _loginNameWithDomain;

        private String _streetAddress;

        private String _city;

        private String _state;

        private String _postalCode;

        private String _country;

        private String _homePhone;

        private String _extension;

        private String _mobile;

        private String _fax;

        private String _emailAddress;

        private String _title;

        private String _physicalDeliveryOfficeName;

        private String _company;

        private String _manager;

        private String _managerName;

        private String _department;

        private String _EmployeeCode;

        private String _employeeType;
        
        private String _Enable;

        private String _UserAccountControl;

        private String _DisplayName;

        public String DisplayName
        {

            get { return _DisplayName; }

        }
        public String Department

        {

            get { return _department; }

        }

        public bool UserAccountControl
        {

            get {
                    if (_UserAccountControl != null)
                    {
                        int asd = Convert.ToInt32(_UserAccountControl);
                        return !Convert.ToBoolean(asd & 0x0002);
                    }
                    return false;
            }

        }
 

        public String FirstName

        {

            get { return _firstName; }

        }

        public String Employeecode
        {
            get { return _EmployeeCode; }
        }

        public String MiddleName

        {

            get { return _middleName; }

        }

 

        public String LastName

        {

            get { return _lastName; }

        }

 

        public String LoginName

        {

            get { return _loginName; }

        }

 

        public String LoginNameWithDomain

        {

            get { return _loginNameWithDomain; }

        }

 

        public String StreetAddress

        {

            get { return _streetAddress; }

        }

 

        public String City

        {

            get { return _city; }

        }

 

        public String State

        {

            get { return _state; }

        }

 

        public String PostalCode

        {

            get { return _postalCode; }

        }

 

        public String Country

        {

            get { return _country; }

        }

 

        public String HomePhone

        {

            get { return _homePhone; }

        }

 

        public String Extension

        {

            get { return _extension; }

        }

 

        public String Mobile

        {

            get { return _mobile; }

        }

 

        public String Fax

        {

            get { return _fax; }

        }

 

        public String EmailAddress

        {

            get { return _emailAddress; }

        }

 

        public String Title

        {

            get { return _title; }

        }

        public String PhysicalDeliveryOfficeName
        {

            get { return _physicalDeliveryOfficeName; }

        }

        public String Company

        {

            get { return _company; }

        }

 

        public ADUserDetail Manager

        {

            get

            {

                if (!String.IsNullOrEmpty(_managerName))

                {

                    ActiveDirectoryHelper ad = new ActiveDirectoryHelper();

                    return ad.GetUserByFullName(_managerName);

                }

                return null;

            }

        }

        public String Enable
        {

            get { return _Enable; }

        }

        public String ManagerName

        {

            get { return _managerName; }

        }
        public String EmployeeType
        {

            get { return _employeeType; }

        }

 

 

        private ADUserDetail(DirectoryEntry directoryUser)

        {

 

            String domainAddress;

            String domainName;

            _firstName = GetProperty(directoryUser, ADProperties.FIRSTNAME);

            _middleName = GetProperty(directoryUser, ADProperties.MIDDLENAME);

            _lastName = GetProperty(directoryUser, ADProperties.LASTNAME);

            _loginName = GetProperty(directoryUser, ADProperties.LOGINNAME);

            _UserAccountControl = GetProperty(directoryUser, ADProperties.USERACCOUNTCONTROL);

            _DisplayName = GetProperty(directoryUser, ADProperties.DISPLAYNAME);

            String userPrincipalName = GetProperty(directoryUser, ADProperties.USERPRINCIPALNAME);

            if (!string.IsNullOrEmpty(userPrincipalName))

            {

                 domainAddress = userPrincipalName.Split('@')[1];

            }

            else

            {

                domainAddress = String.Empty; 

            }

 

            if (!string.IsNullOrEmpty(domainAddress))

            {

                domainName = domainAddress.Split('.').First();

            }

            else

            {

                domainName = String.Empty;

            }

            _loginNameWithDomain = String.Format(@"{0}\{1}", domainName, _loginName);

            _streetAddress = GetProperty(directoryUser, ADProperties.STREETADDRESS);

            _city = GetProperty(directoryUser, ADProperties.CITY);

            _state = GetProperty(directoryUser, ADProperties.STATE);

            _postalCode = GetProperty(directoryUser, ADProperties.POSTALCODE);

            _country = GetProperty(directoryUser, ADProperties.COUNTRY);

            _company = GetProperty(directoryUser, ADProperties.COMPANY);

            _department = GetProperty(directoryUser, ADProperties.DEPARTMENT);

            _homePhone = GetProperty(directoryUser, ADProperties.HOMEPHONE);

            _extension = GetProperty(directoryUser, ADProperties.EXTENSION);

            _mobile = GetProperty(directoryUser, ADProperties.MOBILE);

            _fax = GetProperty(directoryUser, ADProperties.FAX);

            _emailAddress = GetProperty(directoryUser, ADProperties.EMAILADDRESS);

            _title = GetProperty(directoryUser, ADProperties.TITLE);

            _physicalDeliveryOfficeName = GetProperty(directoryUser, ADProperties.PHYSICALDELIVERYOFFICENAME);

            _EmployeeCode = GetProperty(directoryUser, ADProperties.EMPLOYEECODE);

            _manager = GetProperty(directoryUser, ADProperties.MANAGER);

            _Enable = GetProperty(directoryUser, ADProperties.ENABLE);

            _employeeType = GetProperty(directoryUser, ADProperties.EMPLOYEEType);

            if (!String.IsNullOrEmpty(_manager))

            {

                String[] managerArray = _manager.Split(',');

                _managerName = managerArray[0].Replace("CN=", "");

            }

        }

 

 

        private static String GetProperty(DirectoryEntry userDetail, String propertyName)

        {

            if (userDetail.Properties.Contains(propertyName))

            {

                return userDetail.Properties[propertyName][0].ToString();

            }

            else

            {

                return string.Empty;

            }

        }

 

        public static ADUserDetail GetUser(DirectoryEntry directoryUser)

        {

            return new ADUserDetail(directoryUser);

        }

    }

}


