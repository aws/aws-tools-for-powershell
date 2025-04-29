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
using Amazon.AuditManager;
using Amazon.AuditManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AUDM
{
    /// <summary>
    /// Creates a share request for a custom framework in Audit Manager. 
    /// 
    ///  
    /// <para>
    /// The share request specifies a recipient and notifies them that a custom framework
    /// is available. Recipients have 120 days to accept or decline the request. If no action
    /// is taken, the share request expires.
    /// </para><para>
    /// When you create a share request, Audit Manager stores a snapshot of your custom framework
    /// in the US East (N. Virginia) Amazon Web Services Region. Audit Manager also stores
    /// a backup of the same snapshot in the US West (Oregon) Amazon Web Services Region.
    /// </para><para>
    /// Audit Manager deletes the snapshot and the backup snapshot when one of the following
    /// events occurs:
    /// </para><ul><li><para>
    /// The sender revokes the share request.
    /// </para></li><li><para>
    /// The recipient declines the share request.
    /// </para></li><li><para>
    /// The recipient encounters an error and doesn't successfully accept the share request.
    /// </para></li><li><para>
    /// The share request expires before the recipient responds to the request.
    /// </para></li></ul><para>
    /// When a sender <a href="https://docs.aws.amazon.com/audit-manager/latest/userguide/framework-sharing.html#framework-sharing-resend">resends
    /// a share request</a>, the snapshot is replaced with an updated version that corresponds
    /// with the latest version of the custom framework. 
    /// </para><para>
    /// When a recipient accepts a share request, the snapshot is replicated into their Amazon
    /// Web Services account under the Amazon Web Services Region that was specified in the
    /// share request. 
    /// </para><important><para>
    /// When you invoke the <c>StartAssessmentFrameworkShare</c> API, you are about to share
    /// a custom framework with another Amazon Web Services account. You may not share a custom
    /// framework that is derived from a standard framework if the standard framework is designated
    /// as not eligible for sharing by Amazon Web Services, unless you have obtained permission
    /// to do so from the owner of the standard framework. To learn more about which standard
    /// frameworks are eligible for sharing, see <a href="https://docs.aws.amazon.com/audit-manager/latest/userguide/share-custom-framework-concepts-and-terminology.html#eligibility">Framework
    /// sharing eligibility</a> in the <i>Audit Manager User Guide</i>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Start", "AUDMAssessmentFrameworkShare", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AuditManager.Model.AssessmentFrameworkShareRequest")]
    [AWSCmdlet("Calls the AWS Audit Manager StartAssessmentFrameworkShare API operation.", Operation = new[] {"StartAssessmentFrameworkShare"}, SelectReturnType = typeof(Amazon.AuditManager.Model.StartAssessmentFrameworkShareResponse))]
    [AWSCmdletOutput("Amazon.AuditManager.Model.AssessmentFrameworkShareRequest or Amazon.AuditManager.Model.StartAssessmentFrameworkShareResponse",
        "This cmdlet returns an Amazon.AuditManager.Model.AssessmentFrameworkShareRequest object.",
        "The service call response (type Amazon.AuditManager.Model.StartAssessmentFrameworkShareResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartAUDMAssessmentFrameworkShareCmdlet : AmazonAuditManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para> An optional comment from the sender about the share request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter DestinationAccount
        /// <summary>
        /// <para>
        /// <para> The Amazon Web Services account of the recipient. </para>
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
        public System.String DestinationAccount { get; set; }
        #endregion
        
        #region Parameter DestinationRegion
        /// <summary>
        /// <para>
        /// <para> The Amazon Web Services Region of the recipient. </para>
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
        public System.String DestinationRegion { get; set; }
        #endregion
        
        #region Parameter FrameworkId
        /// <summary>
        /// <para>
        /// <para> The unique identifier for the custom framework to be shared. </para>
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
        public System.String FrameworkId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AssessmentFrameworkShareRequest'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AuditManager.Model.StartAssessmentFrameworkShareResponse).
        /// Specifying the name of a property of type Amazon.AuditManager.Model.StartAssessmentFrameworkShareResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AssessmentFrameworkShareRequest";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FrameworkId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-AUDMAssessmentFrameworkShare (StartAssessmentFrameworkShare)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AuditManager.Model.StartAssessmentFrameworkShareResponse, StartAUDMAssessmentFrameworkShareCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Comment = this.Comment;
            context.DestinationAccount = this.DestinationAccount;
            #if MODULAR
            if (this.DestinationAccount == null && ParameterWasBound(nameof(this.DestinationAccount)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationAccount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationRegion = this.DestinationRegion;
            #if MODULAR
            if (this.DestinationRegion == null && ParameterWasBound(nameof(this.DestinationRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FrameworkId = this.FrameworkId;
            #if MODULAR
            if (this.FrameworkId == null && ParameterWasBound(nameof(this.FrameworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter FrameworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AuditManager.Model.StartAssessmentFrameworkShareRequest();
            
            if (cmdletContext.Comment != null)
            {
                request.Comment = cmdletContext.Comment;
            }
            if (cmdletContext.DestinationAccount != null)
            {
                request.DestinationAccount = cmdletContext.DestinationAccount;
            }
            if (cmdletContext.DestinationRegion != null)
            {
                request.DestinationRegion = cmdletContext.DestinationRegion;
            }
            if (cmdletContext.FrameworkId != null)
            {
                request.FrameworkId = cmdletContext.FrameworkId;
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
        
        private Amazon.AuditManager.Model.StartAssessmentFrameworkShareResponse CallAWSServiceOperation(IAmazonAuditManager client, Amazon.AuditManager.Model.StartAssessmentFrameworkShareRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Audit Manager", "StartAssessmentFrameworkShare");
            try
            {
                return client.StartAssessmentFrameworkShareAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Comment { get; set; }
            public System.String DestinationAccount { get; set; }
            public System.String DestinationRegion { get; set; }
            public System.String FrameworkId { get; set; }
            public System.Func<Amazon.AuditManager.Model.StartAssessmentFrameworkShareResponse, StartAUDMAssessmentFrameworkShareCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssessmentFrameworkShareRequest;
        }
        
    }
}
