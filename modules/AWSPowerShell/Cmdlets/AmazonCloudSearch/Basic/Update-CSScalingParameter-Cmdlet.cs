/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Invokes the UpdateScalingParameters operation against Amazon CloudSearch.", Operation = new[] {"UpdateScalingParameters"})]
    [AWSCmdletOutput("Amazon.CloudSearch.Model.ScalingParametersStatus",
        "This cmdlet returns a ScalingParametersStatus object.",
        "The service call response (type Amazon.CloudSearch.Model.UpdateScalingParametersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCSScalingParameterCmdlet : AmazonCloudSearchClientCmdlet, IExecutor
    {
        
        #region Parameter ScalingParameters_DesiredInstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type that you want to preconfigure for your domain. For example, <code>search.m1.small</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudSearch.PartitionInstanceType")]
        public Amazon.CloudSearch.PartitionInstanceType ScalingParameters_DesiredInstanceType { get; set; }
        #endregion
        
        #region Parameter ScalingParameters_DesiredPartitionCount
        /// <summary>
        /// <para>
        /// <para>The number of partitions you want to preconfigure for your domain. Only valid when
        /// you select <code>m2.2xlarge</code> as the desired instance type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ScalingParameters_DesiredPartitionCount { get; set; }
        #endregion
        
        #region Parameter ScalingParameters_DesiredReplicationCount
        /// <summary>
        /// <para>
        /// <para>The number of replicas you want to preconfigure for each index partition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ScalingParameters_DesiredReplicationCount { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DomainName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CSScalingParameter (UpdateScalingParameters)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.DomainName = this.DomainName;
            context.ScalingParameters_DesiredInstanceType = this.ScalingParameters_DesiredInstanceType;
            if (ParameterWasBound("ScalingParameters_DesiredPartitionCount"))
                context.ScalingParameters_DesiredPartitionCount = this.ScalingParameters_DesiredPartitionCount;
            if (ParameterWasBound("ScalingParameters_DesiredReplicationCount"))
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
            bool requestScalingParametersIsNull = true;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ScalingParameters;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private static Amazon.CloudSearch.Model.UpdateScalingParametersResponse CallAWSServiceOperation(IAmazonCloudSearch client, Amazon.CloudSearch.Model.UpdateScalingParametersRequest request)
        {
            #if DESKTOP
            return client.UpdateScalingParameters(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateScalingParametersAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String DomainName { get; set; }
            public Amazon.CloudSearch.PartitionInstanceType ScalingParameters_DesiredInstanceType { get; set; }
            public System.Int32? ScalingParameters_DesiredPartitionCount { get; set; }
            public System.Int32? ScalingParameters_DesiredReplicationCount { get; set; }
        }
        
    }
}
