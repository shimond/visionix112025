namespace HttpAndMore.Services;

public record PaymentRequest(decimal Amount, string Currency, string PaymentMethod);

public interface IPaymentClient
{
    Task<PaymentRequest> Pay(decimal amount, string currency, string paymentMethod);
}

public class PaymentClient(HttpClient client) : IPaymentClient
{

    public async Task<PaymentRequest> Pay(decimal amount, string currency, string paymentMethod)
    {
        var paymentRequest = new PaymentRequest(amount, currency, paymentMethod);
        var response = await client.PostAsJsonAsync("/pay", paymentRequest);
        response.EnsureSuccessStatusCode();
        var paymentResponse = await response.Content.ReadFromJsonAsync<PaymentRequest>();
        return paymentResponse!;
    }


}
