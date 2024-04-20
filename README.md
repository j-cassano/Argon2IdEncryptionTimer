When using Argon2Id to encrypt passwords it is important to consider the amount of time it will take to encrypt the plain text password. This application allows you to change the parameters used in the Argon2Id encryption and time the results.

Below is the recommended approach to select the parameters taken from the Argon2Id documentation found https://www.cryptolux.org/images/0/0d/Argon2.pdf

Recommended parameters
We recommend the following procedure to select the type and the parameters for practical use of Argon2:
1. Select the type y. If you do not know the difference between them or you consider side-channel attacks
as viable threat, choose Argon2i. Otherwise any choice is fine, including optional types.
2. Figure out the maximum number h of threads that can be initiated by each call to Argon2.
3. Figure out the maximum amount m of memory that each call can afford.
4. Figure out the maximum amount x of time (in seconds) that each call can afford.
5. Select the salt length. 128 bits is sufficient for all applications, but can be reduced to 64 bits in the case of space constraints.
6. Select the tag length. 128 bits is sufficient for most applications, including key derivation. If longer keys are needed, select longer tags.
7. If side-channel attacks is a viable threat, enable the memory wiping option in the library call.
8. Run the scheme of type y, memory m and h lanes and threads, using different number of passes t. Figure out the maximum t such that the running time does not exceed x. If it exceeds x even for t = 1, reduce m accordingly.
9. Hash all the passwords with the just determined values m, h, and t.

