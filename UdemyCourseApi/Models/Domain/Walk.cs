﻿namespace UdemyCourseApi.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LengthInKm { get; set; }

        public string ? WalImageUrl {  get; set; }    

        public Guid DifficultyId { get; set; }  

        public Difficulty Difficulty { get; set; }  

        public Guid RegionId { get; set; }  

        public Region Region { get; set; }  
    }
}