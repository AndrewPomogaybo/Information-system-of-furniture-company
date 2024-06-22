namespace ShopMetta.ViewModels
{
    public  class DeleteCommand
    {
        static DataBaseContext _context = new DataBaseContext();

        public  static void Delete<T>(object id) where T : class
        {
            var entity = _context.Set<T>().Find(id);
            if (entity!= null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
        }


    }
}
