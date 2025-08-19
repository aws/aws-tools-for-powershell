/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.OpenSearchService;
using Amazon.OpenSearchService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OS
{
    /// <summary>
    /// Creates a new cross-cluster search connection from a source Amazon OpenSearch Service
    /// domain to a destination domain. For more information, see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/cross-cluster-search.html">Cross-cluster
    /// search for Amazon OpenSearch Service</a>.
    /// </summary>
    [Cmdlet("New", "OSOutboundConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchService.Model.CreateOutboundConnectionResponse")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service CreateOutboundConnection API operation.", Operation = new[] {"CreateOutboundConnection"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.CreateOutboundConnectionResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchService.Model.CreateOutboundConnectionResponse",
        "This cmdlet returns an Amazon.OpenSearchService.Model.CreateOutboundConnectionResponse object containing multiple properties."
    )]
    public partial class NewOSOutboundConnectionCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConnectionAlias
        /// <summary>
        /// <para>
        /// <para>Name of the connection.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ConnectionAlias { get; set; }
        #endregion
        
        #region Parameter ConnectionMode
        /// <summary>
        /// <para>
        /// <para>The connection mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchService.ConnectionMode")]
        public Amazon.OpenSearchService.ConnectionMode ConnectionMode { get; set; }
        #endregion
        
        #region Parameter LocalDomainInfo_AWSDomainInformation_DomainName
        /// <summary>
        /// <para>
        /// <para>Name of the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LocalDomainInfo_AWSDomainInformation_DomainName { get; set; }
        #endregion
        
        #region Parameter RemoteDomainInfo_AWSDomainInformation_DomainName
        /// <summary>
        /// <para>
        /// <para>Name of the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RemoteDomainInfo_AWSDomainInformation_DomainName { get; set; }
        #endregion
        
        #region Parameter ConnectionProperties_Endpoint
        /// <summary>
        /// <para>
        /// <important><para>The Endpoint attribute cannot be modified. </para></important><para>The endpoint of the remote domain. Applicable for VPC_ENDPOINT connection mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectionProperties_Endpoint { get; set; }
        #endregion
        
        #region Parameter LocalDomainInfo_AWSDomainInformation_OwnerId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the domain owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LocalDomainInfo_AWSDomainInformation_OwnerId { get; set; }
        #endregion
        
        #region Parameter RemoteDomainInfo_AWSDomainInformation_OwnerId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the domain owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RemoteDomainInfo_AWSDomainInformation_OwnerId { get; set; }
        #endregion
        
        #region Parameter LocalDomainInfo_AWSDomainInformation_Region
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region in which the domain is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LocalDomainInfo_AWSDomainInformation_Region { get; set; }
        #endregion
        
        #region Parameter RemoteDomainInfo_AWSDomainInformation_Region
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region in which the domain is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RemoteDomainInfo_AWSDomainInformation_Region { get; set; }
        #endregion
        
        #region Parameter CrossClusterSearch_SkipUnavailable
        /// <summary>
        /// <para>
        /// <para>The status of the <c>SkipUnavailable</c> setting for the outbound connection. This
        /// feature allows you to specify some clusters as optional and ensure that your cross-cluster
        /// queries return partial results despite failures on one or more remote clusters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectionProperties_CrossClusterSearch_SkipUnavailable")]
        [AWSConstantClassSource("Amazon.OpenSearchService.SkipUnavailableStatus")]
        public Amazon.OpenSearchService.SkipUnavailableStatus CrossClusterSearch_SkipUnavailable { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.CreateOutboundConnectionResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.CreateOutboundConnectionResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OSOutboundConnection (CreateOutboundConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.CreateOutboundConnectionResponse, NewOSOutboundConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectionAlias = this.ConnectionAlias;
            #if MODULAR
            if (this.ConnectionAlias == null && ParameterWasBound(nameof(this.ConnectionAlias)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionAlias which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConnectionMode = this.ConnectionMode;
            context.CrossClusterSearch_SkipUnavailable = this.CrossClusterSearch_SkipUnavailable;
            context.ConnectionProperties_Endpoint = this.ConnectionProperties_Endpoint;
            context.LocalDomainInfo_AWSDomainInformation_DomainName = this.LocalDomainInfo_AWSDomainInformation_DomainName;
            context.LocalDomainInfo_AWSDomainInformation_OwnerId = this.LocalDomainInfo_AWSDomainInformation_OwnerId;
            context.LocalDomainInfo_AWSDomainInformation_Region = this.LocalDomainInfo_AWSDomainInformation_Region;
            context.RemoteDomainInfo_AWSDomainInformation_DomainName = this.RemoteDomainInfo_AWSDomainInformation_DomainName;
            context.RemoteDomainInfo_AWSDomainInformation_OwnerId = this.RemoteDomainInfo_AWSDomainInformation_OwnerId;
            context.RemoteDomainInfo_AWSDomainInformation_Region = this.RemoteDomainInfo_AWSDomainInformation_Region;
            
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
            var request = new Amazon.OpenSearchService.Model.CreateOutboundConnectionRequest();
            
            if (cmdletContext.ConnectionAlias != null)
            {
                request.ConnectionAlias = cmdletContext.ConnectionAlias;
            }
            if (cmdletContext.ConnectionMode != null)
            {
                request.ConnectionMode = cmdletContext.ConnectionMode;
            }
            
             // populate ConnectionProperties
            var requestConnectionPropertiesIsNull = true;
            request.ConnectionProperties = new Amazon.OpenSearchService.Model.ConnectionProperties();
            System.String requestConnectionProperties_connectionProperties_Endpoint = null;
            if (cmdletContext.ConnectionProperties_Endpoint != null)
            {
                requestConnectionProperties_connectionProperties_Endpoint = cmdletContext.ConnectionProperties_Endpoint;
            }
            if (requestConnectionProperties_connectionProperties_Endpoint != null)
            {
                request.ConnectionProperties.Endpoint = requestConnectionProperties_connectionProperties_Endpoint;
                requestConnectionPropertiesIsNull = false;
            }
            Amazon.OpenSearchService.Model.CrossClusterSearchConnectionProperties requestConnectionProperties_connectionProperties_CrossClusterSearch = null;
            
             // populate CrossClusterSearch
            var requestConnectionProperties_connectionProperties_CrossClusterSearchIsNull = true;
            requestConnectionProperties_connectionProperties_CrossClusterSearch = new Amazon.OpenSearchService.Model.CrossClusterSearchConnectionProperties();
            Amazon.OpenSearchService.SkipUnavailableStatus requestConnectionProperties_connectionProperties_CrossClusterSearch_crossClusterSearch_SkipUnavailable = null;
            if (cmdletContext.CrossClusterSearch_SkipUnavailable != null)
            {
                requestConnectionProperties_connectionProperties_CrossClusterSearch_crossClusterSearch_SkipUnavailable = cmdletContext.CrossClusterSearch_SkipUnavailable;
            }
            if (requestConnectionProperties_connectionProperties_CrossClusterSearch_crossClusterSearch_SkipUnavailable != null)
            {
                requestConnectionProperties_connectionProperties_CrossClusterSearch.SkipUnavailable = requestConnectionProperties_connectionProperties_CrossClusterSearch_crossClusterSearch_SkipUnavailable;
                requestConnectionProperties_connectionProperties_CrossClusterSearchIsNull = false;
            }
             // determine if requestConnectionProperties_connectionProperties_CrossClusterSearch should be set to null
            if (requestConnectionProperties_connectionProperties_CrossClusterSearchIsNull)
            {
                requestConnectionProperties_connectionProperties_CrossClusterSearch = null;
            }
            if (requestConnectionProperties_connectionProperties_CrossClusterSearch != null)
            {
                request.ConnectionProperties.CrossClusterSearch = requestConnectionProperties_connectionProperties_CrossClusterSearch;
                requestConnectionPropertiesIsNull = false;
            }
             // determine if request.ConnectionProperties should be set to null
            if (requestConnectionPropertiesIsNull)
            {
                request.ConnectionProperties = null;
            }
            
             // populate LocalDomainInfo
            request.LocalDomainInfo = new Amazon.OpenSearchService.Model.DomainInformationContainer();
            Amazon.OpenSearchService.Model.AWSDomainInformation requestLocalDomainInfo_localDomainInfo_AWSDomainInformation = null;
            
             // populate AWSDomainInformation
            var requestLocalDomainInfo_localDomainInfo_AWSDomainInformationIsNull = true;
            requestLocalDomainInfo_localDomainInfo_AWSDomainInformation = new Amazon.OpenSearchService.Model.AWSDomainInformation();
            System.String requestLocalDomainInfo_localDomainInfo_AWSDomainInformation_localDomainInfo_AWSDomainInformation_DomainName = null;
            if (cmdletContext.LocalDomainInfo_AWSDomainInformation_DomainName != null)
            {
                requestLocalDomainInfo_localDomainInfo_AWSDomainInformation_localDomainInfo_AWSDomainInformation_DomainName = cmdletContext.LocalDomainInfo_AWSDomainInformation_DomainName;
            }
            if (requestLocalDomainInfo_localDomainInfo_AWSDomainInformation_localDomainInfo_AWSDomainInformation_DomainName != null)
            {
                requestLocalDomainInfo_localDomainInfo_AWSDomainInformation.DomainName = requestLocalDomainInfo_localDomainInfo_AWSDomainInformation_localDomainInfo_AWSDomainInformation_DomainName;
                requestLocalDomainInfo_localDomainInfo_AWSDomainInformationIsNull = false;
            }
            System.String requestLocalDomainInfo_localDomainInfo_AWSDomainInformation_localDomainInfo_AWSDomainInformation_OwnerId = null;
            if (cmdletContext.LocalDomainInfo_AWSDomainInformation_OwnerId != null)
            {
                requestLocalDomainInfo_localDomainInfo_AWSDomainInformation_localDomainInfo_AWSDomainInformation_OwnerId = cmdletContext.LocalDomainInfo_AWSDomainInformation_OwnerId;
            }
            if (requestLocalDomainInfo_localDomainInfo_AWSDomainInformation_localDomainInfo_AWSDomainInformation_OwnerId != null)
            {
                requestLocalDomainInfo_localDomainInfo_AWSDomainInformation.OwnerId = requestLocalDomainInfo_localDomainInfo_AWSDomainInformation_localDomainInfo_AWSDomainInformation_OwnerId;
                requestLocalDomainInfo_localDomainInfo_AWSDomainInformationIsNull = false;
            }
            System.String requestLocalDomainInfo_localDomainInfo_AWSDomainInformation_localDomainInfo_AWSDomainInformation_Region = null;
            if (cmdletContext.LocalDomainInfo_AWSDomainInformation_Region != null)
            {
                requestLocalDomainInfo_localDomainInfo_AWSDomainInformation_localDomainInfo_AWSDomainInformation_Region = cmdletContext.LocalDomainInfo_AWSDomainInformation_Region;
            }
            if (requestLocalDomainInfo_localDomainInfo_AWSDomainInformation_localDomainInfo_AWSDomainInformation_Region != null)
            {
                requestLocalDomainInfo_localDomainInfo_AWSDomainInformation.Region = requestLocalDomainInfo_localDomainInfo_AWSDomainInformation_localDomainInfo_AWSDomainInformation_Region;
                requestLocalDomainInfo_localDomainInfo_AWSDomainInformationIsNull = false;
            }
             // determine if requestLocalDomainInfo_localDomainInfo_AWSDomainInformation should be set to null
            if (requestLocalDomainInfo_localDomainInfo_AWSDomainInformationIsNull)
            {
                requestLocalDomainInfo_localDomainInfo_AWSDomainInformation = null;
            }
            if (requestLocalDomainInfo_localDomainInfo_AWSDomainInformation != null)
            {
                request.LocalDomainInfo.AWSDomainInformation = requestLocalDomainInfo_localDomainInfo_AWSDomainInformation;
            }
            
             // populate RemoteDomainInfo
            request.RemoteDomainInfo = new Amazon.OpenSearchService.Model.DomainInformationContainer();
            Amazon.OpenSearchService.Model.AWSDomainInformation requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation = null;
            
             // populate AWSDomainInformation
            var requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformationIsNull = true;
            requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation = new Amazon.OpenSearchService.Model.AWSDomainInformation();
            System.String requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation_remoteDomainInfo_AWSDomainInformation_DomainName = null;
            if (cmdletContext.RemoteDomainInfo_AWSDomainInformation_DomainName != null)
            {
                requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation_remoteDomainInfo_AWSDomainInformation_DomainName = cmdletContext.RemoteDomainInfo_AWSDomainInformation_DomainName;
            }
            if (requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation_remoteDomainInfo_AWSDomainInformation_DomainName != null)
            {
                requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation.DomainName = requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation_remoteDomainInfo_AWSDomainInformation_DomainName;
                requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformationIsNull = false;
            }
            System.String requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation_remoteDomainInfo_AWSDomainInformation_OwnerId = null;
            if (cmdletContext.RemoteDomainInfo_AWSDomainInformation_OwnerId != null)
            {
                requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation_remoteDomainInfo_AWSDomainInformation_OwnerId = cmdletContext.RemoteDomainInfo_AWSDomainInformation_OwnerId;
            }
            if (requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation_remoteDomainInfo_AWSDomainInformation_OwnerId != null)
            {
                requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation.OwnerId = requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation_remoteDomainInfo_AWSDomainInformation_OwnerId;
                requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformationIsNull = false;
            }
            System.String requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation_remoteDomainInfo_AWSDomainInformation_Region = null;
            if (cmdletContext.RemoteDomainInfo_AWSDomainInformation_Region != null)
            {
                requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation_remoteDomainInfo_AWSDomainInformation_Region = cmdletContext.RemoteDomainInfo_AWSDomainInformation_Region;
            }
            if (requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation_remoteDomainInfo_AWSDomainInformation_Region != null)
            {
                requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation.Region = requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation_remoteDomainInfo_AWSDomainInformation_Region;
                requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformationIsNull = false;
            }
             // determine if requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation should be set to null
            if (requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformationIsNull)
            {
                requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation = null;
            }
            if (requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation != null)
            {
                request.RemoteDomainInfo.AWSDomainInformation = requestRemoteDomainInfo_remoteDomainInfo_AWSDomainInformation;
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
        
        private Amazon.OpenSearchService.Model.CreateOutboundConnectionResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.CreateOutboundConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "CreateOutboundConnection");
            try
            {
                return client.CreateOutboundConnectionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConnectionAlias { get; set; }
            public Amazon.OpenSearchService.ConnectionMode ConnectionMode { get; set; }
            public Amazon.OpenSearchService.SkipUnavailableStatus CrossClusterSearch_SkipUnavailable { get; set; }
            public System.String ConnectionProperties_Endpoint { get; set; }
            public System.String LocalDomainInfo_AWSDomainInformation_DomainName { get; set; }
            public System.String LocalDomainInfo_AWSDomainInformation_OwnerId { get; set; }
            public System.String LocalDomainInfo_AWSDomainInformation_Region { get; set; }
            public System.String RemoteDomainInfo_AWSDomainInformation_DomainName { get; set; }
            public System.String RemoteDomainInfo_AWSDomainInformation_OwnerId { get; set; }
            public System.String RemoteDomainInfo_AWSDomainInformation_Region { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.CreateOutboundConnectionResponse, NewOSOutboundConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
