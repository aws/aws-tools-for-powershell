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
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;

namespace Amazon.PowerShell.Cmdlets.ES
{
    /// <summary>
    /// Creates a new cross-cluster search connection from a source domain to a destination
    /// domain.
    /// </summary>
    [Cmdlet("New", "ESOutboundCrossClusterSearchConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Elasticsearch.Model.CreateOutboundCrossClusterSearchConnectionResponse")]
    [AWSCmdlet("Calls the Amazon Elasticsearch CreateOutboundCrossClusterSearchConnection API operation.", Operation = new[] {"CreateOutboundCrossClusterSearchConnection"}, SelectReturnType = typeof(Amazon.Elasticsearch.Model.CreateOutboundCrossClusterSearchConnectionResponse))]
    [AWSCmdletOutput("Amazon.Elasticsearch.Model.CreateOutboundCrossClusterSearchConnectionResponse",
        "This cmdlet returns an Amazon.Elasticsearch.Model.CreateOutboundCrossClusterSearchConnectionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewESOutboundCrossClusterSearchConnectionCmdlet : AmazonElasticsearchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConnectionAlias
        /// <summary>
        /// <para>
        /// <para>Specifies the connection alias that will be used by the customer for this connection.</para>
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
        
        #region Parameter DestinationDomainInfo_DomainName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DestinationDomainInfo_DomainName { get; set; }
        #endregion
        
        #region Parameter SourceDomainInfo_DomainName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SourceDomainInfo_DomainName { get; set; }
        #endregion
        
        #region Parameter DestinationDomainInfo_OwnerId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationDomainInfo_OwnerId { get; set; }
        #endregion
        
        #region Parameter SourceDomainInfo_OwnerId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceDomainInfo_OwnerId { get; set; }
        #endregion
        
        #region Parameter DestinationDomainInfo_Region
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationDomainInfo_Region { get; set; }
        #endregion
        
        #region Parameter SourceDomainInfo_Region
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceDomainInfo_Region { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Elasticsearch.Model.CreateOutboundCrossClusterSearchConnectionResponse).
        /// Specifying the name of a property of type Amazon.Elasticsearch.Model.CreateOutboundCrossClusterSearchConnectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConnectionAlias parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConnectionAlias' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConnectionAlias' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ESOutboundCrossClusterSearchConnection (CreateOutboundCrossClusterSearchConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Elasticsearch.Model.CreateOutboundCrossClusterSearchConnectionResponse, NewESOutboundCrossClusterSearchConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConnectionAlias;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConnectionAlias = this.ConnectionAlias;
            #if MODULAR
            if (this.ConnectionAlias == null && ParameterWasBound(nameof(this.ConnectionAlias)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionAlias which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationDomainInfo_DomainName = this.DestinationDomainInfo_DomainName;
            #if MODULAR
            if (this.DestinationDomainInfo_DomainName == null && ParameterWasBound(nameof(this.DestinationDomainInfo_DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationDomainInfo_DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationDomainInfo_OwnerId = this.DestinationDomainInfo_OwnerId;
            context.DestinationDomainInfo_Region = this.DestinationDomainInfo_Region;
            context.SourceDomainInfo_DomainName = this.SourceDomainInfo_DomainName;
            #if MODULAR
            if (this.SourceDomainInfo_DomainName == null && ParameterWasBound(nameof(this.SourceDomainInfo_DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceDomainInfo_DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceDomainInfo_OwnerId = this.SourceDomainInfo_OwnerId;
            context.SourceDomainInfo_Region = this.SourceDomainInfo_Region;
            
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
            var request = new Amazon.Elasticsearch.Model.CreateOutboundCrossClusterSearchConnectionRequest();
            
            if (cmdletContext.ConnectionAlias != null)
            {
                request.ConnectionAlias = cmdletContext.ConnectionAlias;
            }
            
             // populate DestinationDomainInfo
            var requestDestinationDomainInfoIsNull = true;
            request.DestinationDomainInfo = new Amazon.Elasticsearch.Model.DomainInformation();
            System.String requestDestinationDomainInfo_destinationDomainInfo_DomainName = null;
            if (cmdletContext.DestinationDomainInfo_DomainName != null)
            {
                requestDestinationDomainInfo_destinationDomainInfo_DomainName = cmdletContext.DestinationDomainInfo_DomainName;
            }
            if (requestDestinationDomainInfo_destinationDomainInfo_DomainName != null)
            {
                request.DestinationDomainInfo.DomainName = requestDestinationDomainInfo_destinationDomainInfo_DomainName;
                requestDestinationDomainInfoIsNull = false;
            }
            System.String requestDestinationDomainInfo_destinationDomainInfo_OwnerId = null;
            if (cmdletContext.DestinationDomainInfo_OwnerId != null)
            {
                requestDestinationDomainInfo_destinationDomainInfo_OwnerId = cmdletContext.DestinationDomainInfo_OwnerId;
            }
            if (requestDestinationDomainInfo_destinationDomainInfo_OwnerId != null)
            {
                request.DestinationDomainInfo.OwnerId = requestDestinationDomainInfo_destinationDomainInfo_OwnerId;
                requestDestinationDomainInfoIsNull = false;
            }
            System.String requestDestinationDomainInfo_destinationDomainInfo_Region = null;
            if (cmdletContext.DestinationDomainInfo_Region != null)
            {
                requestDestinationDomainInfo_destinationDomainInfo_Region = cmdletContext.DestinationDomainInfo_Region;
            }
            if (requestDestinationDomainInfo_destinationDomainInfo_Region != null)
            {
                request.DestinationDomainInfo.Region = requestDestinationDomainInfo_destinationDomainInfo_Region;
                requestDestinationDomainInfoIsNull = false;
            }
             // determine if request.DestinationDomainInfo should be set to null
            if (requestDestinationDomainInfoIsNull)
            {
                request.DestinationDomainInfo = null;
            }
            
             // populate SourceDomainInfo
            var requestSourceDomainInfoIsNull = true;
            request.SourceDomainInfo = new Amazon.Elasticsearch.Model.DomainInformation();
            System.String requestSourceDomainInfo_sourceDomainInfo_DomainName = null;
            if (cmdletContext.SourceDomainInfo_DomainName != null)
            {
                requestSourceDomainInfo_sourceDomainInfo_DomainName = cmdletContext.SourceDomainInfo_DomainName;
            }
            if (requestSourceDomainInfo_sourceDomainInfo_DomainName != null)
            {
                request.SourceDomainInfo.DomainName = requestSourceDomainInfo_sourceDomainInfo_DomainName;
                requestSourceDomainInfoIsNull = false;
            }
            System.String requestSourceDomainInfo_sourceDomainInfo_OwnerId = null;
            if (cmdletContext.SourceDomainInfo_OwnerId != null)
            {
                requestSourceDomainInfo_sourceDomainInfo_OwnerId = cmdletContext.SourceDomainInfo_OwnerId;
            }
            if (requestSourceDomainInfo_sourceDomainInfo_OwnerId != null)
            {
                request.SourceDomainInfo.OwnerId = requestSourceDomainInfo_sourceDomainInfo_OwnerId;
                requestSourceDomainInfoIsNull = false;
            }
            System.String requestSourceDomainInfo_sourceDomainInfo_Region = null;
            if (cmdletContext.SourceDomainInfo_Region != null)
            {
                requestSourceDomainInfo_sourceDomainInfo_Region = cmdletContext.SourceDomainInfo_Region;
            }
            if (requestSourceDomainInfo_sourceDomainInfo_Region != null)
            {
                request.SourceDomainInfo.Region = requestSourceDomainInfo_sourceDomainInfo_Region;
                requestSourceDomainInfoIsNull = false;
            }
             // determine if request.SourceDomainInfo should be set to null
            if (requestSourceDomainInfoIsNull)
            {
                request.SourceDomainInfo = null;
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
        
        private Amazon.Elasticsearch.Model.CreateOutboundCrossClusterSearchConnectionResponse CallAWSServiceOperation(IAmazonElasticsearch client, Amazon.Elasticsearch.Model.CreateOutboundCrossClusterSearchConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elasticsearch", "CreateOutboundCrossClusterSearchConnection");
            try
            {
                #if DESKTOP
                return client.CreateOutboundCrossClusterSearchConnection(request);
                #elif CORECLR
                return client.CreateOutboundCrossClusterSearchConnectionAsync(request).GetAwaiter().GetResult();
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
            public System.String ConnectionAlias { get; set; }
            public System.String DestinationDomainInfo_DomainName { get; set; }
            public System.String DestinationDomainInfo_OwnerId { get; set; }
            public System.String DestinationDomainInfo_Region { get; set; }
            public System.String SourceDomainInfo_DomainName { get; set; }
            public System.String SourceDomainInfo_OwnerId { get; set; }
            public System.String SourceDomainInfo_Region { get; set; }
            public System.Func<Amazon.Elasticsearch.Model.CreateOutboundCrossClusterSearchConnectionResponse, NewESOutboundCrossClusterSearchConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
