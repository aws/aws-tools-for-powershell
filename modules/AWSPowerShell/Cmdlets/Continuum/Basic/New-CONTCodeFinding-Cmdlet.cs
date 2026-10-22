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
using Amazon.Continuum;
using Amazon.Continuum.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONT
{
    /// <summary>
    /// Ingests a customer-supplied security finding into an environment. Continuum validates
    /// the document synchronously against the required overlay fields for the declared format;
    /// invalid documents are rejected with a ValidationException. The maximum accepted document
    /// size is 256 KB. The environment must have a source configured, and the finding must
    /// identify a code location so Continuum can tie it to a repository in the environment's
    /// build. Continuum assigns a findingId and stores the verbatim document. When no successful
    /// build yet contains the finding's repository, the finding stays SUBMITTED until the
    /// next successful build; if that build does not contain it either, the finding is DISCARDED
    /// with discardReason SOURCE_REPO_NOT_FOUND.
    /// </summary>
    [Cmdlet("New", "CONTCodeFinding", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Continuum.Model.CreateCodeFindingResponse")]
    [AWSCmdlet("Calls the AWS Continuum CreateCodeFinding API operation.", Operation = new[] {"CreateCodeFinding"}, SelectReturnType = typeof(Amazon.Continuum.Model.CreateCodeFindingResponse))]
    [AWSCmdletOutput("Amazon.Continuum.Model.CreateCodeFindingResponse",
        "This cmdlet returns an Amazon.Continuum.Model.CreateCodeFindingResponse object containing multiple properties."
    )]
    public partial class NewCONTCodeFindingCmdlet : AmazonContinuumClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// The environment to ingest the finding into.
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
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter OcsfDocument
        /// <summary>
        /// <para>
        /// The OCSF finding document to ingest, verbatim.
        /// Must declare a class_uid Continuum supports (2002 Vulnerability Finding, or 2007 Application
        /// Security Posture Finding) and validate against the vendored OCSF JSON Schema for that
        /// class, including the Continuum overlay requirements that finding_info.uid be present
        /// and that vulnerabilities[0].affected_code[0].file identify the code location. With
        /// several repositories in the environment, the file path must begin with the repository
        /// name. Maximum size 256 KB. Stored verbatim and normalized into the typed Finding members
        /// returned by GetCodeFinding. GetCodeFinding does not return the document itself.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Management.Automation.PSObject OcsfDocument { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// Caller-provided idempotency token. A retry
        /// with the same token and an identical finding document replays the original result;
        /// the same token with different content is rejected.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Continuum.Model.CreateCodeFindingResponse).
        /// Specifying the name of a property of type Amazon.Continuum.Model.CreateCodeFindingResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EnvironmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONTCodeFinding (CreateCodeFinding)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Continuum.Model.CreateCodeFindingResponse, NewCONTCodeFindingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.EnvironmentId = this.EnvironmentId;
            #if MODULAR
            if (this.EnvironmentId == null && ParameterWasBound(nameof(this.EnvironmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OcsfDocument = this.OcsfDocument;
            #if MODULAR
            if (this.OcsfDocument == null && ParameterWasBound(nameof(this.OcsfDocument)))
            {
                WriteWarning("You are passing $null as a value for parameter OcsfDocument which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Continuum.Model.CreateCodeFindingRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.OcsfDocument != null)
            {
                request.OcsfDocument = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.OcsfDocument);
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
        
        private Amazon.Continuum.Model.CreateCodeFindingResponse CallAWSServiceOperation(IAmazonContinuum client, Amazon.Continuum.Model.CreateCodeFindingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Continuum", "CreateCodeFinding");
            try
            {
                return client.CreateCodeFindingAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String EnvironmentId { get; set; }
            public System.Management.Automation.PSObject OcsfDocument { get; set; }
            public System.Func<Amazon.Continuum.Model.CreateCodeFindingResponse, NewCONTCodeFindingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
