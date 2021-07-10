namespace NHN.WcfClientFactory
{
    /// <summary>
    /// Inneholder konstanter for hostname til ulike miljø for Registerplatformen.
    /// </summary>
    public class Hostnames
    {
        /// <summary>
        /// Utvikling
        /// </summary>
        public const string Utvikling = "ws.utvikling.nhn.no";

        /// <summary>
        /// Test HN
        /// </summary>
        public const string TestHN = "ws.test.nhn.no";
        
        /// <summary>
        /// Test Inet
        /// </summary>
        public const string TestInet = "ws-web.test.nhn.no";

        /// <summary>
        /// QA
        /// </summary>
        public const string Qa = "ws.qa.nhn.no";

        /// <summary>
        /// Prod
        /// </summary>
        public const string Prod = "ws.nhn.no";
    }
}
