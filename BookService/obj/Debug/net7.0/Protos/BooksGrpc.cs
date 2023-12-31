// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/books.proto
// </auto-generated>
// Original file comments:
// BookService servisimizin protobuf dosyası
// Bu dosyayı kullanarak gRPC servisimizin client ve server kodlarını oluşturacağız.
//
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace BookStore.Services {
  /// <summary>
  /// BookService servisimiz
  /// </summary>
  public static partial class BookService
  {
    static readonly string __ServiceName = "bookstore.BookService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
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

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
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

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::BookStore.Services.GetBookRequest> __Marshaller_bookstore_GetBookRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::BookStore.Services.GetBookRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::BookStore.Services.GetBookResponse> __Marshaller_bookstore_GetBookResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::BookStore.Services.GetBookResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::BookStore.Services.CreateBookRequest> __Marshaller_bookstore_CreateBookRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::BookStore.Services.CreateBookRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::BookStore.Services.CreateBookResponse> __Marshaller_bookstore_CreateBookResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::BookStore.Services.CreateBookResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::BookStore.Services.ListBooksRequest> __Marshaller_bookstore_ListBooksRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::BookStore.Services.ListBooksRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::BookStore.Services.ListBooksResponse> __Marshaller_bookstore_ListBooksResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::BookStore.Services.ListBooksResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::BookStore.Services.GetBookRequest, global::BookStore.Services.GetBookResponse> __Method_GetBook = new grpc::Method<global::BookStore.Services.GetBookRequest, global::BookStore.Services.GetBookResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetBook",
        __Marshaller_bookstore_GetBookRequest,
        __Marshaller_bookstore_GetBookResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::BookStore.Services.CreateBookRequest, global::BookStore.Services.CreateBookResponse> __Method_CreateBook = new grpc::Method<global::BookStore.Services.CreateBookRequest, global::BookStore.Services.CreateBookResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateBook",
        __Marshaller_bookstore_CreateBookRequest,
        __Marshaller_bookstore_CreateBookResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::BookStore.Services.ListBooksRequest, global::BookStore.Services.ListBooksResponse> __Method_ListBooks = new grpc::Method<global::BookStore.Services.ListBooksRequest, global::BookStore.Services.ListBooksResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ListBooks",
        __Marshaller_bookstore_ListBooksRequest,
        __Marshaller_bookstore_ListBooksResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::BookStore.Services.BooksReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of BookService</summary>
    [grpc::BindServiceMethod(typeof(BookService), "BindService")]
    public abstract partial class BookServiceBase
    {
      /// <summary>
      /// Kitap bilgilerini getirir.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::BookStore.Services.GetBookResponse> GetBook(global::BookStore.Services.GetBookRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Yeni bir kitap oluşturur.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::BookStore.Services.CreateBookResponse> CreateBook(global::BookStore.Services.CreateBookRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Tüm kitapları listeler.
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::BookStore.Services.ListBooksResponse> ListBooks(global::BookStore.Services.ListBooksRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(BookServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetBook, serviceImpl.GetBook)
          .AddMethod(__Method_CreateBook, serviceImpl.CreateBook)
          .AddMethod(__Method_ListBooks, serviceImpl.ListBooks).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, BookServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetBook, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::BookStore.Services.GetBookRequest, global::BookStore.Services.GetBookResponse>(serviceImpl.GetBook));
      serviceBinder.AddMethod(__Method_CreateBook, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::BookStore.Services.CreateBookRequest, global::BookStore.Services.CreateBookResponse>(serviceImpl.CreateBook));
      serviceBinder.AddMethod(__Method_ListBooks, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::BookStore.Services.ListBooksRequest, global::BookStore.Services.ListBooksResponse>(serviceImpl.ListBooks));
    }

  }
}
#endregion
