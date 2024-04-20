using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

const int DEGREE_OF_PARALLELISM = 8;
const int NUMBER_OF_ITERATIONS = 50;
const int MEMORY_TO_USE_IN_KB = 50000;


var password = "this is the password you're encrypting";       
var stopWatch = new Stopwatch();
var salt = CreateSalt();
stopWatch.Start();
HashPassword(password, salt);                
stopWatch.Stop();
var timeSpan = stopWatch.Elapsed;

var elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
    timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds,
    timeSpan.Milliseconds / 10);
Console.WriteLine("Encryption Time: " + elapsedTime);


byte[] CreateSalt()
{
    var salt = RandomNumberGenerator.GetBytes(16);
    return salt;
}

byte[] HashPassword(string password, byte[] salt)
{
    var passwordBytes = Encoding.UTF8.GetBytes(password);
    var argon2id = new Argon2id(passwordBytes);
    argon2id.Salt = salt;
    argon2id.DegreeOfParallelism = DEGREE_OF_PARALLELISM;
    argon2id.Iterations = NUMBER_OF_ITERATIONS;
    argon2id.MemorySize = MEMORY_TO_USE_IN_KB;
    
    return argon2id.GetBytes(16);
}