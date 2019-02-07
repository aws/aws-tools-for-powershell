/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the placement attributes for a specified instance. You can do the following:
    /// 
    ///  <ul><li><para>
    /// Modify the affinity between an instance and a <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/dedicated-hosts-overview.html">Dedicated
    /// Host</a>. When affinity is set to <code>host</code> and the instance is not associated
    /// with a specific Dedicated Host, the next time the instance is launched, it is automatically
    /// associated with the host on which it lands. If the instance is restarted or rebooted,
    /// this relationship persists.
    /// </para></li><li><para>
    /// Change the Dedicated Host with which an instance is associated.
    /// </para></li><li><para>
    /// Change the instance tenancy of an instance from <code>host</code> to <code>dedicated</code>,
    /// or from <code>dedicated</code> to <code>host</code>.
    /// </para></li><li><para>
    /// Move an instance to or from a <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/placement-groups.html">placement
    /// group</a>.
    /// </para></li></ul><para>
    /// At least one attribute for affinity, host ID, tenancy, or placement group name must
    /// be specified in the request. Affinity and tenancy can be modified in the same request.
    /// </para><para>
    /// To modify the host ID, tenancy, placement group, or partition for an instance, the
    /// instance must be in the <code>stopped</code> state.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2InstancePlacement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud ModifyInstancePlacement API operation.", Operation = new[] {"ModifyInstancePlacement"})]
    [AWSCmdletOutput("System.Boolean",
        "This cmdlet returns a Boolean object.",
        "The service call response (type Amazon.EC2.Model.ModifyInstancePlacementResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2InstancePlacementCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Affinity
        /// <summary>
        /// <para>
        /// <para>The affinity setting for the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.Affinity")]
        public Amazon.EC2.Affinity Affinity { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para>The name of the placement group in which to place the instance. For spread placement
        /// groups, the instance must have a tenancy of <code>default</code>. For cluster and
        /// partition placement groups, the instance must have a tenancy of <code>default</code>
        /// or <code>dedicated</code>.</para><para>To remove an instance from a placement group, specify an empty string ("").</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String GroupName { get; set; }
        #endregion
        
        #region Parameter HostId
        /// <summary>
        /// <para>
        /// <para>The ID of the Dedicated Host with which to associate the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HostId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance that you are modifying.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter PartitionNumber
        /// <summary>
        /// <para>
        /// <para>Reserved for future use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 PartitionNumber { get; set; }
        #endregion
        
        #region Parameter Tenancy
        /// <summary>
        /// <para>
        /// <para>The tenancy for the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.HostTenancy")]
        public Amazon.EC2.HostTenancy Tenancy { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2InstancePlacement (ModifyInstancePlacement)"))
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
            
            context.Affinity = this.Affinity;
            context.GroupName = this.GroupName;
            context.HostId = this.HostId;
            context.InstanceId = this.InstanceId;
            if (ParameterWasBound("PartitionNumber"))
                context.PartitionNumber = this.PartitionNumber;
            context.Tenancy = this.Tenancy;
            
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
            var request = new Amazon.EC2.Model.ModifyInstancePlacementRequest();
            
            if (cmdletContext.Affinity != null)
            {
                request.Affinity = cmdletContext.Affinity;
            }
            if (cmdletContext.GroupName != null)
            {
                request.GroupName = cmdletContext.GroupName;
            }
            if (cmdletContext.HostId != null)
            {
                request.HostId = cmdletContext.HostId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.PartitionNumber != null)
            {
                request.PartitionNumber = cmdletContext.PartitionNumber.Value;
            }
            if (cmdletContext.Tenancy != null)
            {
                request.Tenancy = cmdletContext.Tenancy;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Return;
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
        
        private Amazon.EC2.Model.ModifyInstancePlacementResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyInstancePlacementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "ModifyInstancePlacement");
            try
            {
                #if DESKTOP
                return client.ModifyInstancePlacement(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ModifyInstancePlacementAsync(request);
                return task.Result;
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
            public Amazon.EC2.Affinity Affinity { get; set; }
            public System.String GroupName { get; set; }
            public System.String HostId { get; set; }
            public System.String InstanceId { get; set; }
            public System.Int32? PartitionNumber { get; set; }
            public Amazon.EC2.HostTenancy Tenancy { get; set; }
        }
        
    }
}
