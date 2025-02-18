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
using Amazon.MTurk;
using Amazon.MTurk.Model;

namespace Amazon.PowerShell.Cmdlets.MTR
{
    /// <summary>
    /// The <c>GetFileUploadURL</c> operation generates and returns a temporary URL. You
    /// use the temporary URL to retrieve a file uploaded by a Worker as an answer to a FileUploadAnswer
    /// question for a HIT. The temporary URL is generated the instant the GetFileUploadURL
    /// operation is called, and is valid for 60 seconds. You can get a temporary file upload
    /// URL any time until the HIT is disposed. After the HIT is disposed, any uploaded files
    /// are deleted, and cannot be retrieved. Pending Deprecation on December 12, 2017. The
    /// Answer Specification structure will no longer support the <c>FileUploadAnswer</c>
    /// element to be used for the QuestionForm data structure. Instead, we recommend that
    /// Requesters who want to create HITs asking Workers to upload files to use Amazon S3.
    /// </summary>
    [Cmdlet("Get", "MTRFileUploadURL")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon MTurk Service GetFileUploadURL API operation.", Operation = new[] {"GetFileUploadURL"}, SelectReturnType = typeof(Amazon.MTurk.Model.GetFileUploadURLResponse))]
    [AWSCmdletOutput("System.String or Amazon.MTurk.Model.GetFileUploadURLResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MTurk.Model.GetFileUploadURLResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMTRFileUploadURLCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssignmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the assignment that contains the question with a FileUploadAnswer.</para>
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
        public System.String AssignmentId { get; set; }
        #endregion
        
        #region Parameter QuestionIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the question with a FileUploadAnswer, as specified in the QuestionForm
        /// of the HIT.</para>
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
        public System.String QuestionIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FileUploadURL'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MTurk.Model.GetFileUploadURLResponse).
        /// Specifying the name of a property of type Amazon.MTurk.Model.GetFileUploadURLResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FileUploadURL";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MTurk.Model.GetFileUploadURLResponse, GetMTRFileUploadURLCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssignmentId = this.AssignmentId;
            #if MODULAR
            if (this.AssignmentId == null && ParameterWasBound(nameof(this.AssignmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssignmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QuestionIdentifier = this.QuestionIdentifier;
            #if MODULAR
            if (this.QuestionIdentifier == null && ParameterWasBound(nameof(this.QuestionIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter QuestionIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MTurk.Model.GetFileUploadURLRequest();
            
            if (cmdletContext.AssignmentId != null)
            {
                request.AssignmentId = cmdletContext.AssignmentId;
            }
            if (cmdletContext.QuestionIdentifier != null)
            {
                request.QuestionIdentifier = cmdletContext.QuestionIdentifier;
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
        
        private Amazon.MTurk.Model.GetFileUploadURLResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.GetFileUploadURLRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "GetFileUploadURL");
            try
            {
                return client.GetFileUploadURLAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssignmentId { get; set; }
            public System.String QuestionIdentifier { get; set; }
            public System.Func<Amazon.MTurk.Model.GetFileUploadURLResponse, GetMTRFileUploadURLCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FileUploadURL;
        }
        
    }
}
