namespace Tradeio.Client.Models
{
    /// <summary>
    /// Payment system is type of service which handles payment transactions.
    /// This could be blockhain or some fiat payment system like VISA.
    /// </summary>
    public enum PaymentSystem
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// Bitcoin.
        /// </summary>
        Bitcoin = 1,

        /// <summary>
        /// Litecoin.
        /// </summary>
        Litecoin = 2,

        /// <summary>
        /// Ethereum.
        /// </summary>
        Ethereum = 3,

        /// <summary>
        /// Bitcoin Cash.
        /// </summary>
        BitcoinCash = 4,

        /// <summary>
        /// <a href="https://www.openpay.mx">OpenPay.</a>
        /// </summary>
        OpenPay = 5,

        /// <summary>
        /// Omi payment.
        /// </summary>
        Omni = 6,

        /// <summary>
        /// Payment system for transactions to Liquidity pool.
        /// </summary>
        LiquidityPool = 7,
    }
}
