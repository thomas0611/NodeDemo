// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: websites.proto
#region Designer generated code

using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;

namespace GRPCDemo {
  public static class rpcSite
  {
    static readonly string __ServiceName = "gRPCDemo.rpcSite";

    static readonly Marshaller<global::GRPCDemo.SitesRequest> __Marshaller_SitesRequest = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GRPCDemo.SitesRequest.Parser.ParseFrom);
    static readonly Marshaller<global::GRPCDemo.SitesReply> __Marshaller_SitesReply = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GRPCDemo.SitesReply.Parser.ParseFrom);
    static readonly Marshaller<global::GRPCDemo.DbDetail> __Marshaller_DbDetail = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GRPCDemo.DbDetail.Parser.ParseFrom);

    static readonly Method<global::GRPCDemo.SitesRequest, global::GRPCDemo.SitesReply> __Method_GetSites = new Method<global::GRPCDemo.SitesRequest, global::GRPCDemo.SitesReply>(
        MethodType.Unary,
        __ServiceName,
        "GetSites",
        __Marshaller_SitesRequest,
        __Marshaller_SitesReply);

    static readonly Method<global::GRPCDemo.SitesRequest, global::GRPCDemo.DbDetail> __Method_GetSiteDetail = new Method<global::GRPCDemo.SitesRequest, global::GRPCDemo.DbDetail>(
        MethodType.Unary,
        __ServiceName,
        "GetSiteDetail",
        __Marshaller_SitesRequest,
        __Marshaller_DbDetail);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GRPCDemo.WebsitesReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of rpcSite</summary>
    public abstract class rpcSiteBase
    {
      public virtual global::System.Threading.Tasks.Task<global::GRPCDemo.SitesReply> GetSites(global::GRPCDemo.SitesRequest request, ServerCallContext context)
      {
        throw new RpcException(new Status(StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::GRPCDemo.DbDetail> GetSiteDetail(global::GRPCDemo.SitesRequest request, ServerCallContext context)
      {
        throw new RpcException(new Status(StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for rpcSite</summary>
    public class rpcSiteClient : ClientBase<rpcSiteClient>
    {
      /// <summary>Creates a new client for rpcSite</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public rpcSiteClient(Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for rpcSite that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public rpcSiteClient(CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected rpcSiteClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected rpcSiteClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::GRPCDemo.SitesReply GetSites(global::GRPCDemo.SitesRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return GetSites(request, new CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::GRPCDemo.SitesReply GetSites(global::GRPCDemo.SitesRequest request, CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetSites, null, options, request);
      }
      public virtual AsyncUnaryCall<global::GRPCDemo.SitesReply> GetSitesAsync(global::GRPCDemo.SitesRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return GetSitesAsync(request, new CallOptions(headers, deadline, cancellationToken));
      }
      public virtual AsyncUnaryCall<global::GRPCDemo.SitesReply> GetSitesAsync(global::GRPCDemo.SitesRequest request, CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetSites, null, options, request);
      }
      public virtual global::GRPCDemo.DbDetail GetSiteDetail(global::GRPCDemo.SitesRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return GetSiteDetail(request, new CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::GRPCDemo.DbDetail GetSiteDetail(global::GRPCDemo.SitesRequest request, CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetSiteDetail, null, options, request);
      }
      public virtual AsyncUnaryCall<global::GRPCDemo.DbDetail> GetSiteDetailAsync(global::GRPCDemo.SitesRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return GetSiteDetailAsync(request, new CallOptions(headers, deadline, cancellationToken));
      }
      public virtual AsyncUnaryCall<global::GRPCDemo.DbDetail> GetSiteDetailAsync(global::GRPCDemo.SitesRequest request, CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetSiteDetail, null, options, request);
      }
      protected override rpcSiteClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new rpcSiteClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    public static ServerServiceDefinition BindService(rpcSiteBase serviceImpl)
    {
      return ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetSites, serviceImpl.GetSites)
          .AddMethod(__Method_GetSiteDetail, serviceImpl.GetSiteDetail).Build();
    }

  }
}
#endregion
