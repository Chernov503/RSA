
using RSA;
using System.Text;

string alphabet = "АБВГДЕЖЗИКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
int p;
int q;
do
{
    Console.WriteLine("Перемножение p и q должно быть не меньше 32");
    Console.WriteLine("Введите число p");
    p = int.Parse(Console.ReadLine());
    Console.WriteLine("Введите число q");
    q = int.Parse(Console.ReadLine());
    Console.Clear();
} while (q * p < 32);

int n = p * q;
Console.WriteLine($"Число n = {n}");
int d = 2;
bool ObjieDeliteli = true;
do
{
    d++;
    if (d == 10)
    {
        Console.WriteLine("Не подобрано число d, попробуте другие входные данные");
        Console.ReadKey();
        System.Environment.Exit(0);
    }


} while (ProverkaNaObjieDeliteli.CheckCommonDivisors(d, (p - 1) * (q - 1)));

Console.WriteLine($"число d = {d} (не имеет общих делитеей с (p-1)*(q-1) ) = {(p - 1) * (q - 1)}");

int e = 0;
do
{
    e++;
    if (e == 10)
    {
        Console.WriteLine("Не подобрано число e, попробуте другие входные данные");
        Console.ReadKey();
        System.Environment.Exit(0);
    }
} while ((e * 3) % ((p - 1) * (q - 1)) != 1);

Console.WriteLine($"число e = {e} (e * 3 mod {(p - 1) * (q - 1)} = 1)");
Console.WriteLine($"Открытый ключ (e,n) ({e},{n})");
Console.WriteLine($"Секретный ключ (d,n) ({d},{n})");

Console.WriteLine("Введите сообщение");
string message = Console.ReadLine();
int[] MessageToInt = new int[message.Length];
for (int i = 0; i < message.Length; i++)
{
    MessageToInt[i] = alphabet.IndexOf(message[i]);
}

Console.WriteLine("\n");
int[] RSAMessageToInt = new int[MessageToInt.Length];
string RSAMessage;
StringBuilder BuffRSAMessage = new StringBuilder();
for (int i = 0; i < MessageToInt.Length; i++)
{
    
    double buff = (Math.Pow(MessageToInt[i], e));
    RSAMessageToInt[i] = Convert.ToInt32(Convert.ToInt64(buff) % n);
    BuffRSAMessage.Append(alphabet[RSAMessageToInt[i]]);
    Console.WriteLine($"{message[i]} : {MessageToInt[i]} ^ {e} = {buff} ; {buff} mod {n} = {RSAMessageToInt[i]} : {alphabet[RSAMessageToInt[i]]}");

}
RSAMessage = BuffRSAMessage.ToString();
Console.WriteLine($"\nЗашифрованное сообщение {RSAMessage}\n");

string DeRSAMessage;
StringBuilder BuffDeRSAMessage = new StringBuilder();
int[] DeRSAMessageToInt = new int[RSAMessageToInt.Length];
for(int i = 0; i < RSAMessageToInt.Length; i++)
{
    double buff = (Math.Pow(RSAMessageToInt[i], d));
    DeRSAMessageToInt[i] = (int)buff % n;
    BuffDeRSAMessage.Append(alphabet[DeRSAMessageToInt[i]]);
    Console.WriteLine($"{RSAMessage[i]} : {RSAMessageToInt[i]} ^ {d} = {buff} ; {buff} mod {n} = {DeRSAMessageToInt[i]} : {alphabet[DeRSAMessageToInt[i]]}");
}
DeRSAMessage = BuffDeRSAMessage.ToString();
Console.WriteLine($"\nРасшифрованное сообщение {DeRSAMessage}");
Console.ReadLine();


