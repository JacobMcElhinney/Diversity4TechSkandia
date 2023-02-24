namespace DefensiveProgramming.Models
{
    internal partial class Customer : Information
    {
        public Guid Id { get; set; }
        public override string? Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string? Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string? City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string? Region { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string? PostalCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string? Country { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string? Phone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
