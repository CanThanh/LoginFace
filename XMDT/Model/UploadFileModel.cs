namespace XMDT.Model
{
    internal class UploadFileModel
    {
        public bool status { get; set; }
        public int id { get; set; }
        public string url { get; set; }
        public string destination { get; set; }
        public string name { get; set; }
        public string filename { get; set; }
        public string slug { get; set; }
        public string size { get; set; }
        public string type { get; set; }
        public string expiry { get; set; }
        public string session_id { get; set; }
        public string timing { get; set; }
    }
}
