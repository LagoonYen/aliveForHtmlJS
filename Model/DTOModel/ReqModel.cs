namespace AliveStoreTemplate.Model.DTOModel
{
    public class AddToCarReqModel
    {
        public string ProductId { get; set; }
        public string ProductSpecId { get; set; }
        public int OrderNum { get; set; }
        public int Price { get; set; }
    }
}
