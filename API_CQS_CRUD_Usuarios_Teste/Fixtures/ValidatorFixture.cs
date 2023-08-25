namespace API_CQS_CRUD_Usuarios_Teste.Fixtures
{
    public class ValidatorFixture<T> where T : class, new()
    {
        public ValidatorFixture()
        {
            Instance = new T();
        }

        public T Instance { get; }
    }
}
