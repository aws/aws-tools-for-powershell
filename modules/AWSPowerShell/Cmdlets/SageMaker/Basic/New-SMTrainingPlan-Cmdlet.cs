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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates a new training plan in SageMaker to reserve compute capacity.
    /// 
    ///  
    /// <para>
    /// Amazon SageMaker Training Plan is a capability within SageMaker that allows customers
    /// to reserve and manage GPU capacity for large-scale AI model training. It provides
    /// a way to secure predictable access to computational resources within specific timelines
    /// and budgets, without the need to manage underlying infrastructure. 
    /// </para><para><b>How it works</b></para><para>
    /// Plans can be created for specific resources such as SageMaker Training Jobs or SageMaker
    /// HyperPod clusters, automatically provisioning resources, setting up infrastructure,
    /// executing workloads, and handling infrastructure failures.
    /// </para><para><b>Plan creation workflow</b></para><ul><li><para>
    /// Users search for available plan offerings based on their requirements (e.g., instance
    /// type, count, start time, duration) using the <c><a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_SearchTrainingPlanOfferings.html">SearchTrainingPlanOfferings</a></c> API operation.
    /// </para></li><li><para>
    /// They create a plan that best matches their needs using the ID of the plan offering
    /// they want to use. 
    /// </para></li><li><para>
    /// After successful upfront payment, the plan's status becomes <c>Scheduled</c>. 
    /// </para></li><li><para>
    /// The plan can be used to:
    /// </para><ul><li><para>
    /// Queue training jobs.
    /// </para></li><li><para>
    /// Allocate to an instance group of a SageMaker HyperPod cluster. 
    /// </para></li></ul></li><li><para>
    /// When the plan start date arrives, it becomes <c>Active</c>. Based on available reserved
    /// capacity:
    /// </para><ul><li><para>
    /// Training jobs are launched.
    /// </para></li><li><para>
    /// Instance groups are provisioned.
    /// </para></li></ul></li></ul><para><b>Plan composition</b></para><para>
    /// A plan can consist of one or more Reserved Capacities, each defined by a specific
    /// instance type, quantity, Availability Zone, duration, and start and end times. For
    /// more information about Reserved Capacity, see <c><a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_ReservedCapacitySummary.html">ReservedCapacitySummary</a></c>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMTrainingPlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateTrainingPlan API operation.", Operation = new[] {"CreateTrainingPlan"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateTrainingPlanResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateTrainingPlanResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateTrainingPlanResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMTrainingPlanCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs to apply to this training plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TrainingPlanName
        /// <summary>
        /// <para>
        /// <para>The name of the training plan to create.</para>
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
        public System.String TrainingPlanName { get; set; }
        #endregion
        
        #region Parameter TrainingPlanOfferingId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the training plan offering to use for creating this plan.</para>
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
        public System.String TrainingPlanOfferingId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrainingPlanArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateTrainingPlanResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateTrainingPlanResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrainingPlanArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrainingPlanName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMTrainingPlan (CreateTrainingPlan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateTrainingPlanResponse, NewSMTrainingPlanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            context.TrainingPlanName = this.TrainingPlanName;
            #if MODULAR
            if (this.TrainingPlanName == null && ParameterWasBound(nameof(this.TrainingPlanName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainingPlanName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrainingPlanOfferingId = this.TrainingPlanOfferingId;
            #if MODULAR
            if (this.TrainingPlanOfferingId == null && ParameterWasBound(nameof(this.TrainingPlanOfferingId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainingPlanOfferingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.CreateTrainingPlanRequest();
            
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TrainingPlanName != null)
            {
                request.TrainingPlanName = cmdletContext.TrainingPlanName;
            }
            if (cmdletContext.TrainingPlanOfferingId != null)
            {
                request.TrainingPlanOfferingId = cmdletContext.TrainingPlanOfferingId;
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
        
        private Amazon.SageMaker.Model.CreateTrainingPlanResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateTrainingPlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateTrainingPlan");
            try
            {
                return client.CreateTrainingPlanAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.String TrainingPlanName { get; set; }
            public System.String TrainingPlanOfferingId { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateTrainingPlanResponse, NewSMTrainingPlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrainingPlanArn;
        }
        
    }
}
