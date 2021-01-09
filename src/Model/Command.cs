//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Command.proto
namespace hrvv
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Command")]
  public partial class Command : global::ProtoBuf.IExtensible
  {
    public Command() {}
    
    private hrvv.Command.Type _type;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public hrvv.Command.Type type
    {
      get { return _type; }
      set { _type = value; }
    }
    private string _DevID;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"DevID", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string DevID
    {
      get { return _DevID; }
      set { _DevID = value; }
    }

    private string _timestamp = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"timestamp", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string timestamp
    {
      get { return _timestamp; }
      set { _timestamp = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"Type")]
    public enum Type
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_POWER", Value=0)]
      SET_POWER = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_GPIO", Value=1)]
      SET_GPIO = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_FREQUENCY_POINT", Value=2)]
      SET_FREQUENCY_POINT = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_CARRIER", Value=5)]
      SET_CARRIER = 5,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_GEN2", Value=7)]
      SET_GEN2 = 7,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_WORK_ANT", Value=8)]
      SET_WORK_ANT = 8,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_FREQUENCY_AREA", Value=9)]
      SET_FREQUENCY_AREA = 9,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_CARRIER", Value=15)]
      GET_CARRIER = 15,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_WORK_INTERRUPTED", Value=29)]
      SET_WORK_INTERRUPTED = 29,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_WORK_TIME", Value=31)]
      SET_WORK_TIME = 31,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_FASTID", Value=33)]
      SET_FASTID = 33,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_QT", Value=38)]
      SET_QT = 38,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_TAGFOCUS", Value=41)]
      SET_TAGFOCUS = 41,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_HARD_VERSION", Value=10)]
      GET_HARD_VERSION = 10,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_FIRM_VERSION", Value=11)]
      GET_FIRM_VERSION = 11,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_POWER", Value=12)]
      GET_POWER = 12,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_FREQUENCY_POINT", Value=13)]
      GET_FREQUENCY_POINT = 13,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_WORK_ANT", Value=16)]
      GET_WORK_ANT = 16,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_FREQUENCY_AREA", Value=17)]
      GET_FREQUENCY_AREA = 17,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_TEMPERATURE", Value=18)]
      GET_TEMPERATURE = 18,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_GPIO", Value=19)]
      GET_GPIO = 19,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_GEN2", Value=20)]
      GET_GEN2 = 20,
            
      [global::ProtoBuf.ProtoEnum(Name=@"START_SINGLE_EPC", Value=22)]
      START_SINGLE_EPC = 22,
            
      [global::ProtoBuf.ProtoEnum(Name=@"START_MULTI_EPC", Value=23)]
      START_MULTI_EPC = 23,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STOP_MULTI_EPC", Value=24)]
      STOP_MULTI_EPC = 24,
            
      [global::ProtoBuf.ProtoEnum(Name=@"READ_TAGS", Value=25)]
      READ_TAGS = 25,
            
      [global::ProtoBuf.ProtoEnum(Name=@"WRITE_TAGS", Value=26)]
      WRITE_TAGS = 26,
            
      [global::ProtoBuf.ProtoEnum(Name=@"LOCK_TAGS", Value=27)]
      LOCK_TAGS = 27,
            
      [global::ProtoBuf.ProtoEnum(Name=@"KILL_TAGS", Value=28)]
      KILL_TAGS = 28,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_WORK_INTERRUPTED", Value=30)]
      GET_WORK_INTERRUPTED = 30,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_WORK_TIME", Value=32)]
      GET_WORK_TIME = 32,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_FASTID", Value=34)]
      GET_FASTID = 34,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_QT", Value=39)]
      GET_QT = 39,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_TAGFOCUS", Value=42)]
      GET_TAGFOCUS = 42,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_WORK_MODE", Value=52)]
      GET_WORK_MODE = 52,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_WORK_MODE", Value=55)]
      SET_WORK_MODE = 55,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_MULTI_ID", Value=241)]
      GET_MULTI_ID = 241,
            
      [global::ProtoBuf.ProtoEnum(Name=@"START_INFO", Value=243)]
      START_INFO = 243,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DOWN_DATA", Value=250)]
      DOWN_DATA = 250,
            
      [global::ProtoBuf.ProtoEnum(Name=@"DOWN_DATA_RESPOND", Value=251)]
      DOWN_DATA_RESPOND = 251,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ERROR_FLAG", Value=255)]
      ERROR_FLAG = 255
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}