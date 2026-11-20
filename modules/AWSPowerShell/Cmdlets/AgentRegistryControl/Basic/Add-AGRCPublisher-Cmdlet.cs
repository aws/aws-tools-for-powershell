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
using Amazon.AgentRegistryControl;
using Amazon.AgentRegistryControl.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AGRC
{
    /// <summary>
    /// Associate a registry record with a publisher and assign the record a public identifier
    /// under the publisher's domain. The registry record must be APPROVED and the publisher
    /// must be ACTIVE. A registry record can have only one publisher association. The new
    /// association starts in PENDING_APPROVAL until a curator approves or rejects it. A ConflictException
    /// (HTTP 409) means the publisher is not ACTIVE yet, the registry record already has
    /// an association, or another registry record already holds the public identifier. To
    /// retry safely, repeat the request with the same clientToken; a retry returns the original
    /// association. If the publisher has reached its association quota, the request fails
    /// with ServiceQuotaExceededException (HTTP 402). Remove an unused association or request
    /// a quota increase.
    /// </summary>
    [Cmdlet("Add", "AGRCPublisher", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AgentRegistryControl.Model.AssociatePublisherResponse")]
    [AWSCmdlet("Calls the Agent Registry Control AssociatePublisher API operation.", Operation = new[] {"AssociatePublisher"}, SelectReturnType = typeof(Amazon.AgentRegistryControl.Model.AssociatePublisherResponse))]
    [AWSCmdletOutput("Amazon.AgentRegistryControl.Model.AssociatePublisherResponse",
        "This cmdlet returns an Amazon.AgentRegistryControl.Model.AssociatePublisherResponse object containing multiple properties."
    )]
    public partial class AddAGRCPublisherCmdlet : AmazonAgentRegistryControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Category
        /// <summary>
        /// <para>
        /// Optional categorization/hierarchy applied to
        /// the public identifier.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Categories")]
        public System.String[] Category { get; set; }
        #endregion
        
        #region Parameter PublisherArn
        /// <summary>
        /// <para>
        /// The Publisher to associate the Record with.
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
        public System.String PublisherArn { get; set; }
        #endregion
        
        #region Parameter RecordArn
        /// <summary>
        /// <para>
        /// The Record being associated.
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
        public System.String RecordArn { get; set; }
        #endregion
        
        #region Parameter Subdomain
        /// <summary>
        /// <para>
        /// Optional single DNS label placed in front of
        /// the publisher domain (e.g. "agents" -&gt; agents.acme.com). Absent means the Record sits
        /// directly on the publisher domain.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Subdomain { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// Optional client-provided idempotency token.
        /// Retries carrying the same token return the originally-created association instead
        /// of creating a duplicate.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AgentRegistryControl.Model.AssociatePublisherResponse).
        /// Specifying the name of a property of type Amazon.AgentRegistryControl.Model.AssociatePublisherResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PublisherArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-AGRCPublisher (AssociatePublisher)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AgentRegistryControl.Model.AssociatePublisherResponse, AddAGRCPublisherCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Category != null)
            {
                context.Category = new List<System.String>(this.Category);
            }
            context.ClientToken = this.ClientToken;
            context.PublisherArn = this.PublisherArn;
            #if MODULAR
            if (this.PublisherArn == null && ParameterWasBound(nameof(this.PublisherArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PublisherArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecordArn = this.RecordArn;
            #if MODULAR
            if (this.RecordArn == null && ParameterWasBound(nameof(this.RecordArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RecordArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Subdomain = this.Subdomain;
            
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
            var request = new Amazon.AgentRegistryControl.Model.AssociatePublisherRequest();
            
            if (cmdletContext.Category != null)
            {
                request.Categories = cmdletContext.Category;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.PublisherArn != null)
            {
                request.PublisherArn = cmdletContext.PublisherArn;
            }
            if (cmdletContext.RecordArn != null)
            {
                request.RecordArn = cmdletContext.RecordArn;
            }
            if (cmdletContext.Subdomain != null)
            {
                request.Subdomain = cmdletContext.Subdomain;
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
        
        private Amazon.AgentRegistryControl.Model.AssociatePublisherResponse CallAWSServiceOperation(IAmazonAgentRegistryControl client, Amazon.AgentRegistryControl.Model.AssociatePublisherRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agent Registry Control", "AssociatePublisher");
            try
            {
                return client.AssociatePublisherAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Category { get; set; }
            public System.String ClientToken { get; set; }
            public System.String PublisherArn { get; set; }
            public System.String RecordArn { get; set; }
            public System.String Subdomain { get; set; }
            public System.Func<Amazon.AgentRegistryControl.Model.AssociatePublisherResponse, AddAGRCPublisherCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
