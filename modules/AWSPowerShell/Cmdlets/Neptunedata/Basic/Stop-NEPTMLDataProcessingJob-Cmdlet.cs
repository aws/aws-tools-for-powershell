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
using Amazon.Neptunedata;
using Amazon.Neptunedata.Model;

namespace Amazon.PowerShell.Cmdlets.NEPT
{
    /// <summary>
    /// Cancels a Neptune ML data processing job. See <a href="https://docs.aws.amazon.com/neptune/latest/userguide/machine-learning-api-dataprocessing.html">The
    /// <c>dataprocessing</c> command</a>.
    /// 
    ///  
    /// <para>
    /// When invoking this operation in a Neptune cluster that has IAM authentication enabled,
    /// the IAM user or role making the request must have a policy attached that allows the
    /// <a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-dp-actions.html#cancelmldataprocessingjob">neptune-db:CancelMLDataProcessingJob</a>
    /// IAM action in that cluster.
    /// </para>
    /// </summary>
    [Cmdlet("Stop", "NEPTMLDataProcessingJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon NeptuneData CancelMLDataProcessingJob API operation.", Operation = new[] {"CancelMLDataProcessingJob"}, SelectReturnType = typeof(Amazon.Neptunedata.Model.CancelMLDataProcessingJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.Neptunedata.Model.CancelMLDataProcessingJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Neptunedata.Model.CancelMLDataProcessingJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StopNEPTMLDataProcessingJobCmdlet : AmazonNeptunedataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Clean
        /// <summary>
        /// <para>
        /// <para>If set to <c>TRUE</c>, this flag specifies that all Neptune ML S3 artifacts should
        /// be deleted when the job is stopped. The default is <c>FALSE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Clean { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the data-processing job.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter NeptuneIamRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role that provides Neptune access to SageMaker and Amazon S3 resources.
        /// This must be listed in your DB cluster parameter group or an error will occur.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NeptuneIamRoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptunedata.Model.CancelMLDataProcessingJobResponse).
        /// Specifying the name of a property of type Amazon.Neptunedata.Model.CancelMLDataProcessingJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-NEPTMLDataProcessingJob (CancelMLDataProcessingJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptunedata.Model.CancelMLDataProcessingJobResponse, StopNEPTMLDataProcessingJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Clean = this.Clean;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NeptuneIamRoleArn = this.NeptuneIamRoleArn;
            
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
            var request = new Amazon.Neptunedata.Model.CancelMLDataProcessingJobRequest();
            
            if (cmdletContext.Clean != null)
            {
                request.Clean = cmdletContext.Clean.Value;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.NeptuneIamRoleArn != null)
            {
                request.NeptuneIamRoleArn = cmdletContext.NeptuneIamRoleArn;
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
        
        private Amazon.Neptunedata.Model.CancelMLDataProcessingJobResponse CallAWSServiceOperation(IAmazonNeptunedata client, Amazon.Neptunedata.Model.CancelMLDataProcessingJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon NeptuneData", "CancelMLDataProcessingJob");
            try
            {
                #if DESKTOP
                return client.CancelMLDataProcessingJob(request);
                #elif CORECLR
                return client.CancelMLDataProcessingJobAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Clean { get; set; }
            public System.String Id { get; set; }
            public System.String NeptuneIamRoleArn { get; set; }
            public System.Func<Amazon.Neptunedata.Model.CancelMLDataProcessingJobResponse, StopNEPTMLDataProcessingJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
