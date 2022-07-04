/*
 * Palalau Alexandru
 * Allows to encrypt and decrypt data
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Security.Cryptography;
using System;

public class MD5 : MonoBehaviour
{
    public const string HASH_KEY = "NCD_GAME";
    /// <summary>
    /// Encrypt Data using MD5
    /// </summary>
    /// <param name="inputData">String data to encrypt</param>
    /// <returns>Return the encrypted data</returns>
    public static string MD5Encrypt(string inputData)
    {
        string hasKey = HASH_KEY; //You can use any string here as haskey
        byte[] bData = UTF8Encoding.UTF8.GetBytes(inputData);

        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        TripleDESCryptoServiceProvider tripalDES = new TripleDESCryptoServiceProvider
        {
            Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hasKey)),
            Mode = CipherMode.ECB
        };

        ICryptoTransform trnsfrm = tripalDES.CreateEncryptor();
        byte[] result = trnsfrm.TransformFinalBlock(bData, 0, bData.Length);

        //Debug.Log("Encrypt " + Convert.ToBase64String(result));
        return Convert.ToBase64String(result);
    }

    /// <summary>
    /// Decrypt Data who was encrypted using MD5
    /// </summary>
    /// <param name="inputData">Decrypt string data who were encrypted whit MD5</param>
    /// <returns>Return decrypted data</returns>
    public string MD5Decrypt(string inputData)
    {
        string hasKey = HASH_KEY; //You can use any string here as haskey
        byte[] bData = Convert.FromBase64String(inputData);

        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        TripleDESCryptoServiceProvider tripalDES = new TripleDESCryptoServiceProvider
        {
            Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hasKey)),
            Mode = CipherMode.ECB
        };

        ICryptoTransform trnsfrm = tripalDES.CreateDecryptor();
        byte[] result = trnsfrm.TransformFinalBlock(bData, 0, bData.Length);

        //Debug.Log("Decrypt " + UTF8Encoding.UTF8.GetString(result));
        return UTF8Encoding.UTF8.GetString(result);
    }
    
}
