using System;

namespace PruebaService_App.ViewModels
{
    public class PeopleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Height { get; set; }
        public decimal Mass { get; set; }
        public string Gender { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
