using System.Collections.Generic;

namespace XMDT.Model
{
     public class Information
    {
        public string Id { get; set; }
        public string Pass { get; set; }
        public string TwoFA { get; set; }
        public string Email { get; set; }
        public string PassMail { get; set; }
        public string EmailRecover { get; set; }
    }
    public class SecondaryEmail
    {
        public string Email { get; set; }
        public string Pass { get; set; }
    }

    public class FaceInfo
    {
        public string Id { get; set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public List<string> Works { get; set; }
        public List<string> Educations { get; set; }
        public List<string> Places { get; set; }
        public List<string> OtherNames { get; set; }
        public string RelationShip { get; set; }
        public string Favourite { get; set; }
        public List<string> FamilyMember { get; set; }
        public List<string> Friends { get; set; }

        public FaceInfo()
        {
            Works = new List<string>();
            Educations = new List<string>();
            Places = new List<string>();
            OtherNames = new List<string>();
            FamilyMember = new List<string>();
            Friends = new List<string>();
        }
    }
}
