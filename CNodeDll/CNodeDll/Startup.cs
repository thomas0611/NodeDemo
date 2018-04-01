using System.Threading.Tasks;
using Grpc.Core;
using GRPCDemo;
using Utility;
using System;

public class Startup
{
    public async Task<object> GetLocalSites(dynamic input)
    {
        //int anInteger = (int)input.anInteger;
        //double aNumber = (double)input.aNumber;
        //string aString = (string)input.aString;
        //bool aBoolean = (bool)input.aBoolean;
        //byte[] aBuffer = (byte[])input.aBuffer;
        //object[] anArray = (object[])input.anArray;
        //dynamic anObject = (dynamic)input.anObject;
        try
        {
            var list = new IISHelper().GetAllSites();
            return new { Message = "success", ListWebSite = list };
        }
        catch (Exception ex)
        {
            return new { Message = ex.Message };
        }
    }

    public async Task<object> GetRemoteSites(dynamic input)
    {
        try
        {
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new rpcSite.rpcSiteClient(channel);
            var reply = client.GetSites(new SitesRequest { Name = "Thomas" });
            return reply;
        }
        catch (Exception ex)
        {
            return new { Message = ex.Message };
        }
    }

    public async Task<object> GetSiteDetail(dynamic input)
    {
        try
        {
            string path = (string)input;
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new rpcSite.rpcSiteClient(channel);
            var reply = client.GetSiteDetail(new SitesRequest { Name = path });
            return reply;
        }
        catch (Exception ex)
        {
            return new { Message = ex.Message };
        }
    }
}
