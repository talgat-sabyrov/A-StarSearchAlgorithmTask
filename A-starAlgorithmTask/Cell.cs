namespace A_starAlgorithmTask
{
    public class Cell
    {
        public int Color { get; set; }
        
        public int I { get; set; }
        public int J { get; set; }

        public Cell NorthCell { get; set; }
        public Cell EastCell { get; set; }
        public Cell SouthCell { get; set; }
        public Cell WestCell { get; set; }
    }
}
