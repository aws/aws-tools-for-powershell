/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Create as many Networks as you need. You will associate one or more Clusters with
    /// each Network.Each Network provides MediaLive Anywhere with required information about
    /// the network in your organization that you are using for video encoding using MediaLive.
    /// </summary>
    [Cmdlet("New", "EMLNetwork", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.CreateNetworkResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive CreateNetwork API operation.", Operation = new[] {"CreateNetwork"}, SelectReturnType = typeof(Amazon.MediaLive.Model.CreateNetworkResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.CreateNetworkResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.CreateNetworkResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEMLNetworkCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IpPool
        /// <summary>
        /// <para>
        /// An array of IpPoolCreateRequests that identify
        /// a collection of IP addresses in your network that you want to reserve for use in MediaLive
        /// Anywhere. MediaLiveAnywhere uses these IP addresses for Push inputs (in both Bridge
        /// and NATnetworks) and for output destinations (only in Bridge networks). EachIpPoolUpdateRequest
        /// specifies one CIDR block.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IpPools")]
        public Amazon.MediaLive.Model.IpPoolCreateRequest[] IpPool { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// Specify a name that is unique in the AWS account.
        /// We recommend that you assign a name that hints at the type of traffic on the network.
        /// Names are case-sensitive.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RequestId
        /// <summary>
        /// <para>
        /// An ID that you assign to a create request. This
        /// ID ensures idempotency when creating resources.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestId { get; set; }
        #endregion
        
        #region Parameter Route
        /// <summary>
        /// <para>
        /// An array of routes that MediaLive Anywhere needs
        /// to know about in order to route encoding traffic.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Routes")]
        public Amazon.MediaLive.Model.RouteCreateRequest[] Route { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// A collection of key-value pairs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.CreateNetworkResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.CreateNetworkResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMLNetwork (CreateNetwork)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.CreateNetworkResponse, NewEMLNetworkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.IpPool != null)
            {
                context.IpPool = new List<Amazon.MediaLive.Model.IpPoolCreateRequest>(this.IpPool);
            }
            context.Name = this.Name;
            context.RequestId = this.RequestId;
            if (this.Route != null)
            {
                context.Route = new List<Amazon.MediaLive.Model.RouteCreateRequest>(this.Route);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.MediaLive.Model.CreateNetworkRequest();
            
            if (cmdletContext.IpPool != null)
            {
                request.IpPools = cmdletContext.IpPool;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RequestId != null)
            {
                request.RequestId = cmdletContext.RequestId;
            }
            if (cmdletContext.Route != null)
            {
                request.Routes = cmdletContext.Route;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.MediaLive.Model.CreateNetworkResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.CreateNetworkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "CreateNetwork");
            try
            {
                #if DESKTOP
                return client.CreateNetwork(request);
                #elif CORECLR
                return client.CreateNetworkAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public List<Amazon.MediaLive.Model.IpPoolCreateRequest> IpPool { get; set; }
            public System.String Name { get; set; }
            public System.String RequestId { get; set; }
            public List<Amazon.MediaLive.Model.RouteCreateRequest> Route { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.MediaLive.Model.CreateNetworkResponse, NewEMLNetworkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
