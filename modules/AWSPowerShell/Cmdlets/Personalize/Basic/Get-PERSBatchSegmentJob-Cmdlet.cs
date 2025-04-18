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
    /// Gets the properties of a batch segment job including name, Amazon Resource Name (ARN),
    /// status, input and output configurations, and the ARN of the solution version used
    /// to generate segments.
    /// </summary>
    [Cmdlet("Get", "PERSBatchSegmentJob")]
    [OutputType("Amazon.Personalize.Model.BatchSegmentJob")]
    [AWSCmdlet("Calls the AWS Personalize DescribeBatchSegmentJob API operation.", Operation = new[] {"DescribeBatchSegmentJob"}, SelectReturnType = typeof(Amazon.Personalize.Model.DescribeBatchSegmentJobResponse))]
    [AWSCmdletOutput("Amazon.Personalize.Model.BatchSegmentJob or Amazon.Personalize.Model.DescribeBatchSegmentJobResponse",
        "This cmdlet returns an Amazon.Personalize.Model.BatchSegmentJob object.",
        "The service call response (type Amazon.Personalize.Model.DescribeBatchSegmentJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPERSBatchSegmentJobCmdlet : AmazonPersonalizeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BatchSegmentJobArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the batch segment job to describe.</para>
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
        public System.String BatchSegmentJobArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BatchSegmentJob'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Personalize.Model.DescribeBatchSegmentJobResponse).
        /// Specifying the name of a property of type Amazon.Personalize.Model.DescribeBatchSegmentJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BatchSegmentJob";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BatchSegmentJobArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BatchSegmentJobArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BatchSegmentJobArn' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Personalize.Model.DescribeBatchSegmentJobResponse, GetPERSBatchSegmentJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BatchSegmentJobArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BatchSegmentJobArn = this.BatchSegmentJobArn;
            #if MODULAR
            if (this.BatchSegmentJobArn == null && ParameterWasBound(nameof(this.BatchSegmentJobArn)))
            {
                WriteWarning("You are passing $null as a value for parameter BatchSegmentJobArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Personalize.Model.DescribeBatchSegmentJobRequest();
            
            if (cmdletContext.BatchSegmentJobArn != null)
            {
                request.BatchSegmentJobArn = cmdletContext.BatchSegmentJobArn;
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
        
        private Amazon.Personalize.Model.DescribeBatchSegmentJobResponse CallAWSServiceOperation(IAmazonPersonalize client, Amazon.Personalize.Model.DescribeBatchSegmentJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Personalize", "DescribeBatchSegmentJob");
            try
            {
                #if DESKTOP
                return client.DescribeBatchSegmentJob(request);
                #elif CORECLR
                return client.DescribeBatchSegmentJobAsync(request).GetAwaiter().GetResult();
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
            public System.String BatchSegmentJobArn { get; set; }
            public System.Func<Amazon.Personalize.Model.DescribeBatchSegmentJobResponse, GetPERSBatchSegmentJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BatchSegmentJob;
        }
        
    }
}
