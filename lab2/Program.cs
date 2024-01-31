using System;
using System.Text;

class MatrixEncryption
{
    static void Main()
    {
        // Вхідна фраза для шифрування та дешифрування
        string originalPhrase = "фразаиз25буквыпример12345";

        // Шифрування вхідної фрази
        string encryptedPhrase = Encrypt(originalPhrase);
        Console.WriteLine("Зашифрована фраза: " + encryptedPhrase);

        // Дешифрування зашифрованої фрази
        string decryptedPhrase = Decrypt(encryptedPhrase);
        Console.WriteLine("Розшифрована фраза: " + decryptedPhrase);
    }

    // Метод для шифрування вхідної фрази
    static string Encrypt(string phrase)
    {
        // Підготовка вхідних даних: видалення пробілів та переведення у верхній регістр
        phrase = phrase.Replace(" ", "").ToUpper();

        // Перевірка довжини фрази (має бути рівно 25 символів)
        if (phrase.Length != 25)
        {
            Console.WriteLine("Фраза повинна містити рівно 25 символів.");
            return string.Empty;
        }

        char[,] matrix = new char[5, 5];
        int index = 0;

        // Заповнюємо матрицю символами з фрази по рядках
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                matrix[i, j] = phrase[index++];
            }
        }

        Console.WriteLine("Заполненная матрица:");

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
 

        // Перемішуємо символи по рядках
        for (int i = 0; i < 5; i++)
        {
            if (i % 2 == 0) // Перевірка на парність рядка
            {
                for (int j = 0; j < 5 / 2; j++)
                {
                    char temp = matrix[i, j];
                    matrix[i, j] = matrix[i, 4 - j];
                    matrix[i, 4 - j] = temp;
                }
            }
        }

        // Перемішуємо символи по стовпцях
        for (int j = 0; j < 5; j++)
        {
            if (j % 2 == 0) // Перевірка на парність стовпця
            {
                for (int i = 0; i < 5 / 2; i++)
                {
                    char temp = matrix[i, j];
                    matrix[i, j] = matrix[4 - i, j];
                    matrix[4 - i, j] = temp;
                }
            }
        }

        Console.WriteLine("Матрица с перестановками:");

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        // Формуємо зашифровану фразу з символів матриці, взятих по стовпцях
        StringBuilder encryptedPhrase = new StringBuilder();
        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < 5; i++)
            {
                encryptedPhrase.Append(matrix[i, j]);
            }
        }

        return encryptedPhrase.ToString();
    }

    // Метод для дешифрування зашифрованої фрази
    static string Decrypt(string encryptedPhrase)
    {
        // Перевірка довжини зашифрованої фрази (має бути рівно 25 символів)
        if (encryptedPhrase.Length != 25)
        {
            Console.WriteLine("Зашифрована фраза повинна містити рівно 25 символів.");
            return string.Empty;
        }

        char[,] matrix = new char[5, 5];
        int index = 0;

        // Заповнюємо матрицю символами з зашифрованої фрази по стовпцях
        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < 5; i++)
            {
                matrix[i, j] = encryptedPhrase[index++];
            }
        }

        // Повертаємо перемішані символи по стовпцях та рядках назад до початкового стану

        // Розшифровуємо по стовпцях
        for (int j = 0; j < 5; j++)
        {
            if (j % 2 == 0) // Перевірка на парність стовпця
            {
                for (int i = 0; i < 5 / 2; i++)
                {
                    char temp = matrix[i, j];
                    matrix[i, j] = matrix[4 - i, j];
                    matrix[4 - i, j] = temp;
                }
            }
        }

        // Розшифровуємо по рядках
        for (int i = 0; i < 5; i++)
        {
            if (i % 2 == 0) // Перевірка на парність рядка
            {
                for (int j = 0; j < 5 / 2; j++)
                {
                    char temp = matrix[i, j];
                    matrix[i, j] = matrix[i, 4 - j];
                    matrix[i, 4 - j] = temp;
                }
            }
        }

        // Формуємо розшифровану фразу з символів матриці, взятих по рядках
        StringBuilder decryptedPhrase = new StringBuilder();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                decryptedPhrase.Append(matrix[i, j]);
            }
        }

        return decryptedPhrase.ToString();
    }
}