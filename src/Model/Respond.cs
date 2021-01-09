//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Respond.proto
namespace hrvv
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Respond")]
  public partial class Respond : global::ProtoBuf.IExtensible
  {
    public Respond() {}
    
    private hrvv.Respond.Type _type;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public hrvv.Respond.Type type
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
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_POWER_RESPOND", Value=128)]
      SET_POWER_RESPOND = 128,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_GPIO_RESPOND", Value=129)]
      SET_GPIO_RESPOND = 129,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_FREQUENCY_POINT_RESPOND", Value=130)]
      SET_FREQUENCY_POINT_RESPOND = 130,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_CARRIER_RESPOND", Value=133)]
      SET_CARRIER_RESPOND = 133,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_CARRIER_RESPOND", Value=143)]
      GET_CARRIER_RESPOND = 143,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_GEN2_RESPOND", Value=135)]
      SET_GEN2_RESPOND = 135,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_WORK_ANT_RESPOND", Value=136)]
      SET_WORK_ANT_RESPOND = 136,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_FREQUENCY_AREA_RESPOND", Value=137)]
      SET_FREQUENCY_AREA_RESPOND = 137,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_FREQUENCY_POINT_RESPOND", Value=141)]
      GET_FREQUENCY_POINT_RESPOND = 141,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_FREQUENCY_AREA_RESPOND", Value=145)]
      GET_FREQUENCY_AREA_RESPOND = 145,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_TEMPERATURE_RESPOND", Value=146)]
      GET_TEMPERATURE_RESPOND = 146,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_GPIO_RESPOND", Value=147)]
      GET_GPIO_RESPOND = 147,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_GEN2_RESPPOND", Value=148)]
      GET_GEN2_RESPPOND = 148,
            
      [global::ProtoBuf.ProtoEnum(Name=@"START_SINGLE_EPC_RESPOND", Value=150)]
      START_SINGLE_EPC_RESPOND = 150,
            
      [global::ProtoBuf.ProtoEnum(Name=@"START_MULTI_EPC_RESPOND", Value=151)]
      START_MULTI_EPC_RESPOND = 151,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_SINGLE_CHANNEL_RESPOND", Value=157)]
      SET_SINGLE_CHANNEL_RESPOND = 157,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_HARD_VERSION_RESPOND", Value=138)]
      GET_HARD_VERSION_RESPOND = 138,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_FIRM_VERSION_RESPOND", Value=139)]
      GET_FIRM_VERSION_RESPOND = 139,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_POWER_RESPOND", Value=140)]
      GET_POWER_RESPOND = 140,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_WORK_ANT_RESPOND", Value=144)]
      GET_WORK_ANT_RESPOND = 144,
            
      [global::ProtoBuf.ProtoEnum(Name=@"READ_TAGS_RESPOND", Value=153)]
      READ_TAGS_RESPOND = 153,
            
      [global::ProtoBuf.ProtoEnum(Name=@"WRITE_TAGS_RESPOND", Value=154)]
      WRITE_TAGS_RESPOND = 154,
            
      [global::ProtoBuf.ProtoEnum(Name=@"LOCK_TAGS_RESPOND", Value=155)]
      LOCK_TAGS_RESPOND = 155,
            
      [global::ProtoBuf.ProtoEnum(Name=@"KILL_TAGS_RESPOND", Value=156)]
      KILL_TAGS_RESPOND = 156,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_WORK_INTERRUPTED_RESPOND", Value=158)]
      GET_WORK_INTERRUPTED_RESPOND = 158,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_WORK_TIME_RESPOND", Value=159)]
      SET_WORK_TIME_RESPOND = 159,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_WORK_TIME_RESPOND", Value=160)]
      GET_WORK_TIME_RESPOND = 160,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_FASTID_RESPOND", Value=161)]
      SET_FASTID_RESPOND = 161,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_FASTID_RESPOND", Value=162)]
      GET_FASTID_RESPOND = 162,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_QT_RESPOND", Value=166)]
      SET_QT_RESPOND = 166,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_QT_RESPOND", Value=167)]
      GET_QT_RESPOND = 167,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_TAGFOCUS_RESPOND", Value=169)]
      SET_TAGFOCUS_RESPOND = 169,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_TAGFOCUS_RESPOND", Value=170)]
      GET_TAGFOCUS_RESPOND = 170,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_COMMUNICATION_INFO_RESPOND", Value=171)]
      GET_COMMUNICATION_INFO_RESPOND = 171,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ERROR_RESPOND", Value=10)]
      ERROR_RESPOND = 10,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_COMMUNICATION_INFO_RESPOND", Value=195)]
      SET_COMMUNICATION_INFO_RESPOND = 195,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_WORK_MODE_RESPOND", Value=196)]
      GET_WORK_MODE_RESPOND = 196,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_WORK_MODE_RESPOND", Value=199)]
      SET_WORK_MODE_RESPOND = 199,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_MAC_ADD_RESPOND", Value=200)]
      SET_MAC_ADD_RESPOND = 200,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_MAC_ADD_RESPOND", Value=201)]
      GET_MAC_ADD_RESPOND = 201,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_SIM_RESPOND", Value=203)]
      GET_SIM_RESPOND = 203,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_SIM_RESPOND", Value=204)]
      SET_SIM_RESPOND = 204,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_WIFI_RESPOND", Value=207)]
      SET_WIFI_RESPOND = 207,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_WIFI_RESPOND", Value=209)]
      GET_WIFI_RESPOND = 209,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_MQTT_RESPOND", Value=213)]
      SET_MQTT_RESPOND = 213,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_MQTT_RESPOND", Value=214)]
      GET_MQTT_RESPOND = 214,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SET_MQTT_THEME_RESPOND", Value=215)]
      SET_MQTT_THEME_RESPOND = 215,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GET_MQTT_THEME_RESPOND", Value=216)]
      GET_MQTT_THEME_RESPOND = 216
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}