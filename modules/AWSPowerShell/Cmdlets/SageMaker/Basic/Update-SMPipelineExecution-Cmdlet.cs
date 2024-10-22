/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Updates a pipeline execution.
    /// </summary>
    [Cmdlet("Update", "SMPipelineExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdatePipelineExecution API operation.", Operation = new[] {"UpdatePipelineExecution"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdatePipelineExecutionResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdatePipelineExecutionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdatePipelineExecutionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMPipelineExecutionCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ParallelismConfiguration_MaxParallelExecutionStep
        /// <summary>
        /// <para>
        /// <para>The max number of steps that can be executed in parallel. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ParallelismConfiguration_MaxParallelExecutionSteps")]
        public System.Int32? ParallelismConfiguration_MaxParallelExecutionStep { get; set; }
        #endregion
        
        #region Parameter PipelineExecutionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the pipeline execution.</para>
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
        public System.String PipelineExecutionArn { get; set; }
        #endregion
        
        #region Parameter PipelineExecutionDescription
        /// <summary>
        /// <para>
        /// <para>The description of the pipeline execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PipelineExecutionDescription { get; set; }
        #endregion
        
        #region Parameter PipelineExecutionDisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the pipeline execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PipelineExecutionDisplayName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PipelineExecutionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdatePipelineExecutionResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdatePipelineExecutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PipelineExecutionArn";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PipelineExecutionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMPipelineExecution (UpdatePipelineExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdatePipelineExecutionResponse, UpdateSMPipelineExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ParallelismConfiguration_MaxParallelExecutionStep = this.ParallelismConfiguration_MaxParallelExecutionStep;
            context.PipelineExecutionArn = this.PipelineExecutionArn;
            #if MODULAR
            if (this.PipelineExecutionArn == null && ParameterWasBound(nameof(this.PipelineExecutionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineExecutionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PipelineExecutionDescription = this.PipelineExecutionDescription;
            context.PipelineExecutionDisplayName = this.PipelineExecutionDisplayName;
            
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
            var request = new Amazon.SageMaker.Model.UpdatePipelineExecutionRequest();
            
            
             // populate ParallelismConfiguration
            var requestParallelismConfigurationIsNull = true;
            request.ParallelismConfiguration = new Amazon.SageMaker.Model.ParallelismConfiguration();
            System.Int32? requestParallelismConfiguration_parallelismConfiguration_MaxParallelExecutionStep = null;
            if (cmdletContext.ParallelismConfiguration_MaxParallelExecutionStep != null)
            {
                requestParallelismConfiguration_parallelismConfiguration_MaxParallelExecutionStep = cmdletContext.ParallelismConfiguration_MaxParallelExecutionStep.Value;
            }
            if (requestParallelismConfiguration_parallelismConfiguration_MaxParallelExecutionStep != null)
            {
                request.ParallelismConfiguration.MaxParallelExecutionSteps = requestParallelismConfiguration_parallelismConfiguration_MaxParallelExecutionStep.Value;
                requestParallelismConfigurationIsNull = false;
            }
             // determine if request.ParallelismConfiguration should be set to null
            if (requestParallelismConfigurationIsNull)
            {
                request.ParallelismConfiguration = null;
            }
            if (cmdletContext.PipelineExecutionArn != null)
            {
                request.PipelineExecutionArn = cmdletContext.PipelineExecutionArn;
            }
            if (cmdletContext.PipelineExecutionDescription != null)
            {
                request.PipelineExecutionDescription = cmdletContext.PipelineExecutionDescription;
            }
            if (cmdletContext.PipelineExecutionDisplayName != null)
            {
                request.PipelineExecutionDisplayName = cmdletContext.PipelineExecutionDisplayName;
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
        
        private Amazon.SageMaker.Model.UpdatePipelineExecutionResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdatePipelineExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdatePipelineExecution");
            try
            {
                #if DESKTOP
                return client.UpdatePipelineExecution(request);
                #elif CORECLR
                return client.UpdatePipelineExecutionAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? ParallelismConfiguration_MaxParallelExecutionStep { get; set; }
            public System.String PipelineExecutionArn { get; set; }
            public System.String PipelineExecutionDescription { get; set; }
            public System.String PipelineExecutionDisplayName { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdatePipelineExecutionResponse, UpdateSMPipelineExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PipelineExecutionArn;
        }
        
    }
}
