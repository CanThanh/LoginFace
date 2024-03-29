﻿namespace Facebook.Model
{
    public class AccountInfo
    {
        public string Id { get; set; }
        public string Pass { get; set; }
        public string TwoFA { get; set; }
        public string Email { get; set; }
        public string PassMail { get; set; }
        public string EmailRecover { get; set; }
        public string Cookie { get; set; }
        public string EAAAAAY { get; set; }
        public string EAAG { get; set; }
        public string EAAB { get; set; }
        public string DTSG { get; set; }
        public string Proxy { get; set; }
        public string UserAgent { get; set; }
        public string ImgFacePath { get; set; }
        public string ImgIdentityQuanlityPath { get; set; }
        public int TypeProxy { get; set; }
        public string Status { get; set; }
        public string Info { get; set; }
    }
    public class SecondaryEmail
    {
        public string Email { get; set; }
        public string Pass { get; set; }
    }

    public class FaceInfo
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string name { get; set; }
        public string birthday { get; set; }
        public string gender { get; set; }
        public string address { get; set; }

        //public string Email { get; set; }
        //public string FirtName { get; set; }
        //public string LastName { get; set; }
        //public string DateOfBirth { get; set; }
        //public string Gender { get; set; }
        //public string Address { get; set; }
        //public string About { get; set; }
        //public string ImageUrl { get; set; }
        //public List<string> Works { get; set; }
        //public List<string> Educations { get; set; }
        //public List<string> Places { get; set; }
        //public List<string> OtherNames { get; set; }
        //public string RelationShip { get; set; }
        //public string Favourite { get; set; }
        //public List<string> FamilyMember { get; set; }
        //public List<string> Friends { get; set; }

        public FaceInfo()
        {
            //Works = new List<string>();
            //Educations = new List<string>();
            //Places = new List<string>();
            //OtherNames = new List<string>();
            //FamilyMember = new List<string>();
            //Friends = new List<string>();
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}

