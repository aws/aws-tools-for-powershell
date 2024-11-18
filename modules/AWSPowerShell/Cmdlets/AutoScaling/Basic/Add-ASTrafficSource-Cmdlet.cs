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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Attaches one or more traffic sources to the specified Auto Scaling group.
    /// 
    ///  
    /// <para>
    /// You can use any of the following as traffic sources for an Auto Scaling group:
    /// </para><ul><li><para>
    /// Application Load Balancer
    /// </para></li><li><para>
    /// Classic Load Balancer
    /// </para></li><li><para>
    /// Gateway Load Balancer
    /// </para></li><li><para>
    /// Network Load Balancer
    /// </para></li><li><para>
    /// VPC Lattice
    /// </para></li></ul><para>
    /// This operation is additive and does not detach existing traffic sources from the Auto
    /// Scaling group. 
    /// </para><para>
    /// After the operation completes, use the <a href="https://docs.aws.amazon.com/autoscaling/ec2/APIReference/API_DescribeTrafficSources.html">DescribeTrafficSources</a>
    /// API to return details about the state of the attachments between traffic sources and
    /// your Auto Scaling group. To detach a traffic source from the Auto Scaling group, call
    /// the <a href="https://docs.aws.amazon.com/autoscaling/ec2/APIReference/API_DetachTrafficSources.html">DetachTrafficSources</a>
    /// API.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "ASTrafficSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Auto Scaling AttachTrafficSources API operation.", Operation = new[] {"AttachTrafficSources"}, SelectReturnType = typeof(Amazon.AutoScaling.Model.AttachTrafficSourcesResponse))]
    [AWSCmdletOutput("None or Amazon.AutoScaling.Model.AttachTrafficSourcesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AutoScaling.Model.AttachTrafficSourcesResponse) be returned by specifying '-Select *'."
    )]
    public partial class AddASTrafficSourceCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Auto Scaling group.</para>
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
        public System.String AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter SkipZonalShiftValidation
        /// <summary>
        /// <para>
        /// <para> If you enable zonal shift with cross-zone disabled load balancers, capacity could
        /// become imbalanced across Availability Zones. To skip the validation, specify <c>true</c>.
        /// For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-zonal-shift.html">Auto
        /// Scaling group zonal shift</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SkipZonalShiftValidation { get; set; }
        #endregion
        
        #region Parameter TrafficSource
        /// <summary>
        /// <para>
        /// <para>The unique identifiers of one or more traffic sources. You can specify up to 10 traffic
        /// sources.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TrafficSources")]
        public Amazon.AutoScaling.Model.TrafficSourceIdentifier[] TrafficSource { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScaling.Model.AttachTrafficSourcesResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TrafficSource parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TrafficSource' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TrafficSource' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrafficSource), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-ASTrafficSource (AttachTrafficSources)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScaling.Model.AttachTrafficSourcesResponse, AddASTrafficSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TrafficSource;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            #if MODULAR
            if (this.AutoScalingGroupName == null && ParameterWasBound(nameof(this.AutoScalingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoScalingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SkipZonalShiftValidation = this.SkipZonalShiftValidation;
            if (this.TrafficSource != null)
            {
                context.TrafficSource = new List<Amazon.AutoScaling.Model.TrafficSourceIdentifier>(this.TrafficSource);
            }
            #if MODULAR
            if (this.TrafficSource == null && ParameterWasBound(nameof(this.TrafficSource)))
            {
                WriteWarning("You are passing $null as a value for parameter TrafficSource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AutoScaling.Model.AttachTrafficSourcesRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            if (cmdletContext.SkipZonalShiftValidation != null)
            {
                request.SkipZonalShiftValidation = cmdletContext.SkipZonalShiftValidation.Value;
            }
            if (cmdletContext.TrafficSource != null)
            {
                request.TrafficSources = cmdletContext.TrafficSource;
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
        
        private Amazon.AutoScaling.Model.AttachTrafficSourcesResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.AttachTrafficSourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling", "AttachTrafficSources");
            try
            {
                #if DESKTOP
                return client.AttachTrafficSources(request);
                #elif CORECLR
                return client.AttachTrafficSourcesAsync(request).GetAwaiter().GetResult();
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
            public System.String AutoScalingGroupName { get; set; }
            public System.Boolean? SkipZonalShiftValidation { get; set; }
            public List<Amazon.AutoScaling.Model.TrafficSourceIdentifier> TrafficSource { get; set; }
            public System.Func<Amazon.AutoScaling.Model.AttachTrafficSourcesResponse, AddASTrafficSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
