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
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.COMP
{
    /// <summary>
    /// Deletes an entity recognizer.
    /// 
    ///  
    /// <para>
    /// Only those recognizers that are in terminated states (IN_ERROR, TRAINED) will be deleted.
    /// If an active inference job is using the model, a <c>ResourceInUseException</c> will
    /// be returned.
    /// </para><para>
    /// This is an asynchronous action that puts the recognizer into a DELETING state, and
    /// it is then removed by a background job. Once removed, the recognizer disappears from
    /// your account and is no longer available for use. 
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "COMPEntityRecognizer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Comprehend DeleteEntityRecognizer API operation.", Operation = new[] {"DeleteEntityRecognizer"}, SelectReturnType = typeof(Amazon.Comprehend.Model.DeleteEntityRecognizerResponse))]
    [AWSCmdletOutput("None or Amazon.Comprehend.Model.DeleteEntityRecognizerResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Comprehend.Model.DeleteEntityRecognizerResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveCOMPEntityRecognizerCmdlet : AmazonComprehendClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EntityRecognizerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that identifies the entity recognizer.</para>
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
        public System.String EntityRecognizerArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Comprehend.Model.DeleteEntityRecognizerResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EntityRecognizerArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-COMPEntityRecognizer (DeleteEntityRecognizer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Comprehend.Model.DeleteEntityRecognizerResponse, RemoveCOMPEntityRecognizerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EntityRecognizerArn = this.EntityRecognizerArn;
            #if MODULAR
            if (this.EntityRecognizerArn == null && ParameterWasBound(nameof(this.EntityRecognizerArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityRecognizerArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Comprehend.Model.DeleteEntityRecognizerRequest();
            
            if (cmdletContext.EntityRecognizerArn != null)
            {
                request.EntityRecognizerArn = cmdletContext.EntityRecognizerArn;
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
        
        private Amazon.Comprehend.Model.DeleteEntityRecognizerResponse CallAWSServiceOperation(IAmazonComprehend client, Amazon.Comprehend.Model.DeleteEntityRecognizerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Comprehend", "DeleteEntityRecognizer");
            try
            {
                return client.DeleteEntityRecognizerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EntityRecognizerArn { get; set; }
            public System.Func<Amazon.Comprehend.Model.DeleteEntityRecognizerResponse, RemoveCOMPEntityRecognizerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
