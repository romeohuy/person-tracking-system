using System;
using System.Collections.Generic;
using System.Text;

namespace SrDemo
{
    public class ErrorNum
    {
        public const string success = "1";
        public const string SEND_FAILED = "-4";
        public const string SEND_OK = "0";
        public string fail = "fail";               //命令执行失败            

        //数据库操作错误

        public enum Error
        {
            SQL_OPER_SUCCESS = 0,
            SQL_CONNECT_FAILED = -1,
            SQL_NOT_OPEN = -2,
            SQL_CREAT_TABLES_FAILED = -3,
            SQL_INSERT_MULTI_FAILED = -5,
            SQL_INSERT_LEN_TOOLONG = -4,
            SQL_INSERT_DATA_WRONG = -6
        };

    }
}
