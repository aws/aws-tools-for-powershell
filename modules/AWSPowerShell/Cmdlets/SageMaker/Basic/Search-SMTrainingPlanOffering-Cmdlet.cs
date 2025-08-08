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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Searches for available training plan offerings based on specified criteria. 
    /// 
    ///  <ul><li><para>
    /// Users search for available plan offerings based on their requirements (e.g., instance
    /// type, count, start time, duration). 
    /// </para></li><li><para>
    /// And then, they create a plan that best matches their needs using the ID of the plan
    /// offering they want to use. 
    /// </para></li></ul><para>
    /// For more information about how to reserve GPU capacity for your SageMaker training
    /// jobs or SageMaker HyperPod clusters using Amazon SageMaker Training Plan , see <c><a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateTrainingPlan.html">CreateTrainingPlan</a></c>.
    /// </para>
    /// </summary>
    [Cmdlet("Search", "SMTrainingPlanOffering", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.TrainingPlanOffering")]
    [AWSCmdlet("Calls the Amazon SageMaker Service SearchTrainingPlanOfferings API operation.", Operation = new[] {"SearchTrainingPlanOfferings"}, SelectReturnType = typeof(Amazon.SageMaker.Model.SearchTrainingPlanOfferingsResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.TrainingPlanOffering or Amazon.SageMaker.Model.SearchTrainingPlanOfferingsResponse",
        "This cmdlet returns a collection of Amazon.SageMaker.Model.TrainingPlanOffering objects.",
        "The service call response (type Amazon.SageMaker.Model.SearchTrainingPlanOfferingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SearchSMTrainingPlanOfferingCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DurationHour
        /// <summary>
        /// <para>
        /// <para>The desired duration in hours for the training plan offerings.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DurationHours")]
        public System.Int64? DurationHour { get; set; }
        #endregion
        
        #region Parameter EndTimeBefore
        /// <summary>
        /// <para>
        /// <para>A filter to search for reserved capacity offerings with an end time before a specified
        /// date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTimeBefore { get; set; }
        #endregion
        
        #region Parameter InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of instances you want to reserve in the training plan offerings. This allows
        /// you to specify the quantity of compute resources needed for your SageMaker training
        /// jobs or SageMaker HyperPod clusters, helping you find reserved capacity offerings
        /// that match your requirements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceCount { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The type of instance you want to search for in the available training plan offerings.
        /// This field allows you to filter the search results based on the specific compute resources
        /// you require for your SageMaker training jobs or SageMaker HyperPod clusters. When
        /// searching for training plan offerings, specifying the instance type helps you find
        /// Reserved Instances that match your computational needs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ReservedCapacityInstanceType")]
        public Amazon.SageMaker.ReservedCapacityInstanceType InstanceType { get; set; }
        #endregion
        
        #region Parameter StartTimeAfter
        /// <summary>
        /// <para>
        /// <para>A filter to search for training plan offerings with a start time after a specified
        /// date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTimeAfter { get; set; }
        #endregion
        
        #region Parameter TargetResource
        /// <summary>
        /// <para>
        /// <para>The target resources (e.g., SageMaker Training Jobs, SageMaker HyperPod) to search
        /// for in the offerings.</para><para>Training plans are specific to their target resource.</para><ul><li><para>A training plan designed for SageMaker training jobs can only be used to schedule
        /// and run training jobs.</para></li><li><para>A training plan for HyperPod clusters can be used exclusively to provide compute resources
        /// to a cluster's instance group.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TargetResources")]
        public System.String[] TargetResource { get; set; }
        #endregion
        
        #region Parameter UltraServerCount
        /// <summary>
        /// <para>
        /// <para>The number of UltraServers to search for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UltraServerCount { get; set; }
        #endregion
        
        #region Parameter UltraServerType
        /// <summary>
        /// <para>
        /// <para>The type of UltraServer to search for, such as ml.u-p6e-gb200x72.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UltraServerType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrainingPlanOfferings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.SearchTrainingPlanOfferingsResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.SearchTrainingPlanOfferingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrainingPlanOfferings";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-SMTrainingPlanOffering (SearchTrainingPlanOfferings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.SearchTrainingPlanOfferingsResponse, SearchSMTrainingPlanOfferingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DurationHour = this.DurationHour;
            #if MODULAR
            if (this.DurationHour == null && ParameterWasBound(nameof(this.DurationHour)))
            {
                WriteWarning("You are passing $null as a value for parameter DurationHour which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndTimeBefore = this.EndTimeBefore;
            context.InstanceCount = this.InstanceCount;
            context.InstanceType = this.InstanceType;
            context.StartTimeAfter = this.StartTimeAfter;
            if (this.TargetResource != null)
            {
                context.TargetResource = new List<System.String>(this.TargetResource);
            }
            #if MODULAR
            if (this.TargetResource == null && ParameterWasBound(nameof(this.TargetResource)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetResource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UltraServerCount = this.UltraServerCount;
            context.UltraServerType = this.UltraServerType;
            
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
            var request = new Amazon.SageMaker.Model.SearchTrainingPlanOfferingsRequest();
            
            if (cmdletContext.DurationHour != null)
            {
                request.DurationHours = cmdletContext.DurationHour.Value;
            }
            if (cmdletContext.EndTimeBefore != null)
            {
                request.EndTimeBefore = cmdletContext.EndTimeBefore.Value;
            }
            if (cmdletContext.InstanceCount != null)
            {
                request.InstanceCount = cmdletContext.InstanceCount.Value;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.StartTimeAfter != null)
            {
                request.StartTimeAfter = cmdletContext.StartTimeAfter.Value;
            }
            if (cmdletContext.TargetResource != null)
            {
                request.TargetResources = cmdletContext.TargetResource;
            }
            if (cmdletContext.UltraServerCount != null)
            {
                request.UltraServerCount = cmdletContext.UltraServerCount.Value;
            }
            if (cmdletContext.UltraServerType != null)
            {
                request.UltraServerType = cmdletContext.UltraServerType;
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
        
        private Amazon.SageMaker.Model.SearchTrainingPlanOfferingsResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.SearchTrainingPlanOfferingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "SearchTrainingPlanOfferings");
            try
            {
                return client.SearchTrainingPlanOfferingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int64? DurationHour { get; set; }
            public System.DateTime? EndTimeBefore { get; set; }
            public System.Int32? InstanceCount { get; set; }
            public Amazon.SageMaker.ReservedCapacityInstanceType InstanceType { get; set; }
            public System.DateTime? StartTimeAfter { get; set; }
            public List<System.String> TargetResource { get; set; }
            public System.Int32? UltraServerCount { get; set; }
            public System.String UltraServerType { get; set; }
            public System.Func<Amazon.SageMaker.Model.SearchTrainingPlanOfferingsResponse, SearchSMTrainingPlanOfferingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrainingPlanOfferings;
        }
        
    }
}
