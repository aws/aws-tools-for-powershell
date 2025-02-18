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
using Amazon.AppFabric;
using Amazon.AppFabric.Model;

namespace Amazon.PowerShell.Cmdlets.AFAB
{
    /// <summary>
    /// Creates a data ingestion for an application.
    /// </summary>
    [Cmdlet("New", "AFABIngestion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppFabric.Model.Ingestion")]
    [AWSCmdlet("Calls the Amazon Web Services AppFabric CreateIngestion API operation.", Operation = new[] {"CreateIngestion"}, SelectReturnType = typeof(Amazon.AppFabric.Model.CreateIngestionResponse))]
    [AWSCmdletOutput("Amazon.AppFabric.Model.Ingestion or Amazon.AppFabric.Model.CreateIngestionResponse",
        "This cmdlet returns an Amazon.AppFabric.Model.Ingestion object.",
        "The service call response (type Amazon.AppFabric.Model.CreateIngestionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAFABIngestionCmdlet : AmazonAppFabricClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter App
        /// <summary>
        /// <para>
        /// <para>The name of the application.</para><para>Valid values are:</para><ul><li><para><c>SLACK</c></para></li><li><para><c>ASANA</c></para></li><li><para><c>JIRA</c></para></li><li><para><c>M365</c></para></li><li><para><c>M365AUDITLOGS</c></para></li><li><para><c>ZOOM</c></para></li><li><para><c>ZENDESK</c></para></li><li><para><c>OKTA</c></para></li><li><para><c>GOOGLE</c></para></li><li><para><c>DROPBOX</c></para></li><li><para><c>SMARTSHEET</c></para></li><li><para><c>CISCO</c></para></li></ul>
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
        public System.String App { get; set; }
        #endregion
        
        #region Parameter AppBundleIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) or Universal Unique Identifier (UUID) of the app bundle
        /// to use for the request.</para>
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
        public System.String AppBundleIdentifier { get; set; }
        #endregion
        
        #region Parameter IngestionType
        /// <summary>
        /// <para>
        /// <para>The ingestion type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AppFabric.IngestionType")]
        public Amazon.AppFabric.IngestionType IngestionType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of the key-value pairs of the tag or tags to assign to the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.AppFabric.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TenantId
        /// <summary>
        /// <para>
        /// <para>The ID of the application tenant.</para>
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
        public System.String TenantId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Specifies a unique, case-sensitive identifier that you provide to ensure the idempotency
        /// of the request. This lets you safely retry the request without accidentally performing
        /// the same operation a second time. Passing the same value to a later call to an operation
        /// requires that you also pass the same value for all other parameters. We recommend
        /// that you use a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID
        /// type of value</a>.</para><para>If you don't provide this value, then Amazon Web Services generates a random one for
        /// you.</para><para>If you retry the operation with the same <c>ClientToken</c>, but with different parameters,
        /// the retry fails with an <c>IdempotentParameterMismatch</c> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Ingestion'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppFabric.Model.CreateIngestionResponse).
        /// Specifying the name of a property of type Amazon.AppFabric.Model.CreateIngestionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Ingestion";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppBundleIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AFABIngestion (CreateIngestion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppFabric.Model.CreateIngestionResponse, NewAFABIngestionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.App = this.App;
            #if MODULAR
            if (this.App == null && ParameterWasBound(nameof(this.App)))
            {
                WriteWarning("You are passing $null as a value for parameter App which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AppBundleIdentifier = this.AppBundleIdentifier;
            #if MODULAR
            if (this.AppBundleIdentifier == null && ParameterWasBound(nameof(this.AppBundleIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter AppBundleIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.IngestionType = this.IngestionType;
            #if MODULAR
            if (this.IngestionType == null && ParameterWasBound(nameof(this.IngestionType)))
            {
                WriteWarning("You are passing $null as a value for parameter IngestionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.AppFabric.Model.Tag>(this.Tag);
            }
            context.TenantId = this.TenantId;
            #if MODULAR
            if (this.TenantId == null && ParameterWasBound(nameof(this.TenantId)))
            {
                WriteWarning("You are passing $null as a value for parameter TenantId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.AppFabric.Model.CreateIngestionRequest();
            
            if (cmdletContext.App != null)
            {
                request.App = cmdletContext.App;
            }
            if (cmdletContext.AppBundleIdentifier != null)
            {
                request.AppBundleIdentifier = cmdletContext.AppBundleIdentifier;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.IngestionType != null)
            {
                request.IngestionType = cmdletContext.IngestionType;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TenantId != null)
            {
                request.TenantId = cmdletContext.TenantId;
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
        
        private Amazon.AppFabric.Model.CreateIngestionResponse CallAWSServiceOperation(IAmazonAppFabric client, Amazon.AppFabric.Model.CreateIngestionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Web Services AppFabric", "CreateIngestion");
            try
            {
                return client.CreateIngestionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String App { get; set; }
            public System.String AppBundleIdentifier { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.AppFabric.IngestionType IngestionType { get; set; }
            public List<Amazon.AppFabric.Model.Tag> Tag { get; set; }
            public System.String TenantId { get; set; }
            public System.Func<Amazon.AppFabric.Model.CreateIngestionResponse, NewAFABIngestionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Ingestion;
        }
        
    }
}
