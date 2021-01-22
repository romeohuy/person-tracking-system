using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SrDemo
{
    // 功率 （设置，获取）
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct power_t
    {
        public byte loop;				// 开闭环（开环（默认状态）：0x00;闭环：0x01）
        public byte read;				// 读功率（取值范围：5~30 dBm）
        public byte write;				// 写功率（取值范围：5~30 dBm）
    }

    /************************************************************************
    温度×100，转换为十六进制后，负数则取补码
    例子：当前模块温度为 -40℃，-40*100 = -4000 = 0xFO60,
		    则 temp_msb = 0xF0;temp_lsb = 0x60
    ************************************************************************/
    // 模块的温度
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct temperature_t
    {
        public byte temp_msb;			// 温度值的高8位
        public byte temp_lsb;			// 温度值的低8位
    }


    // 模块外接的GPIO
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct gpio_t
    {
        public byte gpio;					// bit[0]:gpio1。bit[1]:gpio2。...bit[7]:gpio8
        public byte gpio_level;				// 对应每个gpio的高低电平
    }


    //说明：开启状态：fastid_switch为0x01；关闭状态：fastid_switch为0x00。
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct fastid_t
    {
        public byte fastid_switch;			// fastid 的开关。
    }

    //说明：开启状态：carrier_switch为0x01；关闭状态：carrier_switch为0x00。
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct carrier_t
    {
        public byte carrier_switch;			// carrier 的开关。
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct Boot_t
    {
        public byte bootAuto_switch;			// carrier 的开关。
    }



    /*
    读写器频率区域
    China1  0x01 
    China2  0x02 
    Europe  0x03 
    USA		0x04 
    Korea	0x05 
    Japan	0x06
    */
    // 读写器频率区域
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct frequency_region_t
    {
        public byte save_setting;			// 保存设置标志.说明：保存设置标志为0时，不保存设置，为1时保存设置。
        public byte region;					// 读写器频率区域
    }


    // 频点
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct output_frequency_t
    {
        public char frequency_num;			// 频点个数
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = global.OUTPUT_FREQUENCY_NUM)]
        public float[] frequency;	            // 输出频率
    }


    // 设置模块通讯波特率
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct baud_rate_t
    {
        public byte rate_type;				// 波特率 类型
    }


    // 天线 （设置，获取）
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct antenna_t
    {
        public byte ants;				// 天线号（bit0：ant1；bit1：ant2；... bit7：ant8）
    }



    /************************************************************************
    说明：设置天线工作时间只适用四端口模块，Data0，Data1为天线1的工作
    时间（单位ms，范围30ms—60000ms），Data2，Data3为天线2的工作时间（单
    位ms，范围30ms—60000ms），Data4，Data5为天线3的工作时间（单位ms，
    范围30ms—60000ms），Data6，Data7为天线4 的工作时间（单位ms，范围
    30ms—60000ms），Data8，Data9为等待时间（单位ms，范围0ms—60000ms），

    如果是使用部分天线，则只需使能需要的天线号就可以了

    例：设置天线1的工作时间为100ms，天线2工作时间150ms，天线3工作
    时间314ms，天线4工作时间30ms，等待时间10000ms。
    命令：BB 1F 0A 00 64 00 96 01 3A 00 1E 27 10 B3 0D 0A
    ************************************************************************/
    // 天线工作时间及等待时间
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct antenna_time_t
    {
        public byte com_type;			// 命令类型（0x1F,0x9F;0x20,0xA0）
        public byte ant1_msb;			// 天线1的工作时间值的高8位
        public byte ant1_lsb;			// 天线1的工作时间值的低8位
        public byte ant2_msb;			// 天线2的工作时间值的高8位
        public byte ant2_lsb;			// 天线2的工作时间值的低8位
        public byte ant3_msb;			// 天线3的工作时间值的高8位
        public byte ant3_lsb;			// 天线3的工作时间值的低8位
        public byte ant4_msb;			// 天线4的工作时间值的高8位
        public byte ant4_lsb;			// 天线4的工作时间值的低8位
        public byte wait_msb;			// 等待时间值的高8位
        public byte wait_lsb;			// 等待时间值的低8位
    }


    // 标签epc数据
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct epc_t
    {
        public byte pc_msb;
        public byte pc_lsb;
        public char epc_len;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = global.PACKET_128)]
        public byte[] epc;	    // PACKET_MID

    }


    /************************************************************************
    说明：RSSI以补码的形式表示，共16bit，为实际值×10。如-65.7dBm，则
    RSSI=FD6F = -657;
    ************************************************************************/
    // 查询标签EPC 
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct query_epc_t
    {
        public byte com_type;	    // 命令类型（0x16,0x96）
        public epc_t epc;

        public byte rssi_msb;
        public byte rssi_lsb;
        public byte ant_id;		    // 天线号
        public int tid_len;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = global.PACKET_128)]
        public byte[] tid;            // PACKET_MID
    }


    /************************************************************************
    说明：AP为标签的访问密码；PC+EPC过滤查询需要，若不过滤，则必须
    全部置零；MB为用户需要查询的数据的bank号；SA为需查询的数据的起始地
    址，单位为字；DL为需查询的数据长度，单位为字
    ************************************************************************/
    // 读取，写入标签数据
    // [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)] 
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct tags_data_t
    {
        public byte com_type;				// 命令类型（0x19,0x99;0x1A,0x9A）
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = global.PASSWORD_LEN)]
        public byte[] password;	            // 密码,PASSWORD_LEN
        public epc_t epc;
        public byte mem_bank;				// 要读写的标签的内存区
        public byte start_addr_msb;			// 要读写的标签的内存区的开始位置的高8位
        public byte start_addr_lsb;			// 要读写的标签的内存区的开始位置的低8位
        public byte data_len_msb;			// 要读写的数据长度的高8位，单位为字
        public byte data_len_lsb;			// 要读写的数据长度的低8位，单位为字
        public byte ant_id;					// 天线号
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = global.PACKET_MAX)]
        public byte[] data;		            // 要读写的数据, PACKET_MAX
    }


    /************************************************************************
    说明：循环查询标签EPC次数范围为1~0xFFFF，为0时，表示永久查询标
    签EPC 
    例：循环查询标签EPC次数为100次
    命令：BB 17 02 00 64 7D 0D 0A 
    ************************************************************************/
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct multi_query_epc_t
    {
        public byte com_type;			// 命令类型（0x17,0x97;0x18,0x98）
        public byte query_total_msb;	// 查询次数的高8位
        public byte query_total_lsb;	// 查询次数的低8位
        public byte packet_num;			// 完整的数据包的个数

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = global.RECV_PACKET_NUM)]
        public query_epc_t[] tags_epc;	// 标签的EPC相关信息,RECV_PACKET_NUM
    }




    // 写标签的EPC
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct tags_epc_t
    {
        public byte com_type;				// 命令类型 WRITE_TAGS_EPC
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = global.PACKET_128)]
        public byte[] epc;		                    // PACKET_128
        public byte epc_len;

        public tags_epc_t(int e_len)
        {
            com_type = 0;
            epc = new byte[e_len];
            epc_len = 0;
        }
    }

    class sr_api
    {
        /***********************************************************************************/
        /**  Tên chức năng:   Set_Power                                                           */
        /** Chức năng: Chức năng này được sử dụng để đặt công suất làm việc của mô-đun                                          */
        /*  loop:  Tham số là 8 bit không dấu, tham số là thiết lập chức năng vòng lặp đóng mở của mô-đun。		    */
        /*  read:  Tham số này là 8 bit không dấu, tham số là thiết lập công suất đọc mô-đun。				*/
        /*  write: Tham số này là 8 bit không dấu, tham số là thiết lập công suất ghi mô-đun。				*/
        /*  Giá trị trả về: Nếu cài đặt thành công, nó trả về 0, nếu không thành công, nó trả về một số âm.    */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Set_Power(byte loop, byte read, byte write);


        /***********************************************************************************/
        /**  Tên chức năng:   Get_Power                                                           */
        /**  Đặc trưng: Chức năng này được sử dụng để có được sức mạnh làm việc của mô-đun   */
        /*  loop:  Tham số không có dấu 8 bit, tham số là để có được chức năng vòng mở và vòng đóng của mô-đun。			*/
        /*  read:  Tham số là 8 bit không dấu, tham số là để lấy công suất đọc mô-đun。				*/
        /*  write: Tham số là 8 bit không dấu, và tham số là để lấy công suất ghi mô-đun。				*/
        /*  Giá trị trả về: Nếu cài đặt thành công, nó trả về 0, nếu không thành công, nó trả về một số âm.                */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Get_Power(ref byte loop,ref byte read,ref byte write);

        /***********************************************************************************/
        /**  Tên chức năng:   Set_Gpio_level             */
        /**  Đặc trưng: Chức năng này được sử dụng để đặt trạng thái GPIO của mô-đun  */
        /*   gpio:  Đặt bit GPIO, bit0-> GPIO1 bit1-> GPIO2 bit2-> GPIO3。			*/
        /*   level: Đặt trạng thái GPIO, 0 mức thấp 1 mức cao							*/
        /*   Giá trị trả về: Nếu cài đặt thành công, nó trả về 0, nếu không thành công, nó trả về một số âm.     */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Set_Gpio_level(byte g_data, byte level);

        /***********************************************************************************/
        /**  Tên chức năng:   Get_Gpio_level                                                      */
        /**  Chức năng: Chức năng này được sử dụng để nhận trạng thái GPIO của mô-đun  */
        /*  gpio:   Đặt bit GPIO，bit0 ->GPIO1 bit1->GPIO2 bit2->GPIO3。			*/
        /*  level:  Đặt trạng thái GPIO, 0 mức thấp 1 mức cao */
        /*  Giá trị trả về: trả về 0 nếu thành công, trả về âm nếu không thành công   */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Get_Gpio_level(byte g_data,ref byte level);

        /***********************************************************************************/
        /** Tên hàm: Get_hardware_version */
        /** Chức năng: Chức năng này được sử dụng để lấy thông tin phiên bản phần cứng */
        /* phiên bản: số phiên bản thu được */
        /* Giá trị trả về: trả về 0 nếu thành công, trả về âm nếu không thành công     */
        /***********************************************************************************/
        [DllImport("api_dll.dll")]
        public extern static int Get_hardware_version(byte[] version);

        /***********************************************************************************/
        /**  Tên hàm: Get_firmware_version * /
        / ** Chức năng: Chức năng này được sử dụng để lấy thông tin phiên bản mô-đun         */
        /*  version:   Số phiên bản đã nhận						*/
        /*   Giá trị trả về: Nếu cài đặt thành công, nó trả về 0, nếu không thành công, nó trả về một số âm                  */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Get_firmware_version(byte[] version);

        /***********************************************************************************/
        /** Tên hàm: Set_output_frequency * /
        /** Chức năng: Chức năng này được sử dụng để đặt tần số đầu ra RF của mô-đun         */
        /*  count:   Đặt số lần nhảy tần số đầu ra RF */
        /* dữ liệu: Đặt tần số nhảy tần đầu ra RF tính bằng KHz */
        /* Số lượng giá trị dữ liệu dựa trên sự kết hợp, tần số đầu ra RF là thực tế * 1000 */
        /* Giá trị trả về: trả về 0 nếu thành công, trả về âm nếu không thành công   */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Set_output_frequency(byte count, int[] data);

        /***********************************************************************************/
        /**  Tên hàm: Get_output_frequency */
        /**  Đặc trưng:     Chức năng này được sử dụng để thu được tần số đầu ra RF của mô-đun * /
        /* count: Nhận số lần nhảy tần số đầu ra RF */
        /* dữ liệu: Nhận tần số nhảy tần đầu ra RF */
        /* Giá trị trả về: trả về 0 nếu thành công, trả về âm nếu không thành công                                         */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Get_output_frequency(ref byte count, int[] data);

        /***********************************************************************************/
        /**  Tên hàm: Set_Work_Antanne * /
        / ** Chức năng: Chức năng này được sử dụng để đặt ăng-ten hoạt động của mô-đun * /
        / * kiến: Đặt ăng-ten hoạt động của mô-đun * /
        / * con kiến ​​* /
        / * Ant8 Ant7 Ant6 Ant5 Ant4 Ant3 Ant2 Ant1 * /
        / * Giá trị trả về: trả về 0 nếu thành công, trả về âm nếu không thành công                                        */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Set_Work_Antanne(byte ants);


        /***********************************************************************************/
        /**  Tên hàm: Get_Work_Antanne * /
        / ** Chức năng: Chức năng này được sử dụng để lấy ăng-ten hoạt động của mô-đun * /
        / * kiến: Nhận ăng-ten làm việc của mô-đun * /
        / * Giá trị trả về: trả về 0 nếu thành công, trả về âm nếu không thành công                                        */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)] //2015-03-10-00
        public extern static int Get_Work_Antanne(ref byte ants);

        /***********************************************************************************/
        /**  Tên hàm: Set_gen2_param * /
        / ** Chức năng: Chức năng này được sử dụng để thiết lập các tham số thuật toán Q * /
        / * q_data: Đặt thuật toán Q: 0 nghĩa là thuật toán Q cố định, 1 nghĩa là thuật toán Q động * /
        / * startQ cài đặt: 0 đến 15 * /
        / * Cài đặt MinQ: 0 đến 15 * /
        / * Cài đặt MaxQ: 0 đến 15 * /
        / * Giá trị trả về: trả về 0 nếu thành công, trả về âm nếu không thành công                                         */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Set_gen2_param(byte q_data, byte start_q, byte min_q, byte max_q,byte select_q,byte session_q,byte target_q);

        /***********************************************************************************/
        /** Tên hàm: Get_gen2_param * /
        / ** Chức năng: Hàm này được sử dụng để lấy tham số thuật toán Q * /
        / * q_data: Đặt thuật toán Q: 0 nghĩa là thuật toán Q cố định, 1 nghĩa là thuật toán Q động * /
        / * startQ cài đặt: 0 đến 15 * /
        / * Cài đặt MinQ: 0 đến 15 * /
        / * Cài đặt MaxQ: 0 đến 15 * /
        / * Giá trị trả về: trả về 0 nếu thành công, trả về âm nếu không thành công                                        */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Get_gen2_param(ref byte q_data, ref byte start_q, ref byte min_q, ref byte max_q,ref byte select_q, ref byte session_q, ref byte target_q);

        /***********************************************************************************/
        /**  Tên hàm: Set_frequency * /
        / ** Chức năng: Chức năng này được sử dụng để đặt vùng tần số của đầu đọc * /
        / * region: Đặt vùng tần số của đầu đọc
                Trung Quốc1 0x01
                Trung Quốc2 0x02
                Châu Âu 0x03
                Hoa Kỳ 0x04
                Hàn Quốc 0x05
                Nhật Bản 0x06 * /
        / * Giá trị trả về: trả về 0 nếu thành công, trả về âm nếu không thành công                                         */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Set_frequency(byte saving,byte region);

        /***********************************************************************************/
        /**  Tên hàm: Get_frequency * /
        / ** Chức năng: Chức năng này được sử dụng để lấy vùng tần số của đầu đọc * /
        / * region: Lấy vùng tần số của đầu đọc				
				        China1 0x01
				        China2 0x02
				        Europe 0x03
				        USA 0x04
				        Korea 0x05
				        Japan 0x06														   */
        /*   Giá trị trả về: Nếu cài đặt thành công, nó trả về 0, nếu không thành công, nó trả về một số âm.       */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Get_frequency(ref byte region);

        
        /***********************************************************************************/
        /**  Tên hàm: Set_antenna_carrier * /
        / ** Chức năng: Chức năng này được sử dụng để đặt sóng mang ăng-ten * /
        / * nhà cung cấp dịch vụ: đặt sóng mang ăng-ten * /
        / * Giá trị trả về: trả về 0 nếu thành công, trả về âm nếu không thành công                                         */                            
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Set_antenna_carrier(byte carrier);

        /***********************************************************************************/
        /**  Tên hàm: Get_antenna_carrier * /
        / ** Chức năng: Chức năng này được sử dụng cho nhà cung cấp dịch vụ không dây * /
        / * nhà cung cấp dịch vụ: đặt sóng mang ăng-ten * /
        / * Giá trị trả về: trả về 0 nếu thành công, trả về âm nếu không thành công                                         */                            
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Get_antenna_carrier(ref byte carrier);


        /***********************************************************************************/
        /**  Tên hàm: Set_rf_link_profile * /
        / ** Chức năng: Chức năng này được sử dụng để đặt sóng mang ăng-ten * /
        / * rf_link: đặt cấu hình liên kết rf * /
        / * Giá trị trả về: trả về 0 nếu thành công, trả về âm nếu không thành công                                         */                            
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Set_rf_link_profile(byte rf_link);

        /***********************************************************************************/
        /**  Tên hàm: Get_rf_link_profile * /
        / ** Chức năng: Chức năng này được sử dụng để thiết lập hồ sơ liên kết rf * /
        / * rf_link: Nhận hồ sơ liên kết rf * /
        / * Giá trị trả về: trả về 0 nếu thành công, trả về âm nếu không thành công                                         */                            
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Get_rf_link_profile(ref byte rf_link);

        /***********************************************************************************/
        /**  Tên hàm: Set_register_status * /
        / ** Chức năng: Chức năng này được sử dụng để thiết lập trạng thái thanh ghi * /
        / * reg_type: đặt loại thanh ghi * /
        / * addr: đặt địa chỉ đăng ký * /
        / * data: thiết lập dữ liệu thanh ghi * /
        / * Giá trị trả về: trả về 0 nếu thành công, trả về âm nếu không thành công                                         */                            
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Set_register_status(byte reg_type,uint addr,uint data);

        /***********************************************************************************/
        /**  Tên hàm: Get_register_status * /
        / ** Chức năng: Chức năng này được sử dụng để lấy trạng thái đăng ký * /
        / * reg_type: kiểu đăng ký * /
        / * addr: địa chỉ đăng ký * /
        / * dữ liệu: Nhận dữ liệu đăng ký * /
        / * Giá trị trả về: trả về 0 nếu thành công, trả về âm nếu không thành công                                         */                            
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Get_register_status(byte reg_type,uint addr,ref uint data);

        /***********************************************************************************/
        /**  Tên hàm: Sigle_Query_Tags_Epc * /
        / ** Chức năng: Chức năng này được sử dụng để đọc dữ liệu EPC của thẻ trong một lần duy nhất * /
        / * epc: Mô-đun trả về dữ liệu EPC của thẻ * /
        / * tid: Trả lại dữ liệu TID của thẻ * /
        / * epc_len: Độ dài của dữ liệu EPC của thẻ do mô-đun trả về * /
        / * tid_len: Trả về độ dài của dữ liệu TID của thẻ * /
        / * rssi: đọc giá trị cường độ tín hiệu của giá trị thực của thẻ * 10 * /
        / * ant_id: đọc số ăng-ten của thẻ * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại								               */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Sigle_Query_Tags_Epc(byte[] epc, ref byte epc_len, byte[] tid, ref byte tid_len, ref ushort rssi, ref byte ant_id);

        /***********************************************************************************/
        /**  Tên hàm: Multi_Query_Tags_Epc * /
        / ** Chức năng: Chức năng này được sử dụng để đọc dữ liệu EPC của thẻ nhiều lần * /
        / * đếm: chu kỳ đọc nhãn lần 00 chu kỳ cố định 100 chu kỳ một trăm lần * /
        / * packnum: trả về tổng số EPC * /
        / * rev_num: Trả về số lượng EPC * /
        / * epc: trả về dữ liệu EPC * /
        / * tid: trả về dữ liệu tid * /
        / * rssi: Trả về cường độ tín hiệu của thẻ truy vấn dưới dạng giá trị thực × 10 * /
        / * data_from_ant: Trả về số ăng-ten của truy vấn EPC * /
        / * Giá trị trả về: trả về 0 nếu thành công, trả về âm nếu không thành công               */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Get_Multi_Query_Tags_Epc_Data(ref multi_query_epc_t multi_epc);

        /***********************************************************************************/
        /**  Tên hàm: Multi_Query_Tags_Epc * /
        / ** Chức năng: Chức năng này được sử dụng để bắt đầu đọc các thẻ trong một vòng lặp * /
        / ** lần: số lần truy vấn nhãn 0 nghĩa là đọc nhãn theo chu kỳ * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại			   */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Multi_Query_Tags_Epc(UInt32 times);

        /***********************************************************************************/
        /**  Tên hàm: Stop_Multi_Query_Tags_Epc * /
        / ** Chức năng: Chức năng này được sử dụng để dừng đọc các thẻ trong một vòng lặp * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại				   */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Stop_Multi_Query_Tags_Epc();

        /***********************************************************************************/
        /**  Tên hàm: read_data * /
        / ** Chức năng: Chức năng này được sử dụng để đọc dữ liệu thẻ * /
        / * password: mật khẩu để đọc nhãn * /
        / * filter_bak: loại bộ lọc * /
        / * filter_len: độ dài dữ liệu lọc * /
        / * filter_data: lọc dữ liệu * /
        / * memory_bank: Ngân hàng có thẻ cần được truy vấn * /
        / * start_addr: địa chỉ bắt đầu được truy vấn * /
        / * recv_len: Độ dài của truy vấn * /
        / * recv_data: Trả lại dữ liệu của thẻ truy vấn * /
        / * data_from_ant: Trả lại số ăng-ten của thẻ truy vấn * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại     */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int read_data(uint password, byte filter_bak, ushort filter_len, byte[] filter_data, byte memory_bank, ushort start_addr, ushort recv_len, byte[] recv_data,ref byte data_from_ant);

        /***********************************************************************************/
        /**  Tên hàm: write_data * /
        / ** Chức năng: Chức năng này được sử dụng để ghi dữ liệu nhãn * /
        / * mật khẩu: Mật khẩu để ghi dữ liệu nhãn * /
        / * filter_bak: ghi loại bộ lọc nhãn * /
        / * filter_len: ghi độ dài dữ liệu bộ lọc nhãn * /
        / * filter_data: lọc dữ liệu * /
        / * memory_bank: Ngân hàng cần ghi thẻ * /
        / * start_addr: địa chỉ bắt đầu được viết * /
        / * data_len: Độ dài của nhãn được ghi * /
        / * write_buffer: dữ liệu được ghi vào thẻ * /
        / * data_from_ant: Trả lại số ăng-ten được ghi vào thẻ * 
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại     */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int write_data(uint password, byte filter_bak, ushort filter_len, byte[] filter_data, byte memory_bank, ushort start_addr, ushort data_len, byte[] write_buffer, ref byte data_from_ant);

        /***********************************************************************************/
        /** Tên hàm: lock_tag */
        /** Chức năng: Chức năng này được sử dụng để khóa nhãn */
        /* mật khẩu: khóa nhãn mật khẩu */
        /* filter_bak: loại bộ lọc nhãn khóa */
        /* filter_len: độ dài dữ liệu bộ lọc nhãn khóa */
        /* filter_data: lọc dữ liệu của nhãn bị khóa */
        /* mask: bit0: USER bit1: TID bit2: EPC bit3: truy cập bit4: kill */
        /* hoạt động: */
        /* Viết mật khẩu Khóa vĩnh viễn Mô tả */
        /* 0 0 Ở trạng thái mở hoặc trạng thái được bảo vệ, ngân hàng bộ nhớ liên quan có thể được ghi. */
        /* 0 1 Ở trạng thái mở hoặc trạng thái được bảo vệ, ngân hàng bộ nhớ liên quan có thể được ghi vĩnh viễn hoặc ngân hàng bộ nhớ liên quan có thể không bao giờ bị khóa. */
        /* 1 0 Ở trạng thái được bảo vệ, ngân hàng bộ nhớ liên quan có thể được ghi nhưng không được ghi ở trạng thái mở */
        /* 1 1 Không thể ghi vào ngân hàng bộ nhớ liên quan ở bất kỳ trạng thái nào. */
        /* data_from_ant: Trả lại số ăng-ten của thẻ bị khóa */
        /* Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại                                             */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int lock_tag(uint password, byte filter_bak, ushort filter_len, byte[] filter_data, byte mask, byte action,ref byte data_from_ant);

        /***********************************************************************************/
        /** Tên hàm: kill_tag * /
        / ** Chức năng: Chức năng này được sử dụng để tiêu diệt các thẻ * /
        / * password: mật khẩu của kill tag * /
        / * filter_bak: loại bộ lọc nhãn khóa * /
        / * filter_len: độ dài dữ liệu bộ lọc nhãn khóa * /
        / * filter_data: lọc dữ liệu của nhãn bị khóa * /
        / * data_from_ant: Trả lại số ăng-ten của thẻ bị khóa * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại                                             */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int kill_tag(uint password, byte filter_bak, ushort filter_len, byte[] filter_data, ref byte data_from_ant);

        /***********************************************************************************/
        /**  Tên hàm: Get_module_tempether * /
        / ** Chức năng: Chức năng này được sử dụng để truy vấn nhiệt độ hiện tại của mô-đun * /
        / * nhiệt độ: Trả về nhiệt độ hiện tại của mô-đun. Nhiệt độ × 100, sau khi chuyển đổi sang hệ thập lục phân, số âm sẽ được bổ sung * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại                                         */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Get_module_temperature(ref ushort temperature);

        /***********************************************************************************/
        /**  Tên hàm: Set_multi_query_tags_interval * /
        / ** Chức năng: Chức năng này đặt thời gian làm việc và thời gian gián đoạn của nhãn truy vấn tuần hoàn * /
        / * work_time: Đặt thời gian làm việc của nhãn truy vấn tuần hoàn (0000-FFFF) * /
        / * khoảng thời gian: Đặt khoảng thời gian của nhãn truy vấn tuần hoàn (0000-FFFF) * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại * /
        / * Lưu ý: Chỉ áp dụng cho thiết bị một kênh. Khi tất cả các cài đặt đều bằng 0, có nghĩa là tìm thẻ liên tục                    */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Set_multi_query_tags_interval(ushort work_time, ushort interval);

        /***********************************************************************************/
        /**  Tên hàm: Get_multi_query_tags_interval * /
        / ** Chức năng: Chức năng này lấy thời gian làm việc và thời gian gián đoạn của nhãn truy vấn hình tròn * /
        / * work_time: Lấy thời gian làm việc của nhãn truy vấn tuần hoàn (0000-FFFF) * /
        / * khoảng thời gian: Nhận khoảng thời gian của nhãn truy vấn tuần hoàn (0000-FFFF) * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại * /
        / * Lưu ý: Chỉ áp dụng cho thiết bị một kênh. Thời gian, đơn vị là ms									   */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Get_multi_query_tags_interval(ref ushort work_time, ref ushort interval);


        /***********************************************************************************/
        /**  Tên hàm: Set_antenna_worktime_and_waittime * /
        / ** Chức năng: Chức năng này đặt thời gian làm việc và thời gian gián đoạn của nhãn truy vấn tuần hoàn * /
        / * ant1_work_time: Đặt thời gian làm việc của anten 1 (đơn vị ms, dải 30ms — 60000ms) * /
        / * ant2_work_time: Đặt thời gian làm việc của anten 2 (đơn vị ms, phạm vi 30ms — 60000ms) * /
        / * ant3_work_time: Đặt thời gian làm việc của anten 3 (đơn vị ms, phạm vi 30ms — 60000ms) * /
        / * ant4_work_time: Đặt thời gian làm việc của anten 4 (đơn vị ms, dải 30ms — 60000ms) * /
        / * wait_time: Đặt thời gian chờ của ăng-ten (đơn vị ms, dải 0ms — 60000ms) * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại * /
        / * Lưu ý: Chỉ áp dụng cho thiết bị đa kênh。									                   */
        /***********************************************************************************/ //2015-03-10－00
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Set_antenna_worktime_and_waittime(ushort ant1_work_time, ushort ant2_work_time, ushort ant3_work_time, ushort ant4_work_time, ushort wait_time);

        /***********************************************************************************/
        /**  Tên hàm: Get_antenna_worktime_and_waittime * /
        / ** Chức năng: Chức năng này thu được thời gian làm việc của anten và thời gian chờ * /
        / * ant1_work_time: Thời gian làm việc của anten 1 thời gian (đơn vị ms, dải 30ms — 60000ms) * /
        / * ant2_work_time: Nhận thời gian làm việc của anten 2 (đơn vị ms, phạm vi 30ms — 60000ms) * /
        / * ant3_work_time: Nhận thời gian làm việc của ăng-ten 3 (đơn vị ms, phạm vi 30ms — 60000ms) * /
        / * ant4_work_time: Nhận thời gian làm việc của anten 4 (đơn vị ms, phạm vi 30ms — 60000ms) * /
        / * wait_time: Nhận thời gian chờ của ăng-ten (đơn vị ms, dải 0ms — 60000ms) * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại * /
        / * Lưu ý: Chỉ áp dụng cho thiết bị đa kênh。									                   */
        /***********************************************************************************/ //2015-03-10-00
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Get_antenna_worktime_and_waittime(ref ushort ant1_work_time, ref ushort ant2_work_time, ref ushort ant3_work_time, ref ushort ant4_work_time, ref ushort wait_time);

        /***********************************************************************************/
        /**  Tên hàm: Set_fastid * /
        / ** Chức năng: Hàm này được sử dụng để thiết lập Fastid * /
        / * fastid: đặt fastid, bật FastID thành 0x01, tắt FastID thành 0x00. * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại * /
        / * Lưu ý: FastID chỉ hợp lệ cho các thẻ của các giống cụ thể。										   */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Set_fastid(byte fastid);
        //-------------------------------------------------------------------
        /***********************************************************************************/
        /**  Tên hàm: Set_TagFocus * /
        / ** Chức năng: Chức năng này được sử dụng để đặt tagFocus * /
        / * tiêu điểm: đặt tagFocus, bật tagFocus thành 0x01, tắt tagFocus thành 0x00. * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại * /
        / * Lưu ý: tagFocus chỉ hợp lệ cho các loại thẻ cụ thể。									   */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Set_TagFocus(byte focus); //20150413

        //-------------------------------------------------------------------

        /***********************************************************************************/
        /**  Tên hàm: Get_fastid * /
        / ** Hàm: Hàm này được sử dụng để lấy Fastid * /
        / * fastid: Lấy fastid, bật FastID thành 0x01, tắt FastID thành 0x00. * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại * /
        / * Lưu ý: FastID chỉ hợp lệ cho các thẻ của các giống cụ thể。										   */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Get_fastid(ref byte fastid);
        //-----------------------------------------------------------------------------
        /***********************************************************************************/
        /**  Tên hàm: Get_tagFocus * /
        / ** Hàm: Hàm này được sử dụng để lấy tagFocus * /
        / * tiêu điểm: Nhận tagFocus, mở tagFocus là 0x01 và đóng tagfocus là 0x00. * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại * /
        / * Lưu ý: tagFocus chỉ hợp lệ cho các loại thẻ cụ thể。									*/
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Get_TagFocus(ref byte focus); //20150413
        //-----------------------------------------------------------------------------


        /***********************************************************************************/
        /**  Tên hàm: Set_module_baud_rate * /
        / ** Chức năng: Chức năng này được sử dụng để đặt tốc độ truyền của mô-đun * /
        / * baud_rate: Đặt tốc độ truyền của mô-đun, * /
        / * Data0 = 0, tương ứng với giá trị cài đặt 9600, * /
        / * Data0 = 1, tương ứng với giá trị cài đặt 19200, * /
        / * Data0 = 2, tương ứng với giá trị cài đặt 38400, * /
        / * Data0 = 3, tương ứng với giá trị cài đặt 57600, * /
        / * Data0 = 4, tương ứng với giá trị cài đặt 115200, * /
        / * Giá trị khác, bất hợp pháp. * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại					                           */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Set_module_baud_rate(byte baud_rate);

        /***********************************************************************************/
        /** Tên hàm: Set_qtparam * /
        / ** Chức năng: Chức năng này được sử dụng để thiết lập trạng thái QT của nhãn * /
        / * mật khẩu: Đặt mật khẩu AP của thẻ QT * /
        / * filter_bak: Đặt loại bộ lọc QT thẻ * /
        / * filter_len: Đặt độ dài dữ liệu bộ lọc QT thẻ * /
        / * filter_data: Đặt dữ liệu lọc của thẻ QT * /
        / * qt_param: Đặt trạng thái của thẻ QT * /
        / * bit0 = 0 có nghĩa là không có điều khiển tầm gần, bit0 = 1 có nghĩa là điều khiển tầm gần được bật * /
        / * bit1 = 0 có nghĩa là bản đồ bộ nhớ riêng được bật cho thẻ, bit1 = 1 có nghĩa là thẻ sử dụng Bản đồ bộ nhớ chung * /
        / * data_from_ant: Trả về số ăng-ten của thẻ cài đặt QT * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại                                             */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Set_qtparam(uint password, byte filter_bak, ushort filter_len, byte[] filter_data, byte qt_param);

        /***********************************************************************************/
        /**  Tên hàm: Get_qtparam * /
        / ** Chức năng: Chức năng này được sử dụng để lấy trạng thái QT của thẻ * /
        / * mật khẩu: Lấy mật khẩu AP của thẻ QT * /
        / * filter_bak: Nhận loại bộ lọc QT thẻ * /
        / * filter_len: Lấy độ dài dữ liệu bộ lọc QT thẻ * /
        / * filter_data: Lấy dữ liệu lọc của thẻ QT * /
        / * qt_param: trả về trạng thái của thẻ QT * /
        / * bit0 = 0 có nghĩa là không có điều khiển tầm gần, bit0 = 1 có nghĩa là điều khiển tầm gần được bật * /
        / * bit1 = 0 có nghĩa là bản đồ bộ nhớ riêng được bật cho thẻ, bit1 = 1 có nghĩa là thẻ sử dụng Bản đồ bộ nhớ chung * /
        / * data_from_ant: Trả về số ăng-ten của thẻ QT * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại                                             */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int Get_qtparam(uint password, byte filter_bak, ushort filter_len, byte[] filter_data, ref byte qt_param);

        
        /***********************************************************************************/
        /**  Tên hàm: Qtpek_operating * /
        / ** Chức năng: Chức năng này được sử dụng để lấy trạng thái QT của thẻ * /
        / * mật khẩu: Lấy mật khẩu AP của thẻ QT * /
        / * filter_bak: Nhận loại bộ lọc QT thẻ * /
        / * filter_len: Lấy độ dài dữ liệu bộ lọc QT thẻ * /
        / * filter_data: Lấy dữ liệu lọc của thẻ QT * /
        / * qt_param: trả về trạng thái của thẻ QT * /
        / * oper_type 0 có nghĩa là không có hoạt động nào sau QT, 1 có nghĩa là hoạt động đọc sau QT, 2 có nghĩa là hoạt động ghi sau QT * /
        / * close_status bit0 = 0 có nghĩa là không có điều khiển phạm vi gần, bit0 = 1 có nghĩa là điều khiển phạm vi gần được bật * /
        / * mem_bank: thao tác số ngân hàng của nhãn * /
        / * addr: thao tác địa chỉ bắt đầu của nhãn * /
        / * data_len: thao tác độ dài dữ liệu của nhãn * /
        / * data: thao tác dữ liệu thẻ * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại                                             */                            
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int qtpek_operat(uint password, byte filter_bak, ushort filter_len, byte[] filter_data, byte oper_type,
							                 byte close_status,byte mem_bank,ushort addr,ushort data_len,byte[] data); 


        /***********************************************************************************/
        /** Tên hàm: uart_trans_open * /
        / ** Chức năng: Chức năng này được sử dụng để mở cổng nối tiếp * /
        / * name: tên cổng nối tiếp (tất cả các đường dẫn) * /
        / * com_baudrate: tốc độ truyền của cổng nối tiếp * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại                                             */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int uart_trans_open(byte[] name, int com_baudrate);

        /***********************************************************************************/
        /**  Tên hàm: uart_trans_close * /
        / ** Chức năng: Chức năng này được sử dụng để đóng cổng nối tiếp * /
        / * Giá trị trả về: NULL					                                               */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static void uart_trans_close();

        /***********************************************************************************/
        /**  Tên hàm: uart_trans_send * /
        / ** Chức năng: Chức năng này được sử dụng để gửi dữ liệu qua cổng nối tiếp * /
        / * send_buffer: dữ liệu đã gửi * /
        / * data_len: độ dài dữ liệu * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại                                             */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int uart_trans_send(byte[] send_buffer, uint data_len);

        /***********************************************************************************/
        /**  Tên hàm: uart_trans_recv * /
        / ** Chức năng: Chức năng này được sử dụng để gửi dữ liệu qua cổng nối tiếp * /
        / * send_buffer: dữ liệu đã gửi * /
        / * date_len: độ dài dữ liệu đã nhận * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại                                             */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int uart_trans_recv(byte[] recv_buffer, ref uint date_len);

        /***********************************************************************************/
        /**  Tên hàm: uart_trans_recv * /
        / ** Chức năng: Chức năng này được sử dụng để khởi tạo cổng mạng * /
        / * Giá trị trả về: NULL                                             */
        /***********************************************************************************/
        //[DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        //public extern static void net_trans_init();

        /***********************************************************************************/
        /**  Tên hàm: uart_trans_recv * /
        / ** Chức năng: Chức năng này được sử dụng để khởi tạo cổng mạng * /
        / * strIP: địa chỉ IP * /
        / * ipAddr: dữ liệu đã gửi * /
        / * nLocalPort: cổng cục bộ * /
        / * nPeerPort: PC là máy chủ và thiết bị là máy khách. Đặt cổng * /
        / * PC là máy khách và thiết bị là máy chủ. Cổng được đặt thành 0 * /
        / * nWorkMode: dữ liệu đã gửi * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại                                             */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int net_trans_open(ref char[] strIP,ref char[] ipAddr, uint nLocalPort, uint nPeerPort, byte nWorkMode);

        /***********************************************************************************/
        /**  Tên hàm: net_trans_close * /
        / ** Chức năng: Chức năng này được sử dụng để đóng giao tiếp cổng mạng * /
        / * Giá trị trả về: NULL																   */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static void net_trans_close();

        /***********************************************************************************/  //2015-03-10-22
        /** Tên hàm: net_trans_send * /
        / ** Chức năng: Chức năng này dùng để gửi dữ liệu qua cổng mạng * /
        / * send_buffer: gửi dữ liệu * /
        / * data_len: độ dài dữ liệu * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại											   */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int net_trans_send(byte[] send_buffer, uint data_len);

        /***********************************************************************************/
        /**  Tên hàm: net_trans_send_set * /
        / ** Chức năng: Chức năng này được sử dụng cho cài đặt gửi giao tiếp cổng mạng * /
        / * Giá trị trả về: NULL																   */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static void net_trans_send_set();

        /***********************************************************************************/
        /**  Tên hàm: net_trans_recv * /
        / ** Chức năng: Chức năng này dùng để nhận dữ liệu qua cổng mạng * /
        / * send_buffer: gửi dữ liệu * /
        / * data_len: độ dài dữ liệu dữ liệu đã nhận * /
        / * Giá trị trả về: trả về 0 khi thành công, số âm khi thất bại											   */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static int net_trans_recv(byte[] recv_buffer, uint[] data_len);

        /***********************************************************************************/
        /**  Tên hàm: net_trans_recv_set * /
        / ** Chức năng: Chức năng này được sử dụng cho cài đặt nhận giao tiếp cổng mạng * /
        / * Giá trị trả về: NULL																   */
        /***********************************************************************************/
        [DllImport("api_dll.dll", CharSet = CharSet.Ansi)]
        public extern static void net_trans_recv_set();


        /***********************************************************************************/
        /**  Tên hàm: basic_init * /
        / ** Chức năng: Chức năng này được sử dụng để khởi tạo giao tiếp * /
        / ** itype: 101 CONNECT_SERIAL 102 CONNECT_NET * /
        / * Giá trị trả về: NULL																   */
        /***********************************************************************************/
        [DllImport("api_dll.dll")]
        public extern static int basic_init(int itype);

    }
}

