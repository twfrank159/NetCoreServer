// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: protos/human_resource.proto
// </auto-generated>
// Original file comments:
// proto文件需要與Server端一致才能響應
//
// Protocol Buffers Format version
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace L8_SignalR.Protos {
  /// <summary>
  ///定義所有的rpc服務 input and ouput
  /// </summary>
  public static partial class Employee
  {
    static readonly string __ServiceName = "gRPCTest.humanresource.Employee";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::L8_SignalR.Protos.EmployeeRequest> __Marshaller_gRPCTest_humanresource_EmployeeRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::L8_SignalR.Protos.EmployeeRequest.Parser));
    static readonly grpc::Marshaller<global::L8_SignalR.Protos.EmployeeModel> __Marshaller_gRPCTest_humanresource_EmployeeModel = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::L8_SignalR.Protos.EmployeeModel.Parser));
    static readonly grpc::Marshaller<global::L8_SignalR.Protos.EmployeeAddedResult> __Marshaller_gRPCTest_humanresource_EmployeeAddedResult = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::L8_SignalR.Protos.EmployeeAddedResult.Parser));

    static readonly grpc::Method<global::L8_SignalR.Protos.EmployeeRequest, global::L8_SignalR.Protos.EmployeeModel> __Method_GetEmployee = new grpc::Method<global::L8_SignalR.Protos.EmployeeRequest, global::L8_SignalR.Protos.EmployeeModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetEmployee",
        __Marshaller_gRPCTest_humanresource_EmployeeRequest,
        __Marshaller_gRPCTest_humanresource_EmployeeModel);

    static readonly grpc::Method<global::L8_SignalR.Protos.EmployeeRequest, global::L8_SignalR.Protos.EmployeeModel> __Method_GetAllEmployees = new grpc::Method<global::L8_SignalR.Protos.EmployeeRequest, global::L8_SignalR.Protos.EmployeeModel>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetAllEmployees",
        __Marshaller_gRPCTest_humanresource_EmployeeRequest,
        __Marshaller_gRPCTest_humanresource_EmployeeModel);

    static readonly grpc::Method<global::L8_SignalR.Protos.EmployeeModel, global::L8_SignalR.Protos.EmployeeAddedResult> __Method_AddEmployee = new grpc::Method<global::L8_SignalR.Protos.EmployeeModel, global::L8_SignalR.Protos.EmployeeAddedResult>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddEmployee",
        __Marshaller_gRPCTest_humanresource_EmployeeModel,
        __Marshaller_gRPCTest_humanresource_EmployeeAddedResult);

    static readonly grpc::Method<global::L8_SignalR.Protos.EmployeeModel, global::L8_SignalR.Protos.EmployeeAddedResult> __Method_AddEmployees = new grpc::Method<global::L8_SignalR.Protos.EmployeeModel, global::L8_SignalR.Protos.EmployeeAddedResult>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "AddEmployees",
        __Marshaller_gRPCTest_humanresource_EmployeeModel,
        __Marshaller_gRPCTest_humanresource_EmployeeAddedResult);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::L8_SignalR.Protos.HumanResourceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for Employee</summary>
    public partial class EmployeeClient : grpc::ClientBase<EmployeeClient>
    {
      /// <summary>Creates a new client for Employee</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public EmployeeClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Employee that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public EmployeeClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected EmployeeClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected EmployeeClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::L8_SignalR.Protos.EmployeeModel GetEmployee(global::L8_SignalR.Protos.EmployeeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetEmployee(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::L8_SignalR.Protos.EmployeeModel GetEmployee(global::L8_SignalR.Protos.EmployeeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetEmployee, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::L8_SignalR.Protos.EmployeeModel> GetEmployeeAsync(global::L8_SignalR.Protos.EmployeeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetEmployeeAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::L8_SignalR.Protos.EmployeeModel> GetEmployeeAsync(global::L8_SignalR.Protos.EmployeeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetEmployee, null, options, request);
      }
      public virtual grpc::AsyncServerStreamingCall<global::L8_SignalR.Protos.EmployeeModel> GetAllEmployees(global::L8_SignalR.Protos.EmployeeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllEmployees(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::L8_SignalR.Protos.EmployeeModel> GetAllEmployees(global::L8_SignalR.Protos.EmployeeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetAllEmployees, null, options, request);
      }
      public virtual global::L8_SignalR.Protos.EmployeeAddedResult AddEmployee(global::L8_SignalR.Protos.EmployeeModel request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddEmployee(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::L8_SignalR.Protos.EmployeeAddedResult AddEmployee(global::L8_SignalR.Protos.EmployeeModel request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_AddEmployee, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::L8_SignalR.Protos.EmployeeAddedResult> AddEmployeeAsync(global::L8_SignalR.Protos.EmployeeModel request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddEmployeeAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::L8_SignalR.Protos.EmployeeAddedResult> AddEmployeeAsync(global::L8_SignalR.Protos.EmployeeModel request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_AddEmployee, null, options, request);
      }
      /// <summary>
      ///Stream is list of Model 
      /// </summary>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncClientStreamingCall<global::L8_SignalR.Protos.EmployeeModel, global::L8_SignalR.Protos.EmployeeAddedResult> AddEmployees(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddEmployees(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      ///Stream is list of Model 
      /// </summary>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncClientStreamingCall<global::L8_SignalR.Protos.EmployeeModel, global::L8_SignalR.Protos.EmployeeAddedResult> AddEmployees(grpc::CallOptions options)
      {
        return CallInvoker.AsyncClientStreamingCall(__Method_AddEmployees, null, options);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override EmployeeClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new EmployeeClient(configuration);
      }
    }

  }
}
#endregion
