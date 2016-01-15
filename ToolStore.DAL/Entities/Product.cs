namespace ToolStore.DAL.Entities
{
    /// <summary>
    /// Incapsulates information about product
    /// </summary>
    public class Product
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public string PicturePath
        {
            get { return string.Format("Content/Photos/product_{0}.jpg", Id); }
        }
    }
}