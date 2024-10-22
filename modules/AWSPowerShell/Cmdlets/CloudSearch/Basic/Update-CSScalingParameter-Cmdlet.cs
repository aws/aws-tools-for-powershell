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
using Amazon.CloudSearch;
using Amazon.CloudSearch.Model;

namespace Amazon.PowerShell.Cmdlets.CS
{
    /// <summary>
    /// Configures scaling parameters for a domain. A domain's scaling parameters specify
    /// the desired search instance type and replication count. Amazon CloudSearch will still
    /// automatically scale your domain based on the volume of data and traffic, but not below
    /// the desired instance type and replication count. If the Multi-AZ option is enabled,
    /// these values control the resources used per Availability Zone. For more information,
    /// see <a href="http://docs.aws.amazon.com/cloudsearch/latest/developerguide/configuring-scaling-options.html" target="_blank">Configuring Scaling Options</a> in the <i>Amazon CloudSearch Developer
    /// Guide</i>.
    /// </summary>
    [Cmdlet("Update", "CSScalingParameter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudSearch.Model.ScalingParametersStatus")]
    [AWSCmdlet("Calls the Amazon CloudSearch UpdateScalingParameters API operation.", Operation = new[] {"UpdateScalingParameters"}, SelectReturnType = typeof(Amazon.CloudSearch.Model.UpdateScalingParametersResponse), LegacyAlias="Update-CSScalingParameters")]
    [AWSCmdletOutput("Amazon.CloudSearch.Model.ScalingParametersStatus or Amazon.CloudSearch.Model.UpdateScalingParametersResponse",
        "This cmdlet returns an Amazon.CloudSearch.Model.ScalingParametersStatus object.",
        "The service call response (type Amazon.CloudSearch.Model.UpdateScalingParametersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCSScalingParameterCmdlet : AmazonCloudSearchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ScalingParameters_DesiredInstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type that you want to preconfigure for your domain. For example, <c>search.m1.small</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudSearch.PartitionInstanceType")]
        public Amazon.CloudSearch.PartitionInstanceType ScalingParameters_DesiredInstanceType { get; set; }
        #endregion
        
        #region Parameter ScalingParameters_DesiredPartitionCount
        /// <summary>
        /// <para>
        /// <para>The number of partitions you want to preconfigure for your domain. Only valid when
        /// you select <c>m2.2xlarge</c> as the desired instance type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingParameters_DesiredPartitionCount { get; set; }
        #endregion
        
        #region Parameter ScalingParameters_DesiredReplicationCount
        /// <summary>
        /// <para>
        /// <para>The number of replicas you want to preconfigure for each index partition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingParameters_DesiredReplicationCount { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ScalingParameters'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudSearch.Model.UpdateScalingParametersResponse).
        /// Specifying the name of a property of type Amazon.CloudSearch.Model.UpdateScalingParametersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ScalingParameters";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CSScalingParameter (UpdateScalingParameters)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudSearch.Model.UpdateScalingParametersResponse, UpdateCSScalingParameterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScalingParameters_DesiredInstanceType = this.ScalingParameters_DesiredInstanceType;
            context.ScalingParameters_DesiredPartitionCount = this.ScalingParameters_DesiredPartitionCount;
            context.ScalingParameters_DesiredReplicationCount = this.ScalingParameters_DesiredReplicationCount;
            
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
            var request = new Amazon.CloudSearch.Model.UpdateScalingParametersRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate ScalingParameters
            var requestScalingParametersIsNull = true;
            request.ScalingParameters = new Amazon.CloudSearch.Model.ScalingParameters();
            Amazon.CloudSearch.PartitionInstanceType requestScalingParameters_scalingParameters_DesiredInstanceType = null;
            if (cmdletContext.ScalingParameters_DesiredInstanceType != null)
            {
                requestScalingParameters_scalingParameters_DesiredInstanceType = cmdletContext.ScalingParameters_DesiredInstanceType;
            }
            if (requestScalingParameters_scalingParameters_DesiredInstanceType != null)
            {
                request.ScalingParameters.DesiredInstanceType = requestScalingParameters_scalingParameters_DesiredInstanceType;
                requestScalingParametersIsNull = false;
            }
            System.Int32? requestScalingParameters_scalingParameters_DesiredPartitionCount = null;
            if (cmdletContext.ScalingParameters_DesiredPartitionCount != null)
            {
                requestScalingParameters_scalingParameters_DesiredPartitionCount = cmdletContext.ScalingParameters_DesiredPartitionCount.Value;
            }
            if (requestScalingParameters_scalingParameters_DesiredPartitionCount != null)
            {
                request.ScalingParameters.DesiredPartitionCount = requestScalingParameters_scalingParameters_DesiredPartitionCount.Value;
                requestScalingParametersIsNull = false;
            }
            System.Int32? requestScalingParameters_scalingParameters_DesiredReplicationCount = null;
            if (cmdletContext.ScalingParameters_DesiredReplicationCount != null)
            {
                requestScalingParameters_scalingParameters_DesiredReplicationCount = cmdletContext.ScalingParameters_DesiredReplicationCount.Value;
            }
            if (requestScalingParameters_scalingParameters_DesiredReplicationCount != null)
            {
                request.ScalingParameters.DesiredReplicationCount = requestScalingParameters_scalingParameters_DesiredReplicationCount.Value;
                requestScalingParametersIsNull = false;
            }
             // determine if request.ScalingParameters should be set to null
            if (requestScalingParametersIsNull)
            {
                request.ScalingParameters = null;
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
        
        private Amazon.CloudSearch.Model.UpdateScalingParametersResponse CallAWSServiceOperation(IAmazonCloudSearch client, Amazon.CloudSearch.Model.UpdateScalingParametersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudSearch", "UpdateScalingParameters");
            try
            {
                #if DESKTOP
                return client.UpdateScalingParameters(request);
                #elif CORECLR
                return client.UpdateScalingParametersAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainName { get; set; }
            public Amazon.CloudSearch.PartitionInstanceType ScalingParameters_DesiredInstanceType { get; set; }
            public System.Int32? ScalingParameters_DesiredPartitionCount { get; set; }
            public System.Int32? ScalingParameters_DesiredReplicationCount { get; set; }
            public System.Func<Amazon.CloudSearch.Model.UpdateScalingParametersResponse, UpdateCSScalingParameterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ScalingParameters;
        }
        
    }
}
