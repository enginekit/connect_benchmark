﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace MySqlTest
{
    public class TestSet1 : MySqlTester
    {
        [Test]
        public static void T_OpenAndClose()
        {
            int n = 100;
            long total;
            long avg;
            var connStr = GetMySqlConnString();
            Test(n, TimeUnit.Ticks, out total, out avg, () =>
            {

                var conn = new MySqlConnection(connStr);
                conn.Open();
                //connList.Add(conn);
                conn.Close();
            });
        }

        static string GetMySqlConnString()
        {
            string h = "127.0.0.1";
            string u = "root";
            string p = "root";
            string db = "test";
            return "server=" + h + ";uid=" + u + ";pwd=" + p + ";database=" + db;

        }
    }
}