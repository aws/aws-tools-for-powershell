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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Describes the details of a pipeline.
    /// </summary>
    [Cmdlet("Get", "SMPipeline")]
    [OutputType("Amazon.SageMaker.Model.DescribePipelineResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service DescribePipeline API operation.", Operation = new[] {"DescribePipeline"}, SelectReturnType = typeof(Amazon.SageMaker.Model.DescribePipelineResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.DescribePipelineResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.DescribePipelineResponse object containing multiple properties."
    )]
    public partial class GetSMPipelineCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PipelineName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the pipeline to describe.</para>
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
        public System.String PipelineName { get; set; }
        #endregion
        
        #region Parameter PipelineVersionId
        /// <summary>
        /// <para>
        /// <para>The ID of the pipeline version to describe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? PipelineVersionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.DescribePipelineResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.DescribePipelineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PipelineName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PipelineName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PipelineName' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.DescribePipelineResponse, GetSMPipelineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PipelineName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PipelineName = this.PipelineName;
            #if MODULAR
            if (this.PipelineName == null && ParameterWasBound(nameof(this.PipelineName)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PipelineVersionId = this.PipelineVersionId;
            
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
            var request = new Amazon.SageMaker.Model.DescribePipelineRequest();
            
            if (cmdletContext.PipelineName != null)
            {
                request.PipelineName = cmdletContext.PipelineName;
            }
            if (cmdletContext.PipelineVersionId != null)
            {
                request.PipelineVersionId = cmdletContext.PipelineVersionId.Value;
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
        
        private Amazon.SageMaker.Model.DescribePipelineResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.DescribePipelineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "DescribePipeline");
            try
            {
                #if DESKTOP
                return client.DescribePipeline(request);
                #elif CORECLR
                return client.DescribePipelineAsync(request).GetAwaiter().GetResult();
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
            public System.String PipelineName { get; set; }
            public System.Int64? PipelineVersionId { get; set; }
            public System.Func<Amazon.SageMaker.Model.DescribePipelineResponse, GetSMPipelineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
