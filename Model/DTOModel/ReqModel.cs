namespace AliveStoreTemplate.Model.DTOModel
{
    public class AddToCarReqModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductSpecId { get; set; }
        public string ProductSpecName { get; set; }

        public int OrderNum { get; set; }
        public int Price { get; set; }
        //"ProductId": "a3279dae3b0542b6a353e87d921da95b",
        //"ProductSpecId": "7273d54adaa44bc88bd7fc3c7518c752",
        //"ProductName": "Bose｜SoundSport运动无线蓝牙耳机",
        //"Price": 1409,
        //"ProductSpecName": "蓝色",
        //"storageQuantity": 1,
        //"BuyQuantity": "1",
        //"TotalPrice": 1409
    }

    public class DelFromCarReqModel
    {
        public string ProductId { get; set; }
        public string ProductSpecId { get; set; }
    }

    public class PatchFromCarReqModel : DelFromCarReqModel
    {
        public string Symbol { get; set;}

    }
}
