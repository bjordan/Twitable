namespace Twitable.EntityManager.Filter
{
    /// <summary>
    /// Determines the filters that can be applied to a list of users
    /// </summary>
    public class UserFilter
    {
        public string UserName { get; set; }
        public string  Following { get; set; }
    }
}
