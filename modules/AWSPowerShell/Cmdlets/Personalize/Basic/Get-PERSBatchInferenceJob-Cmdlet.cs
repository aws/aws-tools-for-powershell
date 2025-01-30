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
using Amazon.Personalize;
using Amazon.Personalize.Model;

namespace Amazon.PowerShell.Cmdlets.PERS
{
    /// <summary>
    /// Gets the properties of a batch inference job including name, Amazon Resource Name
    /// (ARN), status, input and output configurations, and the ARN of the solution version
    /// used to generate the recommendations.
    /// </summary>
    [Cmdlet("Get", "PERSBatchInferenceJob")]
    [OutputType("Amazon.Personalize.Model.BatchInferenceJob")]
    [AWSCmdlet("Calls the AWS Personalize DescribeBatchInferenceJob API operation.", Operation = new[] {"DescribeBatchInferenceJob"}, SelectReturnType = typeof(Amazon.Personalize.Model.DescribeBatchInferenceJobResponse))]
    [AWSCmdletOutput("Amazon.Personalize.Model.BatchInferenceJob or Amazon.Personalize.Model.DescribeBatchInferenceJobResponse",
        "This cmdlet returns an Amazon.Personalize.Model.BatchInferenceJob object.",
        "The service call response (type Amazon.Personalize.Model.DescribeBatchInferenceJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPERSBatchInferenceJobCmdlet : AmazonPersonalizeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BatchInferenceJobArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the batch inference job to describe.</para>
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
        public System.String BatchInferenceJobArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BatchInferenceJob'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Personalize.Model.DescribeBatchInferenceJobResponse).
        /// Specifying the name of a property of type Amazon.Personalize.Model.DescribeBatchInferenceJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BatchInferenceJob";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BatchInferenceJobArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BatchInferenceJobArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BatchInferenceJobArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Personalize.Model.DescribeBatchInferenceJobResponse, GetPERSBatchInferenceJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BatchInferenceJobArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BatchInferenceJobArn = this.BatchInferenceJobArn;
            #if MODULAR
            if (this.BatchInferenceJobArn == null && ParameterWasBound(nameof(this.BatchInferenceJobArn)))
            {
                WriteWarning("You are passing $null as a value for parameter BatchInferenceJobArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Personalize.Model.DescribeBatchInferenceJobRequest();
            
            if (cmdletContext.BatchInferenceJobArn != null)
            {
                request.BatchInferenceJobArn = cmdletContext.BatchInferenceJobArn;
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
        
        private Amazon.Personalize.Model.DescribeBatchInferenceJobResponse CallAWSServiceOperation(IAmazonPersonalize client, Amazon.Personalize.Model.DescribeBatchInferenceJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Personalize", "DescribeBatchInferenceJob");
            try
            {
                #if DESKTOP
                return client.DescribeBatchInferenceJob(request);
                #elif CORECLR
                return client.DescribeBatchInferenceJobAsync(request).GetAwaiter().GetResult();
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
            public System.String BatchInferenceJobArn { get; set; }
            public System.Func<Amazon.Personalize.Model.DescribeBatchInferenceJobResponse, GetPERSBatchInferenceJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BatchInferenceJob;
        }
        
    }
}
