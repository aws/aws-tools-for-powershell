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
using Amazon.AutoScalingPlans;
using Amazon.AutoScalingPlans.Model;

namespace Amazon.PowerShell.Cmdlets.ASP
{
    /// <summary>
    /// Creates a scaling plan.
    /// </summary>
    [Cmdlet("New", "ASPScalingPlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Int64")]
    [AWSCmdlet("Calls the AWS Auto Scaling Plans CreateScalingPlan API operation.", Operation = new[] {"CreateScalingPlan"}, SelectReturnType = typeof(Amazon.AutoScalingPlans.Model.CreateScalingPlanResponse))]
    [AWSCmdletOutput("System.Int64 or Amazon.AutoScalingPlans.Model.CreateScalingPlanResponse",
        "This cmdlet returns a System.Int64 object.",
        "The service call response (type Amazon.AutoScalingPlans.Model.CreateScalingPlanResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewASPScalingPlanCmdlet : AmazonAutoScalingPlansClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationSource_CloudFormationStackARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a AWS CloudFormation stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationSource_CloudFormationStackARN { get; set; }
        #endregion
        
        #region Parameter ScalingInstruction
        /// <summary>
        /// <para>
        /// <para>The scaling instructions.</para><para>For more information, see <a href="https://docs.aws.amazon.com/autoscaling/plans/APIReference/API_ScalingInstruction.html">ScalingInstruction</a>
        /// in the <i>AWS Auto Scaling API Reference</i>.</para>
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
        [Alias("ScalingInstructions")]
        public Amazon.AutoScalingPlans.Model.ScalingInstruction[] ScalingInstruction { get; set; }
        #endregion
        
        #region Parameter ScalingPlanName
        /// <summary>
        /// <para>
        /// <para>The name of the scaling plan. Names cannot contain vertical bars, colons, or forward
        /// slashes.</para>
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
        public System.String ScalingPlanName { get; set; }
        #endregion
        
        #region Parameter ApplicationSource_TagFilter
        /// <summary>
        /// <para>
        /// <para>A set of tags (up to 50).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplicationSource_TagFilters")]
        public Amazon.AutoScalingPlans.Model.TagFilter[] ApplicationSource_TagFilter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ScalingPlanVersion'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScalingPlans.Model.CreateScalingPlanResponse).
        /// Specifying the name of a property of type Amazon.AutoScalingPlans.Model.CreateScalingPlanResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ScalingPlanVersion";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ScalingPlanName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ScalingPlanName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ScalingPlanName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScalingPlanName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ASPScalingPlan (CreateScalingPlan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScalingPlans.Model.CreateScalingPlanResponse, NewASPScalingPlanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ScalingPlanName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationSource_CloudFormationStackARN = this.ApplicationSource_CloudFormationStackARN;
            if (this.ApplicationSource_TagFilter != null)
            {
                context.ApplicationSource_TagFilter = new List<Amazon.AutoScalingPlans.Model.TagFilter>(this.ApplicationSource_TagFilter);
            }
            if (this.ScalingInstruction != null)
            {
                context.ScalingInstruction = new List<Amazon.AutoScalingPlans.Model.ScalingInstruction>(this.ScalingInstruction);
            }
            #if MODULAR
            if (this.ScalingInstruction == null && ParameterWasBound(nameof(this.ScalingInstruction)))
            {
                WriteWarning("You are passing $null as a value for parameter ScalingInstruction which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScalingPlanName = this.ScalingPlanName;
            #if MODULAR
            if (this.ScalingPlanName == null && ParameterWasBound(nameof(this.ScalingPlanName)))
            {
                WriteWarning("You are passing $null as a value for parameter ScalingPlanName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AutoScalingPlans.Model.CreateScalingPlanRequest();
            
            
             // populate ApplicationSource
            var requestApplicationSourceIsNull = true;
            request.ApplicationSource = new Amazon.AutoScalingPlans.Model.ApplicationSource();
            System.String requestApplicationSource_applicationSource_CloudFormationStackARN = null;
            if (cmdletContext.ApplicationSource_CloudFormationStackARN != null)
            {
                requestApplicationSource_applicationSource_CloudFormationStackARN = cmdletContext.ApplicationSource_CloudFormationStackARN;
            }
            if (requestApplicationSource_applicationSource_CloudFormationStackARN != null)
            {
                request.ApplicationSource.CloudFormationStackARN = requestApplicationSource_applicationSource_CloudFormationStackARN;
                requestApplicationSourceIsNull = false;
            }
            List<Amazon.AutoScalingPlans.Model.TagFilter> requestApplicationSource_applicationSource_TagFilter = null;
            if (cmdletContext.ApplicationSource_TagFilter != null)
            {
                requestApplicationSource_applicationSource_TagFilter = cmdletContext.ApplicationSource_TagFilter;
            }
            if (requestApplicationSource_applicationSource_TagFilter != null)
            {
                request.ApplicationSource.TagFilters = requestApplicationSource_applicationSource_TagFilter;
                requestApplicationSourceIsNull = false;
            }
             // determine if request.ApplicationSource should be set to null
            if (requestApplicationSourceIsNull)
            {
                request.ApplicationSource = null;
            }
            if (cmdletContext.ScalingInstruction != null)
            {
                request.ScalingInstructions = cmdletContext.ScalingInstruction;
            }
            if (cmdletContext.ScalingPlanName != null)
            {
                request.ScalingPlanName = cmdletContext.ScalingPlanName;
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
        
        private Amazon.AutoScalingPlans.Model.CreateScalingPlanResponse CallAWSServiceOperation(IAmazonAutoScalingPlans client, Amazon.AutoScalingPlans.Model.CreateScalingPlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling Plans", "CreateScalingPlan");
            try
            {
                #if DESKTOP
                return client.CreateScalingPlan(request);
                #elif CORECLR
                return client.CreateScalingPlanAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationSource_CloudFormationStackARN { get; set; }
            public List<Amazon.AutoScalingPlans.Model.TagFilter> ApplicationSource_TagFilter { get; set; }
            public List<Amazon.AutoScalingPlans.Model.ScalingInstruction> ScalingInstruction { get; set; }
            public System.String ScalingPlanName { get; set; }
            public System.Func<Amazon.AutoScalingPlans.Model.CreateScalingPlanResponse, NewASPScalingPlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ScalingPlanVersion;
        }
        
    }
}
