using System.Runtime.Serialization;

namespace NHN.DtoContracts.ServiceBus.Data
{
    /// <summary>
    /// Kilder som tilbyr hendelser på topic eksternt
    /// </summary>
    [DataContract(Namespace = Namespaces.ServiceBusManagerV2)]
    public enum SubscriptionEventSource
    {
        AddressRegister,
        Resh,
        Hpr,
        Lsr
    }
}
