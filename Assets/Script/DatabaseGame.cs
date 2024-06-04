using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;

public class DatabaseGame : MonoBehaviour
{
    public static DatabaseGame Instance;
    private string connectionString;
    [SerializeField] private List<GameObject> selectCharacterUIPVPs1;
    [SerializeField] private List<GameObject> selectCharacterUIPVPs2;
    [SerializeField] private List<GameObject> selectCharacterUIChangs;
    [SerializeField] private List<GameObject> uiLocks;
    [SerializeField] private List<GameObject> uiLockLevels;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        connectionString = "Server=localhost;Database=kungfugame;User=root;Charset=utf8";
        OpenConnection();
        for (int i=0; i< selectCharacterUIChangs.Count; i++)
        {
            if (GetUnlock(i) == true)
            {
                Destroy(selectCharacterUIPVPs1[i]);
                Destroy(selectCharacterUIPVPs2[i]);
                Destroy(selectCharacterUIChangs[i]);
                Destroy(uiLocks[i]);
                
            }
            if (GetUnlockLevel(i+1) == true)
            {
                uiLockLevels[i].SetActive(false);
            }
        }
        
    }

    private MySqlConnection connection;

    private void OpenConnection()
    {
        try
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
            Debug.Log("Database connection opened successfully.");
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Failed to open database connection: " + ex.Message);
        }
    }

    public void SetCoinData(int coin)
    {
        string query = "UPDATE Resources SET Coin = @coin";
        using (var command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@coin", coin);
            command.ExecuteNonQuery();
        }
    }   

    public int GetCoinData()
    {
        int coin = 0;
        string query = "SELECT Coin FROM Resources";
        using (var command = new MySqlCommand(query, connection))
        {
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    coin = reader.GetInt32("Coin");
                }
            }
        }
        return coin;
    }

    public void SetUnlockTrue(int id)
    {
        string query = "UPDATE charactergame SET IsUnlock = TRUE WHERE ID = @id";
        using (var command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }

    public bool GetUnlock(int id)
    {
        bool check = false;
        string query = "SELECT IsUnlock FROM charactergame WHERE ID = @id";
        using (var command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@id", id);
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    check = reader.GetBoolean("IsUnlock");
                }
            }
        }
        return check;
    }
    public bool GetUnlockLevel(int level)
    {
        bool check = false;
        string query = "SELECT isplay FROM levelgame WHERE level = @level";
        using (var command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@level", level);
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    check = reader.GetBoolean("isplay");
                }
            }
        }
        return check;
    }
    public void SetLevelTrue(int level)
    {
        string query = "UPDATE levelgame SET isplay = TRUE WHERE level = @level";
        using (var command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@level", level);
            command.ExecuteNonQuery();
        }
    }

    private void OnDestroy()
    {
        if (connection != null && connection.State == ConnectionState.Open)
        {
            connection.Close();
            Debug.Log("Database connection closed.");
        }
    }
}
