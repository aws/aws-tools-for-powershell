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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Updates information related to approval reviews for a specific version of a change
    /// template in Change Manager.
    /// </summary>
    [Cmdlet("Update", "SSMDocumentMetadata", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Systems Manager UpdateDocumentMetadata API operation.", Operation = new[] {"UpdateDocumentMetadata"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.UpdateDocumentMetadataResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleSystemsManagement.Model.UpdateDocumentMetadataResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleSystemsManagement.Model.UpdateDocumentMetadataResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSSMDocumentMetadataCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DocumentReviews_Action
        /// <summary>
        /// <para>
        /// <para>The action to take on a document approval review request.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.DocumentReviewAction")]
        public Amazon.SimpleSystemsManagement.DocumentReviewAction DocumentReviews_Action { get; set; }
        #endregion
        
        #region Parameter DocumentReviews_Comment
        /// <summary>
        /// <para>
        /// <para>A comment entered by a user in your organization about the document review request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SimpleSystemsManagement.Model.DocumentReviewCommentSource[] DocumentReviews_Comment { get; set; }
        #endregion
        
        #region Parameter DocumentVersion
        /// <summary>
        /// <para>
        /// <para>The version of a change template in which to update approval metadata.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DocumentVersion { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the change template for which a version's metadata is to be updated.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.UpdateDocumentMetadataResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSMDocumentMetadata (UpdateDocumentMetadata)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.UpdateDocumentMetadataResponse, UpdateSSMDocumentMetadataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DocumentReviews_Action = this.DocumentReviews_Action;
            #if MODULAR
            if (this.DocumentReviews_Action == null && ParameterWasBound(nameof(this.DocumentReviews_Action)))
            {
                WriteWarning("You are passing $null as a value for parameter DocumentReviews_Action which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DocumentReviews_Comment != null)
            {
                context.DocumentReviews_Comment = new List<Amazon.SimpleSystemsManagement.Model.DocumentReviewCommentSource>(this.DocumentReviews_Comment);
            }
            context.DocumentVersion = this.DocumentVersion;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleSystemsManagement.Model.UpdateDocumentMetadataRequest();
            
            
             // populate DocumentReviews
            var requestDocumentReviewsIsNull = true;
            request.DocumentReviews = new Amazon.SimpleSystemsManagement.Model.DocumentReviews();
            Amazon.SimpleSystemsManagement.DocumentReviewAction requestDocumentReviews_documentReviews_Action = null;
            if (cmdletContext.DocumentReviews_Action != null)
            {
                requestDocumentReviews_documentReviews_Action = cmdletContext.DocumentReviews_Action;
            }
            if (requestDocumentReviews_documentReviews_Action != null)
            {
                request.DocumentReviews.Action = requestDocumentReviews_documentReviews_Action;
                requestDocumentReviewsIsNull = false;
            }
            List<Amazon.SimpleSystemsManagement.Model.DocumentReviewCommentSource> requestDocumentReviews_documentReviews_Comment = null;
            if (cmdletContext.DocumentReviews_Comment != null)
            {
                requestDocumentReviews_documentReviews_Comment = cmdletContext.DocumentReviews_Comment;
            }
            if (requestDocumentReviews_documentReviews_Comment != null)
            {
                request.DocumentReviews.Comment = requestDocumentReviews_documentReviews_Comment;
                requestDocumentReviewsIsNull = false;
            }
             // determine if request.DocumentReviews should be set to null
            if (requestDocumentReviewsIsNull)
            {
                request.DocumentReviews = null;
            }
            if (cmdletContext.DocumentVersion != null)
            {
                request.DocumentVersion = cmdletContext.DocumentVersion;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.SimpleSystemsManagement.Model.UpdateDocumentMetadataResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.UpdateDocumentMetadataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "UpdateDocumentMetadata");
            try
            {
                return client.UpdateDocumentMetadataAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.SimpleSystemsManagement.DocumentReviewAction DocumentReviews_Action { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.DocumentReviewCommentSource> DocumentReviews_Comment { get; set; }
            public System.String DocumentVersion { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.UpdateDocumentMetadataResponse, UpdateSSMDocumentMetadataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
