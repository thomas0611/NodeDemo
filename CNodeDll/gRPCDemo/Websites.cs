// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: websites.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace GRPCDemo {

  /// <summary>Holder for reflection information generated from websites.proto</summary>
  public static partial class WebsitesReflection {

    #region Descriptor
    /// <summary>File descriptor for websites.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static WebsitesReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg53ZWJzaXRlcy5wcm90bxIIZ1JQQ0RlbW8iHAoMU2l0ZXNSZXF1ZXN0EgwK",
            "BG5hbWUYASABKAkiRQoKU2l0ZXNSZXBseRIPCgdtZXNzYWdlGAEgASgJEiYK",
            "C0xpc3RXZWJTaXRlGAIgAygLMhEuZ1JQQ0RlbW8uV2ViU2l0ZSJVCghEYkRl",
            "dGFpbBIPCgdtZXNzYWdlGAEgASgJEg8KB0FkZHJlc3MYAiABKAkSDAoETmFt",
            "ZRgDIAEoCRIMCgRVc2VyGAQgASgJEgsKA1B3ZBgFIAEoCSJ0CgdXZWJTaXRl",
            "EgoKAklEGAEgASgFEgwKBE5hbWUYAiABKAkSFAoMUGh5c2ljYWxQYXRoGAMg",
            "ASgJEg8KB0FkZHJlc3MYBCABKAkSGgoSQmluZGluZ0luZm9ybWF0aW9uGAUg",
            "ASgJEgwKBFBvcnQYBiABKAUyhAEKB3JwY1NpdGUSOgoIR2V0U2l0ZXMSFi5n",
            "UlBDRGVtby5TaXRlc1JlcXVlc3QaFC5nUlBDRGVtby5TaXRlc1JlcGx5IgAS",
            "PQoNR2V0U2l0ZURldGFpbBIWLmdSUENEZW1vLlNpdGVzUmVxdWVzdBoSLmdS",
            "UENEZW1vLkRiRGV0YWlsIgBiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::GRPCDemo.SitesRequest), global::GRPCDemo.SitesRequest.Parser, new[]{ "Name" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::GRPCDemo.SitesReply), global::GRPCDemo.SitesReply.Parser, new[]{ "Message", "ListWebSite" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::GRPCDemo.DbDetail), global::GRPCDemo.DbDetail.Parser, new[]{ "Message", "Address", "Name", "User", "Pwd" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::GRPCDemo.WebSite), global::GRPCDemo.WebSite.Parser, new[]{ "ID", "Name", "PhysicalPath", "Address", "BindingInformation", "Port" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class SitesRequest : pb::IMessage<SitesRequest> {
    private static readonly pb::MessageParser<SitesRequest> _parser = new pb::MessageParser<SitesRequest>(() => new SitesRequest());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SitesRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GRPCDemo.WebsitesReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SitesRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SitesRequest(SitesRequest other) : this() {
      name_ = other.name_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SitesRequest Clone() {
      return new SitesRequest(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SitesRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SitesRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SitesRequest other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Name = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class SitesReply : pb::IMessage<SitesReply> {
    private static readonly pb::MessageParser<SitesReply> _parser = new pb::MessageParser<SitesReply>(() => new SitesReply());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SitesReply> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GRPCDemo.WebsitesReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SitesReply() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SitesReply(SitesReply other) : this() {
      message_ = other.message_;
      listWebSite_ = other.listWebSite_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SitesReply Clone() {
      return new SitesReply(this);
    }

    /// <summary>Field number for the "message" field.</summary>
    public const int MessageFieldNumber = 1;
    private string message_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Message {
      get { return message_; }
      set {
        message_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "ListWebSite" field.</summary>
    public const int ListWebSiteFieldNumber = 2;
    private static readonly pb::FieldCodec<global::GRPCDemo.WebSite> _repeated_listWebSite_codec
        = pb::FieldCodec.ForMessage(18, global::GRPCDemo.WebSite.Parser);
    private readonly pbc::RepeatedField<global::GRPCDemo.WebSite> listWebSite_ = new pbc::RepeatedField<global::GRPCDemo.WebSite>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::GRPCDemo.WebSite> ListWebSite {
      get { return listWebSite_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SitesReply);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SitesReply other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Message != other.Message) return false;
      if(!listWebSite_.Equals(other.listWebSite_)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Message.Length != 0) hash ^= Message.GetHashCode();
      hash ^= listWebSite_.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Message.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Message);
      }
      listWebSite_.WriteTo(output, _repeated_listWebSite_codec);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Message.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Message);
      }
      size += listWebSite_.CalculateSize(_repeated_listWebSite_codec);
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SitesReply other) {
      if (other == null) {
        return;
      }
      if (other.Message.Length != 0) {
        Message = other.Message;
      }
      listWebSite_.Add(other.listWebSite_);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Message = input.ReadString();
            break;
          }
          case 18: {
            listWebSite_.AddEntriesFrom(input, _repeated_listWebSite_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class DbDetail : pb::IMessage<DbDetail> {
    private static readonly pb::MessageParser<DbDetail> _parser = new pb::MessageParser<DbDetail>(() => new DbDetail());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<DbDetail> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GRPCDemo.WebsitesReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DbDetail() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DbDetail(DbDetail other) : this() {
      message_ = other.message_;
      address_ = other.address_;
      name_ = other.name_;
      user_ = other.user_;
      pwd_ = other.pwd_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DbDetail Clone() {
      return new DbDetail(this);
    }

    /// <summary>Field number for the "message" field.</summary>
    public const int MessageFieldNumber = 1;
    private string message_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Message {
      get { return message_; }
      set {
        message_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Address" field.</summary>
    public const int AddressFieldNumber = 2;
    private string address_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Address {
      get { return address_; }
      set {
        address_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Name" field.</summary>
    public const int NameFieldNumber = 3;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "User" field.</summary>
    public const int UserFieldNumber = 4;
    private string user_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string User {
      get { return user_; }
      set {
        user_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Pwd" field.</summary>
    public const int PwdFieldNumber = 5;
    private string pwd_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Pwd {
      get { return pwd_; }
      set {
        pwd_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as DbDetail);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(DbDetail other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Message != other.Message) return false;
      if (Address != other.Address) return false;
      if (Name != other.Name) return false;
      if (User != other.User) return false;
      if (Pwd != other.Pwd) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Message.Length != 0) hash ^= Message.GetHashCode();
      if (Address.Length != 0) hash ^= Address.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (User.Length != 0) hash ^= User.GetHashCode();
      if (Pwd.Length != 0) hash ^= Pwd.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Message.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Message);
      }
      if (Address.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Address);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Name);
      }
      if (User.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(User);
      }
      if (Pwd.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(Pwd);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Message.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Message);
      }
      if (Address.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Address);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (User.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(User);
      }
      if (Pwd.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Pwd);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(DbDetail other) {
      if (other == null) {
        return;
      }
      if (other.Message.Length != 0) {
        Message = other.Message;
      }
      if (other.Address.Length != 0) {
        Address = other.Address;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.User.Length != 0) {
        User = other.User;
      }
      if (other.Pwd.Length != 0) {
        Pwd = other.Pwd;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Message = input.ReadString();
            break;
          }
          case 18: {
            Address = input.ReadString();
            break;
          }
          case 26: {
            Name = input.ReadString();
            break;
          }
          case 34: {
            User = input.ReadString();
            break;
          }
          case 42: {
            Pwd = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class WebSite : pb::IMessage<WebSite> {
    private static readonly pb::MessageParser<WebSite> _parser = new pb::MessageParser<WebSite>(() => new WebSite());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<WebSite> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GRPCDemo.WebsitesReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WebSite() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WebSite(WebSite other) : this() {
      iD_ = other.iD_;
      name_ = other.name_;
      physicalPath_ = other.physicalPath_;
      address_ = other.address_;
      bindingInformation_ = other.bindingInformation_;
      port_ = other.port_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WebSite Clone() {
      return new WebSite(this);
    }

    /// <summary>Field number for the "ID" field.</summary>
    public const int IDFieldNumber = 1;
    private int iD_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ID {
      get { return iD_; }
      set {
        iD_ = value;
      }
    }

    /// <summary>Field number for the "Name" field.</summary>
    public const int NameFieldNumber = 2;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "PhysicalPath" field.</summary>
    public const int PhysicalPathFieldNumber = 3;
    private string physicalPath_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string PhysicalPath {
      get { return physicalPath_; }
      set {
        physicalPath_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Address" field.</summary>
    public const int AddressFieldNumber = 4;
    private string address_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Address {
      get { return address_; }
      set {
        address_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "BindingInformation" field.</summary>
    public const int BindingInformationFieldNumber = 5;
    private string bindingInformation_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string BindingInformation {
      get { return bindingInformation_; }
      set {
        bindingInformation_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Port" field.</summary>
    public const int PortFieldNumber = 6;
    private int port_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Port {
      get { return port_; }
      set {
        port_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as WebSite);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(WebSite other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ID != other.ID) return false;
      if (Name != other.Name) return false;
      if (PhysicalPath != other.PhysicalPath) return false;
      if (Address != other.Address) return false;
      if (BindingInformation != other.BindingInformation) return false;
      if (Port != other.Port) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ID != 0) hash ^= ID.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (PhysicalPath.Length != 0) hash ^= PhysicalPath.GetHashCode();
      if (Address.Length != 0) hash ^= Address.GetHashCode();
      if (BindingInformation.Length != 0) hash ^= BindingInformation.GetHashCode();
      if (Port != 0) hash ^= Port.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (ID != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(ID);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (PhysicalPath.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(PhysicalPath);
      }
      if (Address.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Address);
      }
      if (BindingInformation.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(BindingInformation);
      }
      if (Port != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(Port);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ID);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (PhysicalPath.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PhysicalPath);
      }
      if (Address.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Address);
      }
      if (BindingInformation.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(BindingInformation);
      }
      if (Port != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Port);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(WebSite other) {
      if (other == null) {
        return;
      }
      if (other.ID != 0) {
        ID = other.ID;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.PhysicalPath.Length != 0) {
        PhysicalPath = other.PhysicalPath;
      }
      if (other.Address.Length != 0) {
        Address = other.Address;
      }
      if (other.BindingInformation.Length != 0) {
        BindingInformation = other.BindingInformation;
      }
      if (other.Port != 0) {
        Port = other.Port;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            ID = input.ReadInt32();
            break;
          }
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 26: {
            PhysicalPath = input.ReadString();
            break;
          }
          case 34: {
            Address = input.ReadString();
            break;
          }
          case 42: {
            BindingInformation = input.ReadString();
            break;
          }
          case 48: {
            Port = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
