using System;

class Program
{
    static void Main(string[] args)
    {
        string[] nums = Console.ReadLine().Split();
        string[] urls = Console.ReadLine().Split();
        Smartphone phone = new Smartphone(nums, urls);

        phone.Call();
        phone.Browse();
    }
}